using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CognitiveSoftware.TeamFoundation.Integration
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cem();
            //int b = Convert.ToInt32(TextBox1.Text);

        }
        //private void cem()
        //{
        //    Hashtable parameters = new Hashtable();
        //    parameters.Add("project", DataManager.DevelopmentProject.Name);
        //    //int b = Convert.ToInt32(TextBox1.Text);
        //    string query = "SELECT [System.Id], [System.WorkItemType], [System.AssignedTo], [System.CreatedBy] FROM WorkItems WHERE [System.TeamProject] = @project AND  [System.WorkItemType] = 'Bug' AND [System.Id] = '" + TextBox1.Text.Trim() + "' ORDER BY [System.WorkItemType], [System.Title], [Microsoft.VSTS.Common.Priority], [System.Id]";
        //    WorkItemCollection items = DataManager.DevelopmentProject.Store.Query(query, parameters);
        //    GridView1.DataSource = items;
        //    GridView1.DataBind();
        //}
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("project", DataManager.DevelopmentProject.Name);
            //int b = Convert.ToInt32(TextBox1.Text);
            string query = "SELECT [System.Id], [System.WorkItemType], [System.AssignedTo], [System.CreatedBy] FROM WorkItems WHERE [System.TeamProject] = @project AND  [System.WorkItemType] = 'Bug' AND [System.Id] =  '" + TextBox1.Text.Trim() + "' ORDER BY [System.WorkItemType], [System.Title], [Microsoft.VSTS.Common.Priority], [System.Id]";
            WorkItemCollection items = DataManager.DevelopmentProject.Store.Query(query, parameters);
            GridView1.DataSource = items;
            GridView1.DataBind();
        }
    }
}