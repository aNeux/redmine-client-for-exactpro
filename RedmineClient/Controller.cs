using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RedmineClient.Models;

namespace RedmineClient
{
    public enum ErrorTypes { NoErrors, NoInternetConnection, UnathorizedAccess }

    public class Controller
    {
        List<Project> projects;
        List<Issue> issues;

        public event EventHandler<APITokenEventArgs> OnAPITokenChanged;
        public event EventHandler<ProjectsEventArgs> OnProjectsUpdated;
        public event EventHandler<IssuesEventArgs> OnIssuesUpdated;

        public void ChangeApiToken(string apiToken)
        {
            if (Utils.IsNetworkAvailable())
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://exactprotest.plan.io/projects.json");
                    request.Method = "GET";
                    request.Headers.Add("X-Redmine-API-Key", apiToken);
                    request.Accept = "application/json";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (OnAPITokenChanged != null)
                        if (Properties.Settings.Default.api_token != apiToken)
                        {
                            Properties.Settings.Default.api_token = apiToken;
                            Properties.Settings.Default.Save();
                            OnAPITokenChanged(this, new APITokenEventArgs(ErrorTypes.NoErrors, true));
                        }
                        else
                            OnAPITokenChanged(this, new APITokenEventArgs(ErrorTypes.NoErrors, false));
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("401") && OnAPITokenChanged != null)
                        OnAPITokenChanged(this, new APITokenEventArgs(ErrorTypes.UnathorizedAccess, false));
                }
            }
            else if (OnAPITokenChanged != null)
                OnAPITokenChanged(this, new APITokenEventArgs(ErrorTypes.NoInternetConnection, false));
        }

        public void UpdateProjects()
        {
            if (Utils.IsNetworkAvailable())
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://exactprotest.plan.io/projects.json");
                    request.Method = "GET";
                    request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_token);
                    request.Accept = "application/json";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string jsonResult = streamReader.ReadToEnd();
                    response.Close();
                    streamReader.Close();
                    projects = JsonConvert.DeserializeObject<Projects>(jsonResult).ProjectsList;
                    if (OnProjectsUpdated != null)
                        OnProjectsUpdated(this, new ProjectsEventArgs(ErrorTypes.NoErrors, projects));
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("401") && OnProjectsUpdated != null)
                        OnProjectsUpdated(this, new ProjectsEventArgs(ErrorTypes.UnathorizedAccess, projects));
                }
            }
            else if (OnProjectsUpdated != null)
                OnProjectsUpdated(this, new ProjectsEventArgs(ErrorTypes.NoInternetConnection, projects));
        }

        public void UpdateIssues(long projectID)
        {
            if (Utils.IsNetworkAvailable())
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://exactprotest.plan.io/issues.json");
                    request.Method = "GET";
                    request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_token);
                    request.Accept = "application/json";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string jsonResult = streamReader.ReadToEnd();
                    response.Close();
                    streamReader.Close();
                    issues = JsonConvert.DeserializeObject<Issues>(jsonResult).IssuesList;
                    issues.RemoveAll(temp => temp.Project.ID != projectID);
                    if (OnIssuesUpdated != null)
                        OnIssuesUpdated(this, new IssuesEventArgs(ErrorTypes.NoErrors, issues));
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("401") && OnIssuesUpdated != null)
                        OnIssuesUpdated(this, new IssuesEventArgs(ErrorTypes.UnathorizedAccess, issues));
                }
            }
            else if (OnIssuesUpdated != null)
                OnIssuesUpdated(this, new IssuesEventArgs(ErrorTypes.NoInternetConnection, issues));
        }

        public Project GetProject(long projectID)
        {
            return projects.Single(temp => temp.ID == projectID);
        }

        public Issue GetIssue(long issueID)
        {
            return issues.Single(temp => temp.ID == issueID);
        }
    }

    public class CommonEventArgs : EventArgs
    {
        public ErrorTypes Error { private set; get; }

        public CommonEventArgs(ErrorTypes error)
        {
            this.Error = error;
        }
    }

    public class APITokenEventArgs : CommonEventArgs
    {
        public bool IsChanged { private set; get; }

        public APITokenEventArgs(ErrorTypes error, bool isChanged)
            : base(error)
        {
            this.IsChanged = isChanged;
        }
    }

    public class ProjectsEventArgs : CommonEventArgs
    {
        public List<Project> Projects { private set; get; }

        public ProjectsEventArgs(ErrorTypes error, List<Project> projects)
            : base(error)
        {
            this.Projects = projects;
        }
    }

    public class IssuesEventArgs : CommonEventArgs
    {
        public List<Issue> Issues { private set; get; }

        public IssuesEventArgs(ErrorTypes error, List<Issue> issues)
            : base(error)
        {
            this.Issues = issues;
        }
    }

}
