using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;


namespace CognitiveSoftware.TeamFoundation.Integration
{
    /// <summary>
    /// Handles the control logic for the change detail page.
    /// This is a simple, read only page.
    /// </summary>
    public partial class DeleteDetail : System.Web.UI.Page
    {

        /// <summary>
        /// Handles the page load event.  This method retrieves the necessary information and triggers the bind action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["DeleteID"], System.Globalization.CultureInfo.CurrentCulture);
            WorkItem bug = DataManager.DevelopmentProject.Store.GetWorkItem(id);
            DeleteData(bug);
        }

        /// <summary>
        /// Binds a work item to the user interface elements;
        /// </summary>
        /// <param name="bug">The bug to be bound to the user interface.</param>
        private void DeleteData(WorkItem changeRequest)
        {
            title.Text = changeRequest.Title;
            Id.Text = changeRequest.Fields["Id"].Value.ToString();           
            status.Text = changeRequest.Fields["State"].Value as string;
            triage.Text = changeRequest.Fields["Triage"].Value as string;



            if (changeRequest.Type.Name == "Bug")
            {
                description.Text = (changeRequest.Fields["Symptom"].Value as string);
               
            }
            else
            {
                description.Text = changeRequest.Description;
               
            }
            
            StringBuilder versionHistory = new StringBuilder();
            foreach (Revision issue in changeRequest.Revisions)
                versionHistory.Insert(0, string.Format(System.Globalization.CultureInfo.CurrentCulture,
                    "By:{0}<br>On: {1}<br>{2}<br><hr>",
                    issue.Fields["Changed By"].Value,
                    issue.Fields["Changed Date"].Value,
                    issue.Fields["History"].OriginalValue));

            history.Text = versionHistory.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            server.Authenticate();
            WorkItemStore store = new WorkItemStore(server);


            int WorkItemWillDelete = Convert.ToInt32(Id.Text);
            List<int> toDeletes = new List<int>();
            toDeletes.Add(WorkItemWillDelete);
            var errors = store.DestroyWorkItems(toDeletes);
            foreach (var error in errors)
            {
                Console.WriteLine(error.Exception.Message);

            }

            store.RefreshCache();
            store.SyncToCache();
            
            
            btnRedirect_Click();
        }

        private void btnRedirect_Click()
        {
            string message = "Silme Islemi Basarili";
            
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            
            script += "'; }";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", script, true);
            Response.Redirect("~/IssuesList.aspx");

        }


    }
}
