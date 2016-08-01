using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CognitiveSoftware.TeamFoundation.Integration.TFS
{
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["ID"], System.Globalization.CultureInfo.CurrentCulture);
            WorkItem changeRequest = DataManager.DevelopmentProject.Store.GetWorkItem(id);
            var tip = changeRequest.GetType();
            BindData(changeRequest);
        }
        private void BindData(WorkItem changeRequest)
        {
            try
            {
                if (changeRequest.Fields["Work Item Type"].Value=="Bug")
                {
                    detay.Text = changeRequest.Fields["Symptom"].Value.ToString();
                }
                else
                {
                    detay.Text = changeRequest.Fields["Description"].Value.ToString();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}