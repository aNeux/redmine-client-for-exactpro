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
        // URL-адрес Redmine сервера
        private string REDMINE_HOST = "http://student-rm.exactpro.com/";

        // Список проектов, в которых участвует текущий пользователь
        private List<Project> projects;
        // Список задач для выбранного проекта
        private List<Issue> issues;

        // Событие, возникающее при изменении api-ключа
        public event Action<ErrorTypes, bool> OnAPIKeyChanged;
        // Событие, возникающее после обновления списка проектов, в которых участвует текущий пользователь
        public event Action<ErrorTypes, List<Project>> OnProjectsUpdated;
        // Событие, возникающее после обновления списка задач для выбранного проекта
        public event Action<ErrorTypes, List<Issue>, string> OnIssuesUpdated;
        // Событие, информирующее о готовности к созданию новой задачи
        public event Action<ErrorTypes, List<Tracker>, List<IssuePriority>, List<Membership>> OnPreparedToCreateNewIssue;
        // Событие, возникающее после создания новой задачи
        public event Action<ErrorTypes> OnIssueCreated;

        /// <summary>
        /// Проверку заданного api-ключа на валидность с последующим сохранением его локально.
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
                            string jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            User currentUser = JsonConvert.DeserializeObject<UserJSONObject>(jsonResponse).User;
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
        /// Обновление списка проектов, в которых участвует текущий пользователь.
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
                            string jsonResponse;
                            projects = new List<Project>();
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
                                jsonResponse = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                projectsJSONObject = JsonConvert.DeserializeObject<ProjectsJSONObject>(jsonResponse);
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
        /// Обновление списка задач для указанного проекта.
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
                            string jsonResponse;
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
                                jsonResponse = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                issuesJSONObject = JsonConvert.DeserializeObject<IssuesJSONObject>(jsonResponse);
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
                                jsonResponse = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                membershipsJSONObject = JsonConvert.DeserializeObject<MembershipsJSONObject>(jsonResponse);
                                memberships.AddRange(membershipsJSONObject.Memberships);
                                offset += membershipsJSONObject.Limit;
                            } while (membershipsJSONObject.Memberships.FindIndex(temp => temp.Member.ID == Properties.Settings.Default.id) < 0 && membershipsJSONObject.Memberships.Count != 0);
                            projects.Single(temp => temp.ID == projectID).Memberships = memberships;
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
        /// Загрузка необходимой информации для подготовки к созданию новой задачи.
        /// </summary>
        /// <param name="projectID">Идентификатор проекта.</param>
        public void PrepareDataForCreatingNewIssue(long projectID)
        {
            new Thread(
                delegate()
                {
                    if (Utils.IsNetworkAvailable())
                    {
                        try
                        {
                            HttpWebRequest request;
                            HttpWebResponse response;
                            StreamReader streamReader;
                            string jsonResponse;
                            // Получаем список трекеров (типов задачи)
                            request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "trackers.json");
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                            request.Accept = "application/json";
                            response = (HttpWebResponse)request.GetResponse();
                            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            List<Tracker> trackers = JsonConvert.DeserializeObject<TrackersJSONObject>(jsonResponse).Trackers;
                            // Получаем список приоритетов задачи
                            request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "enumerations/issue_priorities.json");
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                            request.Accept = "application/json";
                            response = (HttpWebResponse)request.GetResponse();
                            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            List<IssuePriority> issuePriorities = JsonConvert.DeserializeObject<IssuePrioritiesJSONObject>(jsonResponse).IssuePriorities;
                            // Получаем список участников проекта
                            List<Membership> memberships = new List<Membership>();
                            MembershipsJSONObject membershipsJSONObject = new MembershipsJSONObject();
                            int offset = 0;
                            do
                            {
                                request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "/projects/" + projectID + "/memberships.json?offset=" + offset);
                                request.Method = "GET";
                                request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                                request.Accept = "application/json";
                                response = (HttpWebResponse)request.GetResponse();
                                streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                                jsonResponse = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                membershipsJSONObject = JsonConvert.DeserializeObject<MembershipsJSONObject>(jsonResponse);
                                memberships.AddRange(membershipsJSONObject.Memberships);
                                offset += membershipsJSONObject.Limit;
                            } while (membershipsJSONObject.Memberships.FindIndex(temp => temp.Member.ID == Properties.Settings.Default.id) < 0 && membershipsJSONObject.Memberships.Count != 0);
                            if (OnPreparedToCreateNewIssue != null)
                                OnPreparedToCreateNewIssue(ErrorTypes.NoErrors, trackers, issuePriorities, memberships);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("401") && OnPreparedToCreateNewIssue != null)
                                OnPreparedToCreateNewIssue(ErrorTypes.UnathorizedAccess, null, null, null);
                        }
                    }
                    else if (OnPreparedToCreateNewIssue != null)
                        OnPreparedToCreateNewIssue(ErrorTypes.NoInternetConnection, null, null, null);
                }).Start();
        }

        /// <summary>
        /// Создание новой задачи.
        /// </summary>
        /// <param name="jsonRequest">Набор параметров в виде JSON для создаваемой задачи.</param>
        public void CreateIssue(string jsonRequest)
        {
            new Thread(
                delegate()
                {
                    if (Utils.IsNetworkAvailable())
                    {
                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues.json");
                            request.Method = "POST";
                            request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_key);
                            request.ContentType = "application/json";
                            StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
                            streamWriter.Write(jsonRequest);
                            streamWriter.Flush();
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            streamWriter.Close();
                            response.Close();
                            if (OnIssueCreated != null)
                                OnIssueCreated(ErrorTypes.NoErrors);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("401") && OnIssueCreated != null)
                                OnIssueCreated(ErrorTypes.UnathorizedAccess);
                        }
                    }
                    else if (OnIssueCreated != null)
                        OnIssueCreated(ErrorTypes.NoInternetConnection);
                }).Start();
        }

        /// <summary>
        /// Получение информации о проекте по его идентификатору.
        /// </summary>
        /// <param name="projectID">Идентификатор проекта.</param>
        /// <returns>Объект типа Project.</returns>
        public Project GetProject(long projectID)
        {
            try
            {
                return projects.Single(temp => temp.ID == projectID);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Получение информации о задаче по ее идентификатору.
        /// </summary>
        /// <param name="projectID">Идентификатор задачи.</param>
        /// <returns>Объект типа Issue.</returns>
        public Issue GetIssue(long issueID)
        {
            try
            {
                return issues.Single(temp => temp.ID == issueID);
            }
            catch
            {
                return null;
            }
        }
    }
}
