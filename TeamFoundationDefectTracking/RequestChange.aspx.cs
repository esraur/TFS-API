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
using System.Web.Caching;
using System.Collections.Generic;
namespace CognitiveSoftware.TeamFoundation.Integration
{
    public partial class RequestChange : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the submit event.  Saves the change request and redirects to the master list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { BindData();}
            
        }
        protected void SubmitIssue(object sender, EventArgs e)
        {
            if (IsValid)
                Save();

        }

        /// <summary>
        /// Saves the issue to the team foundation server by reading the data from the view layer
        /// and binding it to the newly created WorkItem.
        /// </summary>
        private void Save()
        {
            //Note: Some of the common WorkItem fields, such as "Title" and "Description" are available
            //as properties of the WorkItem.  Others, such as "Justification" that are specific to
            //a ChangeRequestType need to be accessed via the Fields collection.

            WorkItem newRequest = new WorkItem(DataManager.ChangeRequestType);
            newRequest.Title = ChangeTitle.Text;
            newRequest.Description = Description.Text.Replace("\n", "<br/>");          
            newRequest.Fields["Company Of Customer"].Value = Company.SelectedItem.Text;           
            newRequest.Validate();

            if (newRequest.IsValid())
            {
                newRequest.Save();
                btnRedirect_Click(newRequest.Id);

            }
            else
            {
                Response.Write("Kaydetme Baþarýsýz");
            }
           
        }

        private void btnRedirect_Click(int p)
        {
            string message = "Ýþleminiz " + p + " numaralý ID ile kaydedilmiþtir.Ana sayfaya yönlendirileceksiniz";
            string url = "IssuesList.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", script, true);

        }
        protected void BindData()
        {
            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            WorkItemStore wis = (WorkItemStore)server.GetService(typeof(WorkItemStore));
            Project teamProject = wis.Projects[config.Project];
            WorkItemType wit = teamProject.WorkItemTypes["Change Request"];
            FieldDefinition fd = wit.FieldDefinitions["Company Of Customer"];
            AllowedValuesCollection avc = fd.AllowedValues;
            Company.DataSource = avc;           
            Company.DataBind();


        }

    }
}
