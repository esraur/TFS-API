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

namespace CognitiveSoftware.TeamFoundation.Integration
{
    /// <summary>
    /// Handles the control logic for the change detail page.
    /// This is a simple, read only page.
    /// </summary>
    public partial class ChangeDetail : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the page load event.  Retrieves the requested item and triggers the bind action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get the issue ID from the query string and retrieve the associated issue
            // bind the relevant fields to the interfacel
            int id = int.Parse(Request.QueryString["IssueID"], System.Globalization.CultureInfo.CurrentCulture);
            WorkItem changeRequest = DataManager.DevelopmentProject.Store.GetWorkItem(id);
            BindData(changeRequest);     
        }

        /// <summary>
        /// Binds the given change request to the interface elements.
        /// </summary>
        /// <param name="changeRequest">The change request being reviewed.</param>
        private void BindData(WorkItem changeRequest)
        {
            title.Text = changeRequest.Title;
            Id.Text = changeRequest.Fields["Id"].Value.ToString();
            
            status.Text = changeRequest.Fields["State"].Value as string;
            triage.Text = changeRequest.Fields["Triage"].Value as string;

            Company.Text = changeRequest.Fields["Company Of Customer"].Value.ToString();

            if (changeRequest.Type.Name=="Bug")
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
    }
}


      