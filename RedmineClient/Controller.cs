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
                            projects = new List<Project>();
                            Projects tempProjects = new Projects();
                            int offset = 0;
                            do
                            {
                                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "projects.json?offset=" + offset);
                                request.Method = "GET";
                                request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_token);
                                request.Accept = "application/json";
                                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                                string jsonResult = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                tempProjects = JsonConvert.DeserializeObject<Projects>(jsonResult);
                                projects.AddRange(tempProjects.ProjectsList);
                                offset += tempProjects.Limit;
                            } while (tempProjects.ProjectsList.Count != 0);
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
                            Issues tempIssues = new Issues();
                            int offset = 0;
                            do
                            {
                                request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "issues.json?offset=" + offset);
                                request.Method = "GET";
                                request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_token);
                                request.Accept = "application/json";
                                response = (HttpWebResponse)request.GetResponse();
                                streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                                jsonResult = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                tempIssues = JsonConvert.DeserializeObject<Issues>(jsonResult);
                                issues.AddRange(tempIssues.IssuesList);
                                offset += tempIssues.Limit;
                            }
                            while (tempIssues.IssuesList.Count != 0);
                            issues.RemoveAll(temp => temp.Project.ID != projectID);

                            List<Membership> memberships = new List<Membership>();
                            Memberships tempMemberships = new Memberships();
                            offset = 0;
                            do
                            {
                                request = (HttpWebRequest)WebRequest.Create(REDMINE_HOST + "/projects/" + projectID + "/memberships.json?offset=" + offset);
                                request.Method = "GET";
                                request.Headers.Add("X-Redmine-API-Key", Properties.Settings.Default.api_token);
                                request.Accept = "application/json";
                                response = (HttpWebResponse)request.GetResponse();
                                streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                                jsonResult = streamReader.ReadToEnd();
                                response.Close();
                                streamReader.Close();
                                tempMemberships = JsonConvert.DeserializeObject<Memberships>(jsonResult);
                                memberships.AddRange(tempMemberships.MembershipsList);
                                offset += tempMemberships.Limit;
                            } while (tempMemberships.MembershipsList.FindIndex(temp => temp.Member.ID == Properties.Settings.Default.id) < 0 && tempMemberships.MembershipsList.Count != 0);
                            Membership membership = memberships.Single(temp => temp.Member.ID == Properties.Settings.Default.id);
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
