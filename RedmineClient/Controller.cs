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
        private string REDMINE_HOST = "http://student-rm.exactpro.com/";

        private List<Project> projects;
        private List<Issue> issues;

        public event Action<ErrorTypes, bool> OnAPITokenChanged;
        public event Action<ErrorTypes, List<Project>> OnProjectsUpdated;
        public event Action<ErrorTypes, List<Issue>, string> OnIssuesUpdated;

        public void ChangeApiToken(string apiToken)
        {
            new Thread(delegate()
                {
                    if (Utils.IsNetworkAvailable())
                    {
                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "users/current.json");
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", apiToken);
                            request.Accept = "application/json";
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            string jsonResult = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            User currentUserInfo = JsonConvert.DeserializeObject<UserObj>(jsonResult).User;
                            Properties.Settings.Default.id = currentUserInfo.ID;
                            Properties.Settings.Default.login = currentUserInfo.Login;
                            Properties.Settings.Default.first_name = currentUserInfo.FirstName;
                            Properties.Settings.Default.last_name = currentUserInfo.LastName;
                            Properties.Settings.Default.email = currentUserInfo.Email;
                            Properties.Settings.Default.created_on = currentUserInfo.CreatedOn;
                            if (Properties.Settings.Default.api_token != apiToken)
                            {
                                Properties.Settings.Default.api_token = apiToken;
                                if (OnAPITokenChanged != null)
                                    OnAPITokenChanged(ErrorTypes.NoErrors, true);
                            }
                            else if (OnAPITokenChanged != null)
                                OnAPITokenChanged(ErrorTypes.NoErrors, false);
                            Properties.Settings.Default.Save();
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
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "projects.json");
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
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues.json");
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

                            request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "/projects/" + projectID + "/memberships.json");
                            request.Method = "GET";
                            request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_token);
                            request.Accept = "application/json";
                            response = (HttpWebResponse)request.GetResponse();
                            streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            jsonResult = streamReader.ReadToEnd();
                            response.Close();
                            streamReader.Close();
                            Membership membership = JsonConvert.DeserializeObject<Memberships>(jsonResult).MembershipsList.Single(temp => temp.Member.ID == Properties.Settings.Default.id);
                            string roles = "";
                            foreach (Role role in membership.Roles)
                                roles += role.Name + ", ";
                            roles = roles.Remove(roles.Length - 2);
                            if (OnIssuesUpdated != null)
                                OnIssuesUpdated(ErrorTypes.NoErrors, issues, roles);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("401") && OnIssuesUpdated != null)
                                OnIssuesUpdated(ErrorTypes.UnathorizedAccess, issues, null);
                        }
                    }
                    else if (OnIssuesUpdated != null)
                        OnIssuesUpdated(ErrorTypes.NoInternetConnection, issues, null);
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
