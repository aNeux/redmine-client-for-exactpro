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
        private string REDMINE_HOST;
        // api-ключ для текущего пользователя
        private string currentAPIKey;

        // Список проектов, в которых участвует текущий пользователь
        private List<Project> projects;
        // Список задач для выбранного проекта
        private List<Issue> issues;
        // Таймер для переодических фоновых обновлений
        private System.Timers.Timer timer;

        // Событие, возникающее при авторизации пользователя
        public event Action<ErrorTypes, bool> OnUserAuthenticated;
        // Событие, возникающее при необходимости открытия окна авторизации
        public event Action<bool> OnNeededToReAuthenticate;
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
        // Событие, возникающее после проверки новых настроек и их применения
        public event Action<ErrorTypes, bool[]> OnOptionsApplied;
        // Событие, возникающее после фонового обновления
        public event Action<ErrorTypes, List<Project>, string> OnBackgroundUpdated;

        public Controller()
        {
            REDMINE_HOST = Properties.Application.Default.redmine_host;
            if (Properties.User.Default.api_key.Length != 0)
                currentAPIKey = Properties.Application.Default.encryption_enabled ? Utils.DecodeXOR(Properties.User.Default.api_key) : Properties.User.Default.api_key;
            else
                currentAPIKey = "";
        }

        /// <summary>
        /// Авторизация пользователя в системе по логину и паролю или api-ключу.
        /// </summary>
        /// <param name="isAuthBasic">Тип авторизации.</param>
        /// <param name="data">Подготовленная строка для Authorization Basic или api-ключ.</param>
        public void Authorize(string newRedmineHost, bool isAuthBasic, string data)
        {
            new Thread(delegate()
                {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newRedmineHost + "users/current.json");
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
                        if (newRedmineHost != Properties.Application.Default.redmine_host)
                        {
                            REDMINE_HOST = newRedmineHost;
                            Properties.Application.Default.redmine_host = newRedmineHost;
                            Properties.Application.Default.Save();
                        }
                        User currentUser = JsonConvert.DeserializeObject<UserJSONObject>(jsonResponse).User;
                        if (Properties.User.Default.api_key.Length == 0 || currentUser.ID != Properties.User.Default.id)
                        {
                            Properties.User.Default.id = currentUser.ID;
                            Properties.User.Default.login = currentUser.Login;
                            Properties.User.Default.first_name = currentUser.FirstName;
                            Properties.User.Default.last_name = currentUser.LastName;
                            Properties.User.Default.email = currentUser.Email;
                            Properties.User.Default.created_on = currentUser.CreatedOn;
                            Properties.User.Default.api_key = Properties.Application.Default.encryption_enabled ? Utils.EncodeXOR(currentUser.APIKey) : currentUser.APIKey;
                            Properties.User.Default.Save();
                            currentAPIKey = currentUser.APIKey;
                            if (OnUserAuthenticated != null)
                                OnUserAuthenticated(ErrorTypes.NoErrors, true);
                        }
                        else
                        {
                            Properties.User.Default.first_name = currentUser.FirstName;
                            Properties.User.Default.last_name = currentUser.LastName;
                            Properties.User.Default.email = currentUser.Email;
                            Properties.User.Default.api_key = Utils.EncodeXOR(currentUser.APIKey);
                            Properties.User.Default.Save();
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
                            {
                                WebException webException = (WebException)ex;
                                if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                                    OnUserAuthenticated(ErrorTypes.UnathorizedAccess, false);
                                else
                                    OnUserAuthenticated(ErrorTypes.ConnectionError, false);
                            }
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
        /// <param name="isFromOptions">Вызван ли этот метод из настроек программы.</param>
        public void NeedToReAuthenticate(bool isFromOptions)
        {
            new Thread(
                delegate()
                {
                    Properties.User.Default.Reset();
                    if (OnNeededToReAuthenticate != null)
                        OnNeededToReAuthenticate(isFromOptions);
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
                            } while (membershipsJSONObject.Memberships.FindIndex(temp => temp.User.ID == Properties.User.Default.id) < 0 && membershipsJSONObject.Memberships.Count != 0);
                            Membership membership = null;
                            foreach (Membership currentMembership in memberships)
                                if (currentMembership.User.ID == Properties.User.Default.id)
                                {
                                    membership = currentMembership;
                                    break;
                                }
                            if (membership != null)
                                projects[i].Roles = membership.Roles;
                            else
                            {
                                List<Role> noRoles = new List<Role>();
                                noRoles.Add(new Role { ID = -1, Name = "< none >" });
                                projects[i].Roles = noRoles;
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
                        if (OnUpdated != null)
                            OnUpdated(ErrorTypes.NoErrors, projects);
                    }
                    catch (Exception ex)
                    {
                        if (OnUpdated != null)
                        {
                            if (ex is WebException)
                            {
                                WebException webException = (WebException)ex;
                                if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                                    OnUpdated(ErrorTypes.UnathorizedAccess, null);
                                else
                                    OnUpdated(ErrorTypes.ConnectionError, null);
                            }
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
                            {
                                WebException webException = (WebException)ex;
                                if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                                    OnPreparedToCreateNewIssue(ErrorTypes.UnathorizedAccess, null, null, null);
                                else
                                    OnPreparedToCreateNewIssue(ErrorTypes.ConnectionError, null, null, null);
                            }
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
                            {
                                WebException webException = (WebException)ex;
                                if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                                    OnMembershipsLoaded(ErrorTypes.UnathorizedAccess, null);
                                else
                                    OnMembershipsLoaded(ErrorTypes.ConnectionError, null);
                            }
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
                            {
                                WebException webException = (WebException)ex;
                                if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                                    OnIssueCreated(ErrorTypes.UnathorizedAccess, newIssue.ProjectID);
                                else
                                    OnIssueCreated(ErrorTypes.ConnectionError, newIssue.ProjectID);
                            }
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
                    catch (Exception ex)
                    {
                        if (OnProjectInformationLoaded != null)
                        {
                            if (ex is WebException)
                            {
                                WebException webException = (WebException)ex;
                                if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                                    OnProjectInformationLoaded(ErrorTypes.UnathorizedAccess, null, null);
                                else
                                    OnProjectInformationLoaded(ErrorTypes.ConnectionError, null, null);
                            }
                            else if (ex is ArgumentException)
                                OnProjectInformationLoaded(ErrorTypes.UnathorizedAccess, null, null);
                            else
                                OnProjectInformationLoaded(ErrorTypes.UnknownError, null, null);
                        }
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
                            {
                                WebException webException = (WebException)ex;
                                if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                                    OnIssueInformationLoaded(ErrorTypes.UnathorizedAccess, null, null, null, null, null);
                                else
                                    OnIssueInformationLoaded(ErrorTypes.ConnectionError, null, null, null, null, null);
                            }
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
                            {
                                WebException webException = (WebException)ex;
                                if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                                    OnIssueUpdated(ErrorTypes.UnathorizedAccess, updatedIssue.ProjectID);
                                else
                                    OnIssueUpdated(ErrorTypes.ConnectionError, updatedIssue.ProjectID);
                            }
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
                            {
                                WebException webException = (WebException)ex;
                                if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                                    OnIssueRemoved(ErrorTypes.UnathorizedAccess, issueID);
                                else
                                    OnIssueRemoved(ErrorTypes.ConnectionError, issueID);
                            }
                            else if (ex is ArgumentException)
                                OnIssueRemoved(ErrorTypes.UnathorizedAccess, issueID);
                            else
                                OnIssueRemoved(ErrorTypes.UnknownError, issueID);
                        }
                    }
                }).Start();
        }

        /// <summary>
        /// Применение новых настроек программы, если это возможно.
        /// </summary>
        /// <param name="newOptions">Новые настройки программы.</param>
        public void ApplyNewOptions(ApplicationOptions newOptions)
        {
            new Thread(
                delegate()
                {
                    Properties.Application.Default.ask_before_exiting = newOptions.AskBeforeExiting;
                    Properties.Application.Default.minimaze_to_tray = newOptions.MinimazeToTray;
                    bool isShowAccountLoginChanged = false, isShowStatusBarChanged = false, isRedmineHostChanged = false, isShowClosedProjectsChanged = false, isShowProjectsWithoutCurrentUserChanged = false;
                    if (Properties.Application.Default.show_status_bar != newOptions.ShowAccountLogin)
                    {
                        isShowAccountLoginChanged = true;
                        Properties.Application.Default.show_status_bar = newOptions.ShowAccountLogin;
                    }
                    if (Properties.Application.Default.show_account_login != newOptions.ShowStatusBar)
                    {
                        isShowStatusBarChanged = true;
                        Properties.Application.Default.show_account_login = newOptions.ShowStatusBar;
                    }
                    if (Properties.Application.Default.encryption_enabled != newOptions.EnableEncryption)
                    {
                        if (newOptions.EnableEncryption)
                            Properties.User.Default.api_key = Utils.EncodeXOR(currentAPIKey);
                        else
                            Properties.User.Default.api_key = currentAPIKey;
                        Properties.Application.Default.encryption_enabled = newOptions.EnableEncryption;
                    }
                    Properties.Application.Default.background_updater_enabled = newOptions.EnableBackgroundUpdater;
                    Properties.Application.Default.background_updater_interval = newOptions.BackgroundUpdaterInterval;
                    Properties.Application.Default.background_updater_notify_about_projects = newOptions.BackgroundUpdaterNotifyAboutProjects;
                    Properties.Application.Default.background_updater_notify_about_issues = newOptions.BackgroundUpdaterNotifyAboutIssues;
                    Properties.Application.Default.background_updater_play_notification_sound = newOptions.BackgroundUpdaterPlayNotificationSound;
                    if (Properties.Application.Default.show_closed_projects != newOptions.ShowClosedProjects)
                    {
                        isShowClosedProjectsChanged = true;
                        Properties.Application.Default.show_closed_projects = newOptions.ShowClosedProjects;
                    }
                    if (Properties.Application.Default.show_projects_without_current_user != newOptions.ShowProjectsWithoutCurrentUser)
                    {
                        isShowProjectsWithoutCurrentUserChanged = true;
                        Properties.Application.Default.show_projects_without_current_user = newOptions.ShowProjectsWithoutCurrentUser;
                    }
                    if (Properties.Application.Default.redmine_host != newOptions.RedmineHost)
                    {
                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newOptions.RedmineHost + "projects.json");
                            request.Method = "GET";
                            request.Accept = "application/json";
                            request.Timeout = 10000;
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            REDMINE_HOST = newOptions.RedmineHost;
                            Properties.Application.Default.redmine_host = newOptions.RedmineHost;
                            isRedmineHostChanged = true;
                            Properties.Application.Default.Save();
                            Properties.User.Default.Reset();
                            if (OnOptionsApplied != null)
                                OnOptionsApplied(ErrorTypes.NoErrors, new bool[] { isShowAccountLoginChanged, isShowStatusBarChanged, isRedmineHostChanged, isShowClosedProjectsChanged, isShowProjectsWithoutCurrentUserChanged });
                            if (isRedmineHostChanged && OnNeededToReAuthenticate != null)
                                OnNeededToReAuthenticate(true);
                        }
                        catch (Exception ex)
                        {
                            if (OnOptionsApplied != null)
                            {
                                if (ex is WebException)
                                {
                                    WebException webException = (WebException)ex;
                                    if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                                    {
                                        REDMINE_HOST = newOptions.RedmineHost;
                                        Properties.Application.Default.redmine_host = newOptions.RedmineHost;
                                        isRedmineHostChanged = true;
                                        Properties.Application.Default.Save();
                                        Properties.User.Default.Reset();
                                        if (OnOptionsApplied != null)
                                            OnOptionsApplied(ErrorTypes.NoErrors, new bool[] { isShowAccountLoginChanged, isShowStatusBarChanged, isRedmineHostChanged, isShowClosedProjectsChanged, isShowProjectsWithoutCurrentUserChanged });
                                        if (isRedmineHostChanged && OnNeededToReAuthenticate != null)
                                            OnNeededToReAuthenticate(true);
                                    }
                                    else
                                        OnOptionsApplied(ErrorTypes.ConnectionError, null);
                                }
                                else
                                    OnOptionsApplied(ErrorTypes.UnknownError, null);
                            }
                        }
                    }
                    else
                    {
                        Properties.Application.Default.Save();
                        Properties.User.Default.Save();
                        if (OnOptionsApplied != null)
                            OnOptionsApplied(ErrorTypes.NoErrors, new bool[] { isShowAccountLoginChanged, isShowStatusBarChanged, isRedmineHostChanged, isShowClosedProjectsChanged, isShowProjectsWithoutCurrentUserChanged });
                    }
                }).Start();
        }

        /// <summary>
        /// Запуск таймера для переодических фоновых обновлений.
        /// </summary>
        /// <param name="executeImmediately">Выполнить метод обновления сразу же или по истечении необходимого интервала времени.</param>
        public void StartBackgroundUpdater(bool executeImmediately)
        {
            timer = new System.Timers.Timer();
            timer.Interval = executeImmediately ? 1 : Properties.Application.Default.background_updater_interval;
            timer.Elapsed += BackgroundUpdate;
            timer.AutoReset = false;
            timer.Start();
        }

        /// <summary>
        /// Остановка таймера переодических фоновых обновлений.
        /// </summary>
        public void StopBackgroundUpdater()
        {
            if (timer != null && timer.Enabled)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }

        /// <summary>
        /// Запущен ли таймер фонового обновления.
        /// </summary>
        /// <returns></returns>
        public bool IsBackgroundUpdaterWorking()
        {
            return timer != null ? timer.Enabled : false;
        }

        /// <summary>
        /// Обновление информации о проектах и задачах в фоновом режиме.
        /// </summary>
        private void BackgroundUpdate(object sender, EventArgs e)
        {
            StopBackgroundUpdater();
            try
            {
                HttpWebRequest request;
                HttpWebResponse response;
                StreamReader streamReader;
                string jsonResponse;
                // Загружаем список проектов
                string resultInfoForProjects = "";
                List<Project> newProjects = new List<Project>();
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
                    newProjects.AddRange(projectsJSONObject.Projects);
                    offset += projectsJSONObject.Limit;
                } while (projectsJSONObject.Projects.Count != 0);
                // Определяем роли пользователя в каждом проекте
                for (int i = 0; i < newProjects.Count; i++)
                {
                    List<Membership> memberships = new List<Membership>();
                    MembershipsJSONObject membershipsJSONObject = new MembershipsJSONObject();
                    offset = 0;
                    do
                    {
                        request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "/projects/" + newProjects[i].ID + "/memberships.json?offset=" + offset);
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
                    } while (membershipsJSONObject.Memberships.FindIndex(temp => temp.User.ID == Properties.User.Default.id) < 0 && membershipsJSONObject.Memberships.Count != 0);
                    Membership membership = null;
                    foreach (Membership currentMembership in memberships)
                        if (currentMembership.User.ID == Properties.User.Default.id)
                        {
                            membership = currentMembership;
                            break;
                        }
                    if (membership != null)
                        newProjects[i].Roles = membership.Roles;
                    else
                    {
                        List<Role> noRoles = new List<Role>();
                        noRoles.Add(new Role { ID = -1, Name = "< none >" });
                        newProjects[i].Roles = noRoles;
                    }
                }
                // Находим изменения в проектах, если это необходимо
                if (Properties.Application.Default.background_updater_notify_about_projects)
                {
                    foreach (Project currentNewProject in newProjects)
                    {
                        int sameProjectIndex = projects.FindIndex(temp => temp.ID == currentNewProject.ID);
                        if (Properties.Application.Default.show_closed_projects || (!Properties.Application.Default.show_closed_projects && currentNewProject.Status != 5))
                            if (Properties.Application.Default.show_projects_without_current_user || (!Properties.Application.Default.show_projects_without_current_user && currentNewProject.Roles[0].ID != -1))
                                if (sameProjectIndex >= 0)
                                {
                                    if (currentNewProject.UpdatedOn > projects[sameProjectIndex].UpdatedOn)
                                    {
                                        if (currentNewProject.Name != projects[sameProjectIndex].Name)
                                            resultInfoForProjects += " » Project #" + projects[sameProjectIndex].ID + " (\"" + projects[sameProjectIndex].Name + "\"): name changed to \"" + currentNewProject.Name + "\"\r\n";
                                        if (currentNewProject.Description != projects[sameProjectIndex].Description)
                                            resultInfoForProjects += " » Project #" + projects[sameProjectIndex].ID + " (\"" + currentNewProject.Name + "\"): description updated\r\n";
                                        if (currentNewProject.Parent == null && projects[sameProjectIndex].Parent != null)
                                            resultInfoForProjects += " » Project #" + projects[sameProjectIndex].ID + " (\"" + currentNewProject.Name + "\"): became an individual project\r\n";
                                        else if ((currentNewProject.Parent != null && projects[sameProjectIndex].Parent == null) || (currentNewProject.Parent != null && projects[sameProjectIndex].Parent != null && currentNewProject.Parent.ID != projects[sameProjectIndex].Parent.ID))
                                            resultInfoForProjects += " » Project #" + projects[sameProjectIndex].ID + " (\"" + currentNewProject.Name + "\"): became subproject of project #" + currentNewProject.Parent.ID + " (\"" + currentNewProject.Parent.Name + "\")\r\n";
                                        if (currentNewProject.IsPublic != projects[sameProjectIndex].IsPublic)
                                            resultInfoForProjects += " » Project #" + projects[sameProjectIndex].ID + " (\"" + currentNewProject.Name + "\"): publicity changed to \"" + (currentNewProject.IsPublic ? "Yes" : "No") + "\"\r\n";
                                        string oldProjectRoles = "";
                                        foreach (Role currentRole in projects[sameProjectIndex].Roles)
                                            oldProjectRoles += currentRole.Name + ", ";
                                        oldProjectRoles = oldProjectRoles.Remove(oldProjectRoles.Length - 2);
                                        string newProjectRoles = "";
                                        foreach (Role currentRole in newProjects[sameProjectIndex].Roles)
                                            newProjectRoles += currentRole.Name + ", ";
                                        newProjectRoles = newProjectRoles.Remove(newProjectRoles.Length - 2);
                                        if (oldProjectRoles != newProjectRoles)
                                            resultInfoForProjects += " » Project #" + projects[sameProjectIndex].ID + " (\"" + currentNewProject.Name + "\"): your project roles changed to \"" + newProjectRoles + "\"\r\n";
                                    }
                                }
                                else
                                    resultInfoForProjects = " » Project #" + currentNewProject.ID + " (\"" + currentNewProject.Name + "\") added\r\n";
                        if (sameProjectIndex >= 0 && currentNewProject.Roles[0].ID != -1)
                            if (currentNewProject.Status != projects[sameProjectIndex].Status)
                                resultInfoForProjects += " » Project #" + projects[sameProjectIndex].ID + " (\"" + currentNewProject.Name + "\"): status changed to \"" + (currentNewProject.Status == 1 ? "Opened" : "Closed") + "\"\r\n";
                    }
                    foreach (Project currentOldProject in projects)
                        if (Properties.Application.Default.show_closed_projects || (!Properties.Application.Default.show_closed_projects && currentOldProject.Status != 5))
                            if (Properties.Application.Default.show_projects_without_current_user || (!Properties.Application.Default.show_projects_without_current_user && currentOldProject.Roles[0].ID != -1))
                                if (newProjects.FindIndex(temp => temp.ID == currentOldProject.ID) < 0)
                                    resultInfoForProjects += " » Project #" + currentOldProject.ID + " (\"" + currentOldProject.Name + "\") removed\r\n";
                }
                projects = new List<Project>();
                projects.AddRange(newProjects);
                // Загружаем список задач
                string resultInfoForIssues = "";
                List<Issue> newIssues = new List<Issue>();
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
                    newIssues.AddRange(issuesJSONObject.Issues);
                    offset += issuesJSONObject.Limit;
                } while (issuesJSONObject.Issues.Count != 0);
                if (Properties.Application.Default.background_updater_notify_about_issues)
                {
                    // Подготавливаем список задач для сравнения
                    List<Issue> issueForComparing = new List<Issue>();
                    issueForComparing.AddRange(newIssues);
                    for (int i = 0; i < issueForComparing.Count; i++)
                    {
                        Project projectForCurrentIsssue = projects.Single(temp => temp.ID == issueForComparing[i].Project.ID);
                        if (projectForCurrentIsssue == null || (!Properties.Application.Default.show_closed_projects && projectForCurrentIsssue.Status == 5) || (!Properties.Application.Default.show_projects_without_current_user && projectForCurrentIsssue.Roles[0].ID == -1))
                        {
                            issueForComparing.RemoveAt(i);
                            i--;
                        }
                    }
                    // Находим изменения в задачах, если это необходимо
                    foreach (Issue currentNewIssue in issueForComparing)
                    {
                        int sameIssueIndex = issues.FindIndex(temp => temp.ID == currentNewIssue.ID);
                        if (sameIssueIndex >= 0)
                        {
                            if (currentNewIssue.UpdatedOn > issues[sameIssueIndex].UpdatedOn)
                            {
                                if (currentNewIssue.Subject != issues[sameIssueIndex].Subject)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + issues[sameIssueIndex].Subject + "\"): subject changed to \"" + currentNewIssue.Subject + "\"\r\n";
                                if (currentNewIssue.Project.ID != issues[sameIssueIndex].Project.ID)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): project changed to \"" + currentNewIssue.Project.Name + "\" (ID: " + currentNewIssue.Project.ID + ")\r\n";
                                if (currentNewIssue.Tracker.ID != issues[sameIssueIndex].Tracker.ID)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): tracker changed to \"" + currentNewIssue.Tracker.Name + "\"\r\n";
                                if (currentNewIssue.Status.ID != issues[sameIssueIndex].Status.ID)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): status changed to \"" + currentNewIssue.Status.Name + "\"\r\n";
                                if (currentNewIssue.Priority.ID != issues[sameIssueIndex].Priority.ID)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): priority changed to \"" + currentNewIssue.Priority.Name + "\"\r\n";
                                if (currentNewIssue.AssignedTo == null && issues[sameIssueIndex].AssignedTo != null)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): assignee deleted (last: " + issues[sameIssueIndex].AssignedTo.Name + ")\r\n";
                                else if ((currentNewIssue.AssignedTo != null && issues[sameIssueIndex].AssignedTo == null) || (currentNewIssue.AssignedTo != null && issues[sameIssueIndex].AssignedTo != null && currentNewIssue.AssignedTo.ID != issues[sameIssueIndex].AssignedTo.ID))
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): assignee set to " + currentNewIssue.AssignedTo.Name + "\r\n";
                                if (currentNewIssue.Description != issues[sameIssueIndex].Description)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): description updated\r\n";
                                if (currentNewIssue.IsPrivate != issues[sameIssueIndex].IsPrivate)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): privacy changed to \"" + (currentNewIssue.IsPrivate ? "Yes" : "No") + "\"\r\n";
                                if (currentNewIssue.StartDate != issues[sameIssueIndex].StartDate)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): start date changed to \"" + currentNewIssue.StartDate.ToShortDateString() + "\"\r\n";
                                if (currentNewIssue.DueDate != issues[sameIssueIndex].DueDate)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): due date changed to \"" + currentNewIssue.DueDate.ToShortDateString() + "\"\r\n";
                                if (currentNewIssue.EstimatedHours != issues[sameIssueIndex].EstimatedHours)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): estimated time changed to \"" + currentNewIssue.EstimatedHours + "\"\r\n";
                                if (currentNewIssue.DoneRatio != issues[sameIssueIndex].DoneRatio)
                                    resultInfoForIssues += " » Issue #" + issues[sameIssueIndex].ID + " (\"" + currentNewIssue.Subject + "\"): done ratio changed to " + currentNewIssue.DoneRatio + "%\r\n";
                            }
                        }
                        else
                            resultInfoForIssues += " » Issue #" + currentNewIssue.ID + " (\"" + currentNewIssue.Subject + "\") added\r\n";
                    }
                    foreach (Issue currentOldIssue in issues)
                    {
                        Project projectForCurrentIssue = projects.Single(temp => temp.ID == currentOldIssue.Project.ID);
                        if (projectForCurrentIssue != null)
                            if (Properties.Application.Default.show_closed_projects || (!Properties.Application.Default.show_closed_projects && projectForCurrentIssue.Status != 5))
                                if (Properties.Application.Default.show_projects_without_current_user || (!Properties.Application.Default.show_projects_without_current_user && projectForCurrentIssue.Roles[0].ID != -1))
                                    if (newIssues.FindIndex(temp => temp.ID == currentOldIssue.ID) < 0)
                                        resultInfoForIssues += " » Issue #" + currentOldIssue.ID + " (\"" + currentOldIssue.Subject + "\") removed\r\n";
                    }
                }
                issues = new List<Issue>();
                issues.AddRange(newIssues);
                // Комбинируем полученную информацию
                string resultInfo = "";
                if (resultInfoForProjects.Length > 0)
                    resultInfo = "Changes in showing projects:\r\n" + resultInfoForProjects + "\r\n";
                if (resultInfoForIssues.Length > 0)
                    resultInfo += "Changes in issues:\r\n" + resultInfoForIssues;
                if(resultInfo.Length > 0)
                    resultInfo = resultInfo.Remove(resultInfo.Length - 1);
                if (OnBackgroundUpdated != null)
                    OnBackgroundUpdated(ErrorTypes.NoErrors, projects, resultInfo);
                StartBackgroundUpdater(false);
            }
            catch (Exception ex)
            {
                if (OnBackgroundUpdated != null)
                {
                    if (ex is WebException)
                    {
                        WebException webException = (WebException)ex;
                        if (webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Unauthorized)
                            OnBackgroundUpdated(ErrorTypes.UnathorizedAccess, null, null);
                        else
                        {
                            OnBackgroundUpdated(ErrorTypes.ConnectionError, null, null);
                            StartBackgroundUpdater(false);
                        }
                    }
                    else if (ex is ArgumentException)
                        OnBackgroundUpdated(ErrorTypes.UnathorizedAccess, null, null);
                    else
                    {
                        OnBackgroundUpdated(ErrorTypes.UnknownError, null, null);
                        StartBackgroundUpdater(false);
                    }
                }
            }
        }
    }
}
