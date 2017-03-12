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
    public enum ErrorTypes { NoErrors, NoInternetConnection, UnathorizedAccess }

    public class Controller
    {
        List<Project> projects;
        List<Issue> issues;

        public event Action<ErrorTypes, bool> OnAPITokenChanged;
        public event Action<ErrorTypes, List<Project>> OnProjectsUpdated;
        public event Action<ErrorTypes, List<Issue>> OnIssuesUpdated;

        public void ChangeApiToken(string apiToken)
        {
            new Thread(delegate()
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
                                    OnAPITokenChanged(ErrorTypes.NoErrors, true);
                                }
                                else
                                    OnAPITokenChanged(ErrorTypes.NoErrors, false);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("401") && OnAPITokenChanged != null)
                                OnAPITokenChanged(ErrorTypes.UnathorizedAccess, false);
                        }
                    }
                    else if (OnAPITokenChanged != null)
                        OnAPITokenChanged(ErrorTypes.NoInternetConnection, false);
                }).Start();
        }

        public void UpdateProjects()
        {
            new Thread(delegate()
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
                                OnProjectsUpdated(ErrorTypes.NoErrors, projects);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("401") && OnProjectsUpdated != null)
                                OnProjectsUpdated(ErrorTypes.UnathorizedAccess, projects);
                        }
                    }
                    else if (OnProjectsUpdated != null)
                        OnProjectsUpdated(ErrorTypes.NoInternetConnection, projects);
                }).Start();
        }

        public void UpdateIssues(long projectID)
        {
            new Thread(delegate()
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
                                OnIssuesUpdated(ErrorTypes.NoErrors, issues);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("401") && OnIssuesUpdated != null)
                                OnIssuesUpdated(ErrorTypes.UnathorizedAccess, issues);
                        }
                    }
                    else if (OnIssuesUpdated != null)
                        OnIssuesUpdated(ErrorTypes.NoInternetConnection, issues);
                }).Start();
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
}
