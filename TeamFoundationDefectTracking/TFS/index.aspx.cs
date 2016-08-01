using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Security.Principal;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using System.Net;
using System.Data;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using CognitiveSoftware.TeamFoundation.Integration.Resources;



namespace CognitiveSoftware.TeamFoundation.Integration.TFS
{
    public partial class index : System.Web.UI.Page
    {
        TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
        private TfsTeamProjectCollection tfs;
        private IGroupSecurityService _gss;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            { 
                UserPrincipal isimsoyisim = UserPrincipal.Current;
                Label1.Text = isimsoyisim.Name;

                if (!IsPostBack)
                {
                    DefaultDilYukle2(this, new EventArgs());
                    
                }

                string kullaniciadi = GetDisplayName();
                System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
                Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
                server.Authenticate();
                const string swdevelopment = "SW Development Management Team";
                const string tfsadmn = "TFS Admin Group";
                IGroupSecurityService gss = (IGroupSecurityService)server.GetService(typeof(IGroupSecurityService));
                var groupList = gss.ListApplicationGroups(null);
                var group = groupList.FirstOrDefault(o => o.AccountName.Contains(swdevelopment));
                var group2 = groupList.FirstOrDefault(s => s.AccountName.Contains(tfsadmn));
                Identity sids = gss.ReadIdentity(SearchFactor.Sid, group.Sid, QueryMembership.Expanded);
                Identity sids2 = gss.ReadIdentity(SearchFactor.Sid, group2.Sid, QueryMembership.Expanded);
                List<Identity> contributors = gss.ReadIdentities(SearchFactor.Sid, sids.Members, QueryMembership.Expanded).ToList();
                List<Identity> contributors2 = gss.ReadIdentities(SearchFactor.Sid, sids2.Members, QueryMembership.Expanded).ToList();
                List<Identity> contributors3 = new List<Identity>();
                contributors3.AddRange(contributors);
                contributors3.AddRange(contributors2);
                WorkItemStore workitemstore = server.GetService<WorkItemStore>();
                string workItemQuery = String.Format(@"SELECT * FROM WorkItems WHERE   ([Customer Of Request]= '" + isimsoyisim.DisplayName + "' OR [System.AssignedTo]='" + isimsoyisim.DisplayName + "' ) ORDER BY State,System.Id ");
                WorkItemCollection items = DataManager.DevelopmentProject.Store.Query(workItemQuery);
                Identity idt = new Identity();
                idt.AccountName = kullaniciadi;
                List<Identity> list = new List<Identity>();
                list = contributors3;
                List<Identity> newList = list.Where(m => m.AccountName == kullaniciadi)
                                        .Select(m => new Identity
                                        {
                                            AccountName = m.AccountName
                                        }).ToList();
                if (newList.Count == 0)//Musteri İse içeride.
                {
                    createworkitem.Visible = true;
                    GridView1.DataSource = items;
                    GridView1.DataBind();
                }

                //TFS ADMİN GROUP TEAM
                foreach (var user in contributors2)
                {
                    if (user.AccountName.ToString() == kullaniciadi)
                    {
                        admindeletebtn.Visible = true;
                        admingroupopbtn.Visible = true;
                        adminuserlistbtn.Visible = true;
                        yonetcilistbtn.Visible = true;
                        yoneticibtn.Visible = true;
                        createworkitem.Visible = true;
                        GridView1.DataSource = items;
                        GridView1.DataBind();
                        return;
                    }
                    else { }
                }
                //SW DEVELOPMENT MANAGEMENT TEAM
                foreach (var user in contributors)
                {
                    if (user.AccountName.ToString() == kullaniciadi)
                    {
                        createworkitem.Visible = true;
                        adminuserlistbtn.Visible = true;
                        yoneticibtn.Visible = true;

                        GridView1.DataSource = items;
                        GridView1.DataBind();
                        return;
                    }
                    else { }
                }
                var myTable = new DataTable();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

          

        private string GetDisplayName()
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.Current;
            return user.SamAccountName;
        }

        protected void DefaultDilYukle2(object sender, EventArgs e)
        {
            GridView1.Columns[0].HeaderText = TR.Id;
            GridView1.Columns[1].HeaderText = TR.State;
            GridView1.Columns[2].HeaderText = TR.Type;
            GridView1.Columns[3].HeaderText = TR.areapath;
            GridView1.Columns[4].HeaderText = TR.title;
            GridView1.Columns[5].HeaderText = TR.Reason;
            GridView1.Columns[6].HeaderText = TR.Detail;
         

            GridView1.DataBind();

            adminuserlistbtn.InnerText = TR.adminuserlistbtn;
            yoneticibtn.InnerText=TR.yoneticibtn;
            admindeletebtn.InnerText = TR.admindeletebtn;
            yonetcilistbtn.InnerText=TR.yonetcilistbtn;
            admingroupopbtn.InnerText=TR.admingroupopbtn;
            createworkitem.InnerText = TR.createworkitem;
           



        }

        protected void EngDilYukle2(object sender, EventArgs e)
        {
            GridView1.Columns[0].HeaderText = EN.Id;
            GridView1.Columns[1].HeaderText = EN.State;
            GridView1.Columns[2].HeaderText = EN.Type;
            GridView1.Columns[3].HeaderText = EN.areapath;
            GridView1.Columns[4].HeaderText = EN.title;
            GridView1.Columns[5].HeaderText = EN.Reason;
            GridView1.Columns[6].HeaderText = EN.Detail;           
            GridView1.DataBind();


            adminuserlistbtn.InnerText = EN.adminuserlistbtn;
            yoneticibtn.InnerText = EN.yoneticibtn;
            admindeletebtn.InnerText = EN.admindeletebtn;
            yonetcilistbtn.InnerText = EN.yonetcilistbtn;
            admingroupopbtn.InnerText = EN.admingroupopbtn;
            createworkitem.InnerText = EN.createworkitem;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        




    }
}