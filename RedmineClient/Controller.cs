using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RedmineClient.Models;

namespace RedmineClient
{
    /// <summary>
    /// Перечисление возможных ошибок, возникающих в резульате запроса к серверу.
    /// </summary>
    public enum ErrorTypes { NoErrors, NoInternetConnection, UnathorizedAccess }

    /// <summary>
    /// Класс, представляющий собой контроллер для взаимодействия с данными (реализация паттерна MVC).
    /// </summary>
    public class Controller
    {
        private string REDMINE_HOST = "http://student-rm.exactpro.com/";

        // Список проектов, в которых участвует текущий пользователь
        private List<Projects> projects;
        // Список задач для выбранного проекта
        private List<Issue> issues;

        // Событие изменения api-ключа
        public event Action<ErrorTypes, bool> OnAPIKeyChanged;
        // Событие обновления списка проектов, в которых участвует текущий пользователь
        public event Action<ErrorTypes, List<Projects>> OnProjectsUpdated;
        // Событие обновление списка задач для выбранного проекта
        public event Action<ErrorTypes, List<Issue>, string> OnIssuesUpdated;

        /// <summary>
        /// Метод, осуществляющий проверку заданного api-ключа на валидность с последующим сохранением его на локальной машине.
        /// </summary>
        /// <param name="APIKey">api-ключ текущего пользователя.</param>
        public void ChangeAPIKey(string APIKey)
        {
            new Thread(delegate()
                {
                    if (Utils.IsNetworkAvailable())
                    {
                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "users/current.json");
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", APIKey);
                            request.Accept = "application/json";
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            string jsonResult = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            User currentUser = JsonConvert.DeserializeObject<UserJSONObject>(jsonResult).User;
                            Properties.Settings.Default.id = currentUser.ID;
                            Properties.Settings.Default.login = currentUser.Login;
                            Properties.Settings.Default.first_name = currentUser.FirstName;
                            Properties.Settings.Default.last_name = currentUser.LastName;
                            Properties.Settings.Default.email = currentUser.Email;
                            Properties.Settings.Default.created_on = currentUser.CreatedOn;
                            if (Properties.Settings.Default.api_key != APIKey)
                            {
                                Properties.Settings.Default.api_key = APIKey;
                                if (OnAPIKeyChanged != null)
                                    OnAPIKeyChanged(ErrorTypes.NoErrors, true);
                            }
                            else if (OnAPIKeyChanged != null)
                                OnAPIKeyChanged(ErrorTypes.NoErrors, false);
                            Properties.Settings.Default.Save();
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("401") && OnAPIKeyChanged != null)
                                OnAPIKeyChanged(ErrorTypes.UnathorizedAccess, false);
                        }
                    }
                    else if (OnAPIKeyChanged != null)
                        OnAPIKeyChanged(ErrorTypes.NoInternetConnection, false);
                }).Start();
        }

        /// <summary>
        /// Метод, осуществляющий обновление списка проектов, в которых участвует текущий пользователь.
        /// </summary>
        public void UpdateProjects()
        {
            new Thread(delegate()
                {
                    if (Utils.IsNetworkAvailable())
                    {
                        try
                        {
                            HttpWebRequest request;
                            HttpWebResponse response;
                            StreamReader streamReader;
                            string jsonResult;
                            projects = new List<Projects>();
                            ProjectsJSONObject projectsJSONObject = new ProjectsJSONObject();
                            int offset = 0;
                            do
                            {
                                request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "projects.json?offset=" + offset);
                                request.Method = "GET";
                                request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                                request.Accept = "application/json";
                                response = (HttpWebResponse)request.GetResponse();
                                streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                                jsonResult = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                projectsJSONObject = JsonConvert.DeserializeObject<ProjectsJSONObject>(jsonResult);
                                projects.AddRange(projectsJSONObject.Projects);
                                offset += projectsJSONObject.Limit;
                            } while (projectsJSONObject.Projects.Count != 0);
                            if (OnProjectsUpdated != null)
                                OnProjectsUpdated(ErrorTypes.NoErrors, projects);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("401") && OnProjectsUpdated != null)
                                OnProjectsUpdated(ErrorTypes.UnathorizedAccess, null);
                        }
                    }
                    else if (OnProjectsUpdated != null)
                        OnProjectsUpdated(ErrorTypes.NoInternetConnection, null);
                }).Start();
        }

        /// <summary>
        /// Метод, осуществляющий обновление списка задач для указанного проекта.
        /// </summary>
        /// <param name="projectID">Идентификатор проекта, для которого необходимо получить список задач.</param>
        public void UpdateIssues(long projectID)
        {
            new Thread(delegate()
                {
                    if (Utils.IsNetworkAvailable())
                    {
                        try
                        {
                            HttpWebRequest request;
                            HttpWebResponse response;
                            StreamReader streamReader;
                            string jsonResult;
                            issues = new List<Issue>();
                            IssuesJSONObject issuesJSONObject = new IssuesJSONObject();
                            int offset = 0;
                            do
                            {
                                request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues.json?offset=" + offset);
                                request.Method = "GET";
                                request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                                request.Accept = "application/json";
                                response = (HttpWebResponse)request.GetResponse();
                                streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                                jsonResult = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                issuesJSONObject = JsonConvert.DeserializeObject<IssuesJSONObject>(jsonResult);
                                issues.AddRange(issuesJSONObject.Issues);
                                offset += issuesJSONObject.Limit;
                            } while (issuesJSONObject.Issues.Count != 0);
                            issues.RemoveAll(temp => temp.Project.ID != projectID);

                            // Получаем также список участников проекта для последующего вычисления ролей в нем текущего пользователя
                            List<Membership> memberships = new List<Membership>();
                            MembershipsJSONObject membershipsJSONObject = new MembershipsJSONObject();
                            offset = 0;
                            do
                            {
                                request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "/projects/" + projectID + "/memberships.json?offset=" + offset);
                                request.Method = "GET";
                                request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                                request.Accept = "application/json";
                                response = (HttpWebResponse)request.GetResponse();
                                streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                                jsonResult = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                membershipsJSONObject = JsonConvert.DeserializeObject<MembershipsJSONObject>(jsonResult);
                                memberships.AddRange(membershipsJSONObject.Memberships);
                                offset += membershipsJSONObject.Limit;
                            } while (membershipsJSONObject.Memberships.FindIndex(temp => temp.Member.ID == Properties.Settings.Default.id) < 0 && membershipsJSONObject.Memberships.Count != 0);
                            Membership membership = null;
                            foreach (Membership currentMembership in memberships)
                                if (currentMembership.Member.ID == Properties.Settings.Default.id)
                                {
                                    membership = currentMembership;
                                    break;
                                }
                            string projectRoles = "";
                            foreach (Role role in membership.Roles)
                                projectRoles += role.Name + ", ";
                            projectRoles = projectRoles.Remove(projectRoles.Length - 2);
                            if (OnIssuesUpdated != null)
                                OnIssuesUpdated(ErrorTypes.NoErrors, issues, projectRoles);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("401") && OnIssuesUpdated != null)
                                OnIssuesUpdated(ErrorTypes.UnathorizedAccess, null, null);
                        }
                    }
                    else if (OnIssuesUpdated != null)
                        OnIssuesUpdated(ErrorTypes.NoInternetConnection, null, null);
                }).Start();
        }

        /// <summary>
        /// Метод, возвращающий информацию о проекте по его идентификатору.
        /// </summary>
        /// <param name="projectID">Идентификатор проекта.</param>
        /// <returns>Объект типа Project.</returns>
        public Projects GetProject(long projectID)
        {
            return projects.Single(temp => temp.ID == projectID);
        }

        /// <summary>
        /// Метод, возвращающий информацию о задаче по ее идентификатору.
        /// </summary>
        /// <param name="projectID">Идентификатор задачи.</param>
        /// <returns>Объект типа Issue.</returns>
        public Issue GetIssue(long issueID)
        {
            return issues.Single(temp => temp.ID == issueID);
        }
    }
}
