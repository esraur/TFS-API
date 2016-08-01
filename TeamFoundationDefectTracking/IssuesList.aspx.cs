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
using System.ComponentModel;
using Microsoft.TeamFoundation.Client;
using System.Net;
namespace CognitiveSoftware.TeamFoundation.Integration
{
    /// <summary>
    /// The control logic for the issue list.  The control class is responsible
    /// for retrieving the list of issues and biding them to the view layer.
    /// </summary>
    /// <remarks>This class can easily be expanded to include filtering and sorting capabilities.</remarks>
    public partial class IssuesList : System.Web.UI.Page
    {
        private TfsTeamProjectCollection tfs;
        private WorkItemStore store;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();

        }
        //protected string GetAddress()
        //{
        //    string boundAddressValue = DataBinder.Eval(Container.DataItem, "Fields['Severity'].Value");

        //    return !String.IsNullOrEmpty(boundAddressValue) ? boundAddressValue : String.Empty;
        //}
        /// <summary>
        /// Binds the data to the repeater
        /// </summary>
        private void BindData()
        {
            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            server.Authenticate();
            NetworkCredential myNetCredentials = new NetworkCredential(config.UserName, config.Password, config.Domain);
            ICredentials myCredentials = (ICredentials)myNetCredentials;
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(config.ServerName), myNetCredentials);
            tfs = tpc;
            store = new WorkItemStore(tfs, WorkItemStoreFlags.BypassRules);
            // Hashtable parameters = new Hashtable();
            //parameters.Add("project", DataManager.DevelopmentProject.Name);
            //WorkItemStore workItemStore = (WorkItemStore)server.GetService(typeof(WorkItemStore));
            //string query = String.Format(@"Select * FROM WorkItems WHERE [System.IterationPath] UNDER '{0}' AND [System.AreaPath] UNDER '{0}'  AND [System.WorkItemType] = 'Bug' OR [System.WorkItemType] = 'Change Request' ORDER BY [System.ID] ", config.Project);
            string query = String.Format(@"SELECT * FROM WorkItems WHERE  ([System.WorkItemType]='Bug' OR [SYSTEM.WorkItemType]='Change Request') AND [System.AreaPath]='" + config.Project + "' ");
            //Query query2 = new Query(workItemStore, query);
            WorkItemCollection items = DataManager.DevelopmentProject.Store.Query(query);
            //WorkItemCollection results = query2.RunQuery();
            GridView1.DataSource = items;
            GridView1.DataBind();
        }
    }
}
