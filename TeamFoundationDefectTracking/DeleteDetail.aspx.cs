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
        private void DeleteData(WorkItem bug)
        {
            title.Text = bug.Title;
            Id.Text = bug.Fields["Id"].Value.ToString();
            //fdate.Text = bug.Fields["Finish Date"].Value as string;
            status.Text = bug.Fields["State"].Value as string;
            triage.Text = bug.Fields["Triage"].Value as string;
            description.Text = (bug.Fields["Symptom"].Value as string);
            reproduce.Text = (bug.Fields["Repro Steps"].Value as string);
            StringBuilder versionHistory = new StringBuilder();
            foreach (Revision issue in bug.Revisions)
            {

                versionHistory.Insert(0, string.Format(System.Globalization.CultureInfo.CurrentCulture,
                    "By:{0}<br>On: {1}<br>{2}<br><hr>",
                    issue.Fields["Changed By"].Value,
                    issue.Fields["Changed Date"].Value,
                    issue.Fields["History"].OriginalValue as string));

            }

            history.Text = versionHistory.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
                    System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName,config.Password,config.Domain);
                    Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName,account);
                    server.Authenticate();
                    WorkItemStore store = new WorkItemStore(server);

            int abc = Convert.ToInt32(TextBox1.Text);
            List<int> toDeletes = new List<int>();
            toDeletes.Add(abc);


            store.DestroyWorkItems(toDeletes);
            
   
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
