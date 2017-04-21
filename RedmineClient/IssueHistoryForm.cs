using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RedmineClient.Models;

namespace RedmineClient
{
    public partial class IssueHistoryForm : Form
    {
        private Issue issue;
        private List<IssueTracker> issueTrackers;
        private List<IssueStatus> issueStatuses;
        private List<IssuePriority> issuePriorities;
        private List<Membership> membership;

        public IssueHistoryForm(Issue issue, List<IssueTracker> issueTrackers, List<IssueStatus> issueStatuses, List<IssuePriority> issuePriorities, List<Membership> membership)
        {
            InitializeComponent();
            this.issue = issue;
            this.issueTrackers = issueTrackers;
            this.issueStatuses = issueStatuses;
            this.issuePriorities = issuePriorities;
            this.membership = membership;
            this.Text = "Issue #" + issue.ID + " history";
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void IssueHistoryForm_Shown(object sender, EventArgs e)
        {
            string result = "";
            for (int i = 0; i < issue.Journals.Count; i++)
            {
                Journal currentJournal = issue.Journals[i];
                result += "# " + (i + 1) + ": update by " + currentJournal.User.Name + " at " + currentJournal.CreatedOn.ToShortTimeString() + ", " + currentJournal.CreatedOn.ToShortDateString() + "\r\n";
                foreach (JournalDetail currentDetail in currentJournal.Details)
                {
                    switch (currentDetail.Name)
                    {
                        case "tracker_id":
                            result += " » Tracker changed from " + issueTrackers.Single(temp => temp.ID.ToString() == currentDetail.OldValue).Name + " to " + issueTrackers.Single(temp => temp.ID.ToString() == currentDetail.NewValue).Name + "\r\n";
                            break;
                        case "project_id":
                            result += " » Project changed from " + Program.controllerGlobal.GetProject(Convert.ToInt64(currentDetail.OldValue)).Name + " to " + Program.controllerGlobal.GetProject(Convert.ToInt64(currentDetail.NewValue)).Name + "\r\n";
                            break;
                        case "subject":
                            result += " » Subject changed from " + currentDetail.OldValue + " to" + currentDetail.NewValue + "\r\n";
                            break;
                        case "description":
                            result += " » Description updated\r\n";
                            break;
                        case "due_date":
                            result += " » Due date changed from "+ currentDetail.OldValue + " to " + currentDetail.NewValue + "\r\n";
                            break;
                        case "status_id":
                            result += " » Status changed from " + issueStatuses.Single(temp => temp.ID.ToString() == currentDetail.OldValue).Name + " to " + issueStatuses.Single(temp => temp.ID.ToString() == currentDetail.NewValue).Name + "\r\n";
                            break;
                        case "assigned_to_id":
                            if (currentDetail.NewValue != null)
                                result += " » Assignee set to " + membership.Single(temp => temp.User.ID.ToString() == currentDetail.NewValue).User.Name + "\r\n";
                            else
                                result += " » Assignee deleted (last: " + membership.Single(temp => temp.User.ID.ToString() == currentDetail.OldValue).User.Name + ")\r\n";
                            break;
                        case "priority_id":
                            result += " » Priority changed from " + issuePriorities.Single(temp => temp.ID.ToString() == currentDetail.OldValue).Name + " to " + issuePriorities.Single(temp => temp.ID.ToString() == currentDetail.NewValue).Name + "\r\n";
                            break;
                        case "start_date":
                            result += " » Start date changed from " + currentDetail.OldValue + " to " + currentDetail.NewValue + "\r\n";
                            break;
                        case "estimated_hours":
                            result += " » Estimated time changed from " + currentDetail.OldValue + " to " + currentDetail.NewValue + "\r\n";
                            break;
                        case "is_private":
                            result += " » Private changed from " + (currentDetail.OldValue == "1" ? "Yes" : "No") + " to " + (currentDetail.NewValue == "1" ? "Yes" : "No") + "\r\n";
                            break;
                    }
                }
                if (currentJournal.Notes != null && currentJournal.Notes.Length > 0)
                    result += " » Note: " + currentJournal.Notes;
                result += "\r\n\r\n";
            }
            tbHistory.Text = result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
