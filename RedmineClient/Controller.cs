using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    public enum ErrorTypes { NoErrors, ConnectionError, UnathorizedAccess, UnknownError }

    /// <summary>
    /// Класс, представляющий собой контроллер для взаимодействия с данными (реализация паттерна MVC).
    /// </summary>
    public class Controller
    {
        // URL-адрес Redmine сервера
        private string REDMINE_HOST = "http://student-rm.exactpro.com/";
        // api-ключ для текущего пользователя
        private string currentAPIKey;

        // Список проектов, в которых участвует текущий пользователь
        private List<Project> projects;
        // Список задач для выбранного проекта
        private List<Issue> issues;

        // Событие, возникающее при авторизации пользователя
        public event Action<ErrorTypes, bool> OnUserAuthenticated;
        // Событие, возникающее при необходимости открытия окна авторизации
        public event Action OnNeededToReAuthenticate;
        // Событие, возникающее после обновления списка проектов и задач, в которых участвует текущий пользователь
        public event Action<ErrorTypes, List<Project>> OnUpdated;
        // Событие, информирующее о готовности к созданию новой задачи
        public event Action<ErrorTypes, List<IssueTracker>, List<IssuePriority>, List<Membership>> OnPreparedToCreateNewIssue;
        // Событие, возникающее после загрузки списка участников указанного проекта
        public event Action<ErrorTypes, List<Membership>> OnMembershipsLoaded;
        // Событие, возникающее после создания новой задачи
        public event Action<ErrorTypes, long> OnIssueCreated;
        // Собитие, возникающее после загрузки информации о выбранном проекте
        public event Action<ErrorTypes, Project, List<Membership>> OnProjectInformationLoaded;
        // Событие, возникающее после загрузки информации о выбранной задаче
        public event Action<ErrorTypes, Issue, List<IssueTracker>, List<IssueStatus>, List<IssuePriority>, List<Membership>> OnIssueInformationLoaded;
        // Событие, возникающее после изменения информации о задаче
        public event Action<ErrorTypes, long> OnIssueUpdated;
        // Событие, возникающее после удаления задачи
        public event Action<ErrorTypes, long> OnIssueRemoved;

        public Controller()
        {
            if (Properties.Settings.Default.api_key.Length != 0)
                currentAPIKey = Utils.DecodeXOR(Properties.Settings.Default.api_key);
            else
                currentAPIKey = "";
        }

        /// <summary>
        /// Авторизация пользователя в системе по логину и паролю или api-ключу.
        /// </summary>
        /// <param name="isAuthBasic">Тип авторизации.</param>
        /// <param name="data">Подготовленная строка для Authorization Basic или api-ключ.</param>
        public void Authorize(bool isAuthBasic, string data)
        {
            new Thread(delegate()
                {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "users/current.json");
                        request.Method = "GET";
                        if (isAuthBasic)
                            request.Headers.Add("Authorization", "Basic " + data);
                        else
                            request.Headers.Add("X-Redmine-API-Key", data);
                        request.Accept = "application/json";
                        request.Timeout = 10000;
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        string jsonResponse = streamReader.ReadToEnd();
                        response.Close();
                        streamReader.Close();
                        User currentUser = JsonConvert.DeserializeObject<UserJSONObject>(jsonResponse).User;
                        if (Properties.Settings.Default.api_key.Length == 0 || currentUser.ID != Properties.Settings.Default.id)
                        {
                            Properties.Settings.Default.id = currentUser.ID;
                            Properties.Settings.Default.login = currentUser.Login;
                            Properties.Settings.Default.first_name = currentUser.FirstName;
                            Properties.Settings.Default.last_name = currentUser.LastName;
                            Properties.Settings.Default.email = currentUser.Email;
                            Properties.Settings.Default.created_on = currentUser.CreatedOn;
                            Properties.Settings.Default.api_key = Utils.EncodeXOR(currentUser.APIKey);
                            Properties.Settings.Default.Save();
                            currentAPIKey = currentUser.APIKey;
                            if (OnUserAuthenticated != null)
                                OnUserAuthenticated(ErrorTypes.NoErrors, true);
                        }
                        else
                        {
                            Properties.Settings.Default.first_name = currentUser.FirstName;
                            Properties.Settings.Default.last_name = currentUser.LastName;
                            Properties.Settings.Default.email = currentUser.Email;
                            Properties.Settings.Default.api_key = Utils.EncodeXOR(currentUser.APIKey);
                            Properties.Settings.Default.Save();
                            currentAPIKey = currentUser.APIKey;
                            if (OnUserAuthenticated != null)
                                OnUserAuthenticated(ErrorTypes.NoErrors, false);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (OnUserAuthenticated != null)
                        {
                            if (ex is WebException)
                                if (((WebException)ex).Status == WebExceptionStatus.Timeout || ((WebException)ex).Status == WebExceptionStatus.NameResolutionFailure)
                                    OnUserAuthenticated(ErrorTypes.ConnectionError, false);
                                else if (((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                                    OnUserAuthenticated(ErrorTypes.UnathorizedAccess, false);
                                else
                                    OnUserAuthenticated(ErrorTypes.UnknownError, false);
                            else if (ex is ArgumentException)
                                OnUserAuthenticated(ErrorTypes.UnathorizedAccess, false);
                            else
                                OnUserAuthenticated(ErrorTypes.UnknownError, false);
                        }
                    }
                }).Start();
        }

        /// <summary>
        /// Метод, оповещающий главную форму о необходимости открытия окна авторизации.
        /// </summary>
        public void NeedToReAuthenticate()
        {
            new Thread(
                delegate()
                {
                    Properties.Settings.Default.api_key = "";
                    Properties.Settings.Default.Save();
                    if (OnNeededToReAuthenticate != null)
                        OnNeededToReAuthenticate();
                }).Start();
        }

        /// <summary>
        /// Обновление списка проектов и задач для текущего пользователя.
        /// </summary>
        public void Update()
        {
            new Thread(
                delegate()
                {
                    try
                    {
                        HttpWebRequest request;
                        HttpWebResponse response;
                        StreamReader streamReader;
                        string jsonResponse;
                        // Загружаем список проектов
                        projects = new List<Project>();
                        ProjectsJSONObject projectsJSONObject = new ProjectsJSONObject();
                        int offset = 0;
                        do
                        {
                            request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "projects.json?offset=" + offset);
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                            request.Accept = "application/json";
                            request.Timeout = 10000;
                            response = (HttpWebResponse)request.GetResponse();
                            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            projectsJSONObject = JsonConvert.DeserializeObject<ProjectsJSONObject>(jsonResponse);
                            projects.AddRange(projectsJSONObject.Projects);
                            offset += projectsJSONObject.Limit;
                        } while (projectsJSONObject.Projects.Count != 0);
                        // Получаем также список участников каждого проекта для последующего вычисления ролей в них текущего пользователя
                        for (int i = 0; i < projects.Count; i++)
                        {
                            List<Membership> memberships = new List<Membership>();
                            MembershipsJSONObject membershipsJSONObject = new MembershipsJSONObject();
                            offset = 0;
                            do
                            {
                                request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "/projects/" + projects[i].ID + "/memberships.json?offset=" + offset);
                                request.Method = "GET";
                                request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                                request.Accept = "application/json";
                                request.Timeout = 10000;
                                response = (HttpWebResponse)request.GetResponse();
                                streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                                jsonResponse = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                membershipsJSONObject = JsonConvert.DeserializeObject<MembershipsJSONObject>(jsonResponse);
                                memberships.AddRange(membershipsJSONObject.Memberships);
                                offset += membershipsJSONObject.Limit;
                            } while (membershipsJSONObject.Memberships.FindIndex(temp => temp.User.ID == Properties.Settings.Default.id) < 0 && membershipsJSONObject.Memberships.Count != 0);
                            Membership membership = null;
                            foreach (Membership currentMembership in memberships)
                                if (currentMembership.User.ID == Properties.Settings.Default.id)
                                {
                                    membership = currentMembership;
                                    break;
                                }
                            if (membership != null)
                            {
                                string projectRoles = "";
                                foreach (Role role in membership.Roles)
                                    projectRoles += role.Name + ", ";
                                projects[i].Roles = projectRoles.Remove(projectRoles.Length - 2);
                            }
                            else
                            {
                                projects.RemoveAt(i);
                                i--;
                            }
                        }
                        // Загружаем список задач
                        issues = new List<Issue>();
                        IssuesJSONObject issuesJSONObject = new IssuesJSONObject();
                        offset = 0;
                        do
                        {
                            request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues.json?offset=" + offset);
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                            request.Accept = "application/json";
                            request.Timeout = 10000;
                            response = (HttpWebResponse)request.GetResponse();
                            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            issuesJSONObject = JsonConvert.DeserializeObject<IssuesJSONObject>(jsonResponse);
                            issues.AddRange(issuesJSONObject.Issues);
                            offset += issuesJSONObject.Limit;
                        } while (issuesJSONObject.Issues.Count != 0);
                        issues.RemoveAll(temp1 => projects.FindIndex(temp2 => temp2.ID == temp1.Project.ID) < 0);
                        if (OnUpdated != null)
                            OnUpdated(ErrorTypes.NoErrors, projects);
                    }
                    catch (Exception ex)
                    {
                        if (OnUpdated != null)
                        {
                            if (ex is WebException)
                                if (((WebException)ex).Status == WebExceptionStatus.Timeout || ((WebException)ex).Status == WebExceptionStatus.NameResolutionFailure)
                                    OnUpdated(ErrorTypes.ConnectionError, null);
                                else if (((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                                    OnUpdated(ErrorTypes.UnathorizedAccess, null);
                                else
                                    OnUpdated(ErrorTypes.UnknownError, null);
                            else if (ex is ArgumentException)
                                OnUpdated(ErrorTypes.UnathorizedAccess, null);
                            else
                                OnUpdated(ErrorTypes.UnknownError, null);
                        }
                    }
                }).Start();
        }

        /// <summary>
        /// Получение списка всех проектов, в которых зарегистрирован текущий пользователь.
        /// </summary>
        /// <returns>Список проектов.</returns>
        public List<Project> GetProjects()
        {
            List<Project> tempProjects = new List<Project>();
            tempProjects.AddRange(projects);
            return tempProjects;
        }

        /// <summary>
        /// Получение списка задач для выбранного проекта.
        /// </summary>
        /// <param name="projectID">Идентификатор проекта.</param>
        /// <returns>Список задач.</returns>
        public List<Issue> GetIssues(long projectID)
        {
            List<Issue> tempIssues = new List<Issue>();
            tempIssues.AddRange(issues);
            tempIssues.RemoveAll(temp => temp.Project.ID != projectID);
            return tempIssues;
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
                    try
                    {
                        HttpWebRequest request;
                        HttpWebResponse response;
                        StreamReader streamReader;
                        string jsonResponse;
                        // Получаем список трекеров (типов задачи)
                        request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "trackers.json");
                        request.Method = "GET";
                        request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                        request.Accept = "application/json";
                        request.Timeout = 10000;
                        response = (HttpWebResponse)request.GetResponse();
                        streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        jsonResponse = streamReader.ReadToEnd();
                        response.Close();
                        streamReader.Close();
                        List<IssueTracker> issueTrackers = JsonConvert.DeserializeObject<IssueTrackersJSONObject>(jsonResponse).IssueTrackers;
                        // Получаем список приоритетов задачи
                        request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "enumerations/issue_priorities.json");
                        request.Method = "GET";
                        request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                        request.Accept = "application/json";
                        request.Timeout = 10000;
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
                            request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                            request.Accept = "application/json";
                            request.Timeout = 10000;
                            response = (HttpWebResponse)request.GetResponse();
                            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            membershipsJSONObject = JsonConvert.DeserializeObject<MembershipsJSONObject>(jsonResponse);
                            memberships.AddRange(membershipsJSONObject.Memberships);
                            offset += membershipsJSONObject.Limit;
                        } while (membershipsJSONObject.Memberships.Count != 0);
                        memberships.RemoveAll(temp => temp.User == null);
                        if (OnPreparedToCreateNewIssue != null)
                            OnPreparedToCreateNewIssue(ErrorTypes.NoErrors, issueTrackers, issuePriorities, memberships);
                    }
                    catch (Exception ex)
                    {
                        if (OnPreparedToCreateNewIssue != null)
                        {
                            if (ex is WebException)
                                if (((WebException)ex).Status == WebExceptionStatus.Timeout || ((WebException)ex).Status == WebExceptionStatus.NameResolutionFailure)
                                    OnPreparedToCreateNewIssue(ErrorTypes.ConnectionError, null, null, null);
                                else if (((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                                    OnPreparedToCreateNewIssue(ErrorTypes.UnathorizedAccess, null, null, null);
                                else
                                    OnPreparedToCreateNewIssue(ErrorTypes.UnknownError, null, null, null);
                            else if (ex is ArgumentException)
                                OnPreparedToCreateNewIssue(ErrorTypes.UnathorizedAccess, null, null, null);
                            else
                                OnPreparedToCreateNewIssue(ErrorTypes.UnknownError, null, null, null);
                        }
                    }
                }).Start();
        }

        /// <summary>
        /// Получение списка участников для указанного проекта.
        /// </summary>
        /// <param name="projectID">Идентификатор проекта.</param>
        public void LoadMemberships(long projectID)
        {
            new Thread(
                delegate()
                {
                    try
                    {
                        List<Membership> memberships = new List<Membership>();
                        MembershipsJSONObject membershipsJSONObject = new MembershipsJSONObject();
                        int offset = 0;
                        do
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "/projects/" + projectID + "/memberships.json?offset=" + offset);
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                            request.Accept = "application/json";
                            request.Timeout = 10000;
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            string jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            membershipsJSONObject = JsonConvert.DeserializeObject<MembershipsJSONObject>(jsonResponse);
                            memberships.AddRange(membershipsJSONObject.Memberships);
                            offset += membershipsJSONObject.Limit;
                        } while (membershipsJSONObject.Memberships.Count != 0);
                        memberships.RemoveAll(temp => temp.User == null);
                        if (OnMembershipsLoaded != null)
                            OnMembershipsLoaded(ErrorTypes.NoErrors, memberships);
                    }
                    catch (Exception ex)
                    {
                        if (OnMembershipsLoaded != null)
                        {
                            if (ex is WebException)
                                if (((WebException)ex).Status == WebExceptionStatus.Timeout || ((WebException)ex).Status == WebExceptionStatus.NameResolutionFailure)
                                    OnMembershipsLoaded(ErrorTypes.ConnectionError, null);
                                else if (((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                                    OnMembershipsLoaded(ErrorTypes.UnathorizedAccess, null);
                                else
                                    OnMembershipsLoaded(ErrorTypes.UnknownError, null);
                            else if (ex is ArgumentException)
                                OnMembershipsLoaded(ErrorTypes.UnathorizedAccess, null);
                            else
                                OnMembershipsLoaded(ErrorTypes.UnknownError, null);
                        }
                    }
                }).Start();
        }

        /// <summary>
        /// Создание новой задачи.
        /// </summary>
        /// <param name="newIssue">Новая задача.</param>
        public void CreateIssue(NewIssue newIssue)
        {
            new Thread(
                delegate()
                {
                    try
                    {
                        HttpWebRequest request;
                        HttpWebResponse response;
                        StreamReader streamReader;
                        string jsonResponse;
                        request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues.json");
                        request.Method = "POST";
                        request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                        request.ContentType = "application/json";
                        request.Timeout = 10000;
                        StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
                        streamWriter.Write(JsonConvert.SerializeObject(new NewIssueJSONObject() { NewIssue = newIssue }, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore }));
                        streamWriter.Flush();
                        response = (HttpWebResponse)request.GetResponse();
                        streamWriter.Close();
                        response.Close();
                        // Здесь же обновляем список задач для текущего пользователя
                        issues = new List<Issue>();
                        IssuesJSONObject issuesJSONObject = new IssuesJSONObject();
                        int offset = 0;
                        do
                        {
                            request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues.json?offset=" + offset);
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                            request.Accept = "application/json";
                            request.Timeout = 10000;
                            response = (HttpWebResponse)request.GetResponse();
                            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            issuesJSONObject = JsonConvert.DeserializeObject<IssuesJSONObject>(jsonResponse);
                            issues.AddRange(issuesJSONObject.Issues);
                            offset += issuesJSONObject.Limit;
                        } while (issuesJSONObject.Issues.Count != 0);
                        issues.RemoveAll(temp1 => projects.FindIndex(temp2 => temp2.ID == temp1.Project.ID) < 0);
                        if (OnIssueCreated != null)
                            OnIssueCreated(ErrorTypes.NoErrors, newIssue.ProjectID);
                    }
                    catch (Exception ex)
                    {
                        if (OnIssueCreated != null)
                        {
                            if (ex is WebException)
                                if (((WebException)ex).Status == WebExceptionStatus.Timeout || ((WebException)ex).Status == WebExceptionStatus.NameResolutionFailure)
                                    OnIssueCreated(ErrorTypes.ConnectionError, newIssue.ProjectID);
                                else if (((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                                    OnIssueCreated(ErrorTypes.UnathorizedAccess, newIssue.ProjectID);
                                else
                                    OnIssueCreated(ErrorTypes.UnknownError, newIssue.ProjectID);
                            else if (ex is ArgumentException)
                                OnIssueCreated(ErrorTypes.UnathorizedAccess, newIssue.ProjectID);
                            else
                                OnIssueCreated(ErrorTypes.UnknownError, newIssue.ProjectID);
                        }
                    }
                }).Start();
        }

        /// <summary>
        /// Получение полной информации об определенном проекте.
        /// </summary>
        /// <param name="projectID">Идентификатор проекта.</param>
        public void LoadProjectInformation(long projectID)
        {
            new Thread(
                delegate()
                {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "projects/" + projectID + ".json");
                        request.Method = "GET";
                        request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                        request.Accept = "application/json";
                        request.Timeout = 10000;
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        string jsonResponse = streamReader.ReadToEnd();
                        response.Close();
                        streamReader.Close();
                        Project project = JsonConvert.DeserializeObject<ProjectJSONObject>(jsonResponse).Project;
                        // Получаем также список участников проекта
                        List<Membership> memberships = new List<Membership>();
                        MembershipsJSONObject membershipsJSONObject = new MembershipsJSONObject();
                        int offset = 0;
                        do
                        {
                            request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "/projects/" + projectID + "/memberships.json?offset=" + offset);
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                            request.Accept = "application/json";
                            request.Timeout = 10000;
                            response = (HttpWebResponse)request.GetResponse();
                            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            membershipsJSONObject = JsonConvert.DeserializeObject<MembershipsJSONObject>(jsonResponse);
                            memberships.AddRange(membershipsJSONObject.Memberships);
                            offset += membershipsJSONObject.Limit;
                        } while (membershipsJSONObject.Memberships.Count != 0);
                        memberships.RemoveAll(temp => temp.User == null);
                        if (OnProjectInformationLoaded != null)
                            OnProjectInformationLoaded(ErrorTypes.NoErrors, project, memberships);
                    }
                    catch (WebException webException)
                    {
                        if (OnProjectInformationLoaded != null)
                            if (webException.Status == WebExceptionStatus.Timeout || webException.Status == WebExceptionStatus.NameResolutionFailure)
                                OnProjectInformationLoaded(ErrorTypes.ConnectionError, null, null);
                            else if (webException.Status == WebExceptionStatus.ProtocolError)
                                OnProjectInformationLoaded(ErrorTypes.UnathorizedAccess, null, null);
                            else
                                OnProjectInformationLoaded(ErrorTypes.UnknownError, null, null);
                    }
                    catch (ArgumentException)
                    {
                        if (OnProjectInformationLoaded != null)
                            OnProjectInformationLoaded(ErrorTypes.UnathorizedAccess, null, null);
                    }
                    catch
                    {
                        if (OnProjectInformationLoaded != null)
                            OnProjectInformationLoaded(ErrorTypes.UnknownError, null, null);
                    }
                }).Start();
        }

        /// <summary>
        /// Получение полной информации об определенной задаче.
        /// </summary>
        /// <param name="issueID">Идентификатор задачи.</param>
        public void LoadIssueInformation(long issueID)
        {
            new Thread(
                delegate()
                {
                    try
                    {
                        HttpWebRequest request;
                        HttpWebResponse response;
                        StreamReader streamReader;
                        string jsonResponse;
                        // Получаем полную информацию о задаче (включая историю ее изменения)
                        request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues/" + issueID + ".json?include=journals");
                        request.Method = "GET";
                        request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                        request.Accept = "application/json";
                        request.Timeout = 10000;
                        response = (HttpWebResponse)request.GetResponse();
                        streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        jsonResponse = streamReader.ReadToEnd();
                        response.Close();
                        streamReader.Close();
                        Issue issue = JsonConvert.DeserializeObject<IssueJSONObject>(jsonResponse).Issue;
                        // Получаем список всевозможных типов задачи
                        request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "trackers.json");
                        request.Method = "GET";
                        request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                        request.Accept = "application/json";
                        request.Timeout = 10000;
                        response = (HttpWebResponse)request.GetResponse();
                        streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        jsonResponse = streamReader.ReadToEnd();
                        response.Close();
                        streamReader.Close();
                        List<IssueTracker> issueTrackers = JsonConvert.DeserializeObject<IssueTrackersJSONObject>(jsonResponse).IssueTrackers;
                        // Получаем список возможных приоритетов задачи
                        request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "enumerations/issue_priorities.json");
                        request.Method = "GET";
                        request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                        request.Accept = "application/json";
                        request.Timeout = 10000;
                        response = (HttpWebResponse)request.GetResponse();
                        streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        jsonResponse = streamReader.ReadToEnd();
                        response.Close();
                        streamReader.Close();
                        List<IssuePriority> issuePriorities = JsonConvert.DeserializeObject<IssuePrioritiesJSONObject>(jsonResponse).IssuePriorities;
                        // Получаем список возможных статусов задачи
                        request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issue_statuses.json");
                        request.Method = "GET";
                        request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                        request.Accept = "application/json";
                        request.Timeout = 10000;
                        response = (HttpWebResponse)request.GetResponse();
                        streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        jsonResponse = streamReader.ReadToEnd();
                        response.Close();
                        streamReader.Close();
                        List<IssueStatus> issueStatuses = JsonConvert.DeserializeObject<IssueStatusesJSONObject>(jsonResponse).IssueStatuses;
                        // Получаем список всех участников проекта
                        List<Membership> memberships = new List<Membership>();
                        MembershipsJSONObject membershipsJSONObject = new MembershipsJSONObject();
                        int offset = 0;
                        do
                        {
                            request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "/projects/" + issue.Project.ID + "/memberships.json?offset=" + offset);
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                            request.Accept = "application/json";
                            request.Timeout = 10000;
                            response = (HttpWebResponse)request.GetResponse();
                            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            membershipsJSONObject = JsonConvert.DeserializeObject<MembershipsJSONObject>(jsonResponse);
                            memberships.AddRange(membershipsJSONObject.Memberships);
                            offset += membershipsJSONObject.Limit;
                        } while (membershipsJSONObject.Memberships.Count != 0);
                        memberships.RemoveAll(temp => temp.User == null);
                        if (OnIssueInformationLoaded != null)
                            OnIssueInformationLoaded(ErrorTypes.NoErrors, issue, issueTrackers, issueStatuses, issuePriorities, memberships);
                    }
                    catch (Exception ex)
                    {
                        if (OnIssueInformationLoaded != null)
                        {
                            if (ex is WebException)
                                if (((WebException)ex).Status == WebExceptionStatus.Timeout || ((WebException)ex).Status == WebExceptionStatus.NameResolutionFailure)
                                    OnIssueInformationLoaded(ErrorTypes.ConnectionError, null, null, null, null, null);
                                else if (((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                                    OnIssueInformationLoaded(ErrorTypes.UnathorizedAccess, null, null, null, null, null);
                                else
                                    OnIssueInformationLoaded(ErrorTypes.UnknownError, null, null, null, null, null);
                            else if (ex is ArgumentException)
                                OnIssueInformationLoaded(ErrorTypes.UnathorizedAccess, null, null, null, null, null);
                            else
                                OnIssueInformationLoaded(ErrorTypes.UnknownError, null, null, null, null, null);
                        }
                    }
                }).Start();
        }

        /// <summary>
        /// Обновление информации о задаче.
        /// </summary>
        /// <param name="issueID">Идентификатор задачи.</param>
        /// <param name="jsonRequest">Набор параметров в виде JSON для изменяемой задачи.</param>
        public void UpdateIssue(long issueID, NewIssue updatedIssue)
        {
            new Thread(
                delegate()
                {
                    try
                    {
                        HttpWebRequest request;
                        HttpWebResponse response;
                        StreamReader streamReader;
                        string jsonResponse;
                        request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues/" + issueID + ".json");
                        request.Method = "PUT";
                        request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                        request.ContentType = "application/json";
                        request.Timeout = 10000;
                        StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
                        streamWriter.Write(JsonConvert.SerializeObject(new NewIssueJSONObject { NewIssue = updatedIssue }, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore }));
                        streamWriter.Flush();
                        response = (HttpWebResponse)request.GetResponse();
                        streamWriter.Close();
                        response.Close();
                        // Здесь же обновляем список задач для текущего пользователя
                        issues = new List<Issue>();
                        IssuesJSONObject issuesJSONObject = new IssuesJSONObject();
                        int offset = 0;
                        do
                        {
                            request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues.json?offset=" + offset);
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                            request.Accept = "application/json";
                            request.Timeout = 10000;
                            response = (HttpWebResponse)request.GetResponse();
                            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            jsonResponse = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            issuesJSONObject = JsonConvert.DeserializeObject<IssuesJSONObject>(jsonResponse);
                            issues.AddRange(issuesJSONObject.Issues);
                            offset += issuesJSONObject.Limit;
                        } while (issuesJSONObject.Issues.Count != 0);
                        issues.RemoveAll(temp1 => projects.FindIndex(temp2 => temp2.ID == temp1.Project.ID) < 0);
                        if (OnIssueUpdated != null)
                            OnIssueUpdated(ErrorTypes.NoErrors, updatedIssue.ProjectID);
                    }
                    catch (Exception ex)
                    {
                        if (OnIssueUpdated != null)
                        {
                            if (ex is WebException)
                                if (((WebException)ex).Status == WebExceptionStatus.Timeout || ((WebException)ex).Status == WebExceptionStatus.NameResolutionFailure)
                                    OnIssueUpdated(ErrorTypes.ConnectionError, updatedIssue.ProjectID);
                                else if (((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                                    OnIssueUpdated(ErrorTypes.UnathorizedAccess, updatedIssue.ProjectID);
                                else
                                    OnIssueUpdated(ErrorTypes.UnknownError, updatedIssue.ProjectID);
                            else if (ex is ArgumentException)
                                OnIssueUpdated(ErrorTypes.UnathorizedAccess, updatedIssue.ProjectID);
                            else
                                OnIssueUpdated(ErrorTypes.UnknownError, updatedIssue.ProjectID);
                        }
                    }
                }).Start();
        }

        /// <summary>
        /// Удаление задачи по ее идентификатору.
        /// </summary>
        /// <param name="issueID">Идентификатор задачи.</param>
        public void RemoveIssue(long issueID)
        {
            new Thread(
                delegate()
                {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues/" + issueID + ".json");
                        request.Method = "DELETE";
                        request.Headers.Add("X-Redmine-API-Key", currentAPIKey);
                        request.Accept = "application/json";
                        request.Timeout = 10000;
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        issues.RemoveAt(issues.FindIndex(temp => temp.ID == issueID));
                        if (OnIssueRemoved != null)
                            OnIssueRemoved(ErrorTypes.NoErrors, issueID);
                    }
                    catch (Exception ex)
                    {
                        if (OnIssueRemoved != null)
                        {
                            if (ex is WebException)
                                if (((WebException)ex).Status == WebExceptionStatus.Timeout || ((WebException)ex).Status == WebExceptionStatus.NameResolutionFailure)
                                    OnIssueRemoved(ErrorTypes.ConnectionError, issueID);
                                else if (((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                                    OnIssueRemoved(ErrorTypes.UnathorizedAccess, issueID);
                                else
                                    OnIssueRemoved(ErrorTypes.UnknownError, issueID);
                            else if (ex is ArgumentException)
                                OnIssueRemoved(ErrorTypes.UnathorizedAccess, issueID);
                            else
                                OnIssueRemoved(ErrorTypes.UnknownError, issueID);
                        }
                    }
                }).Start();
        }
    }
}
