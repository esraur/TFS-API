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
namespace CognitiveSoftware.TeamFoundation.Integration
{
    public partial class ReportBug : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the page load event.  Triggers the preparation of the interface for consumption by the client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { BindData();}
            
        }

        /// <summary>
        /// Handles the Submit event.  Saves the issue to the database and redirects the client to the master list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SubmitIssue(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Save();                
            }
           
        }                   

        /// <summary>
        /// Saves the issue to the team foundation server by reading the data from the view layer
        /// and binding it to the newly created WorkItem.
        /// </summary>
        private void Save()
        {
            //Note: Some of the common WorkItem fields, such as "Title"  are available
            //as properties of the WorkItem.  Others, such as "Symptom" that are specific to
            //a BugType need to be accessed via the Fields collection.

            WorkItem newBug = new WorkItem(DataManager.BugType);
            newBug.Title = BugTitle.Text;
            newBug.Fields["Symptom"].Value = Description.Text.Replace("\n", "<br/>");
            newBug.Fields["Severity"].Value = Severity.SelectedItem.Text;
            newBug.Fields["Company Of Customer"].Value = Company.SelectedItem.Text;           
            //Steps to Reproduce"     
            newBug.Validate();

            if (newBug.IsValid())
            {
                newBug.Save();
                btnRedirect_Click(newBug.Id);   
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
        
      
        /// <summary>
        /// Binds data from the TFS to the view layer.
        /// </summary>
        /// <remarks>This class currently binds the severity fiels to the severity dropw down list.
        /// If additional "picklist" type fields are needed, they can be bound here.
        /// </remarks>
        protected void BindData()
        {
           Severity.DataSource = DataManager.BugType.FieldDefinitions["Severity"].AllowedValues; 
           Severity.DataBind();
           TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
           System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
           Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
           WorkItemStore wis = (WorkItemStore)server.GetService(typeof(WorkItemStore));
           Project teamProject = wis.Projects[config.Project];
           WorkItemType wit = teamProject.WorkItemTypes["Bug"];
           FieldDefinition fd = wit.FieldDefinitions["Company Of Customer"];
           AllowedValuesCollection avc = fd.AllowedValues;
           Company.DataSource = avc;
           Company.DataBind();
        }
               
    }
}
