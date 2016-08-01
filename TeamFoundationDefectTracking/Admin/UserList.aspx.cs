using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.Proxy;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;

namespace CognitiveSoftware.TeamFoundation.Integration.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            // sayfa yüklendiğinde config bilgilerinde bulunan tfs serverımıza bağlanma ve config içerisindeki projeyi çekme
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            server.Authenticate();
            //list_projects.Items.Insert(0, new ListItem(config.Project, config.Project));  DropdownList konulursa configteki projeyi içine atma
            ProjeAdLabel.Text = config.Project;
            GetTfsUsers(server.TfsTeamProjectCollection, config.Project);
        }

        private void GetTfsUsers(TfsTeamProjectCollection server, string Project)
        {
            //const string groupName = "Project Collection Valid Users";
            const string groupName = "Project Valid Users";
            IGroupSecurityService gss = (IGroupSecurityService)server.GetService(typeof(IGroupSecurityService));

            // projede bulunan grupları çekme
            var groupList = gss.ListApplicationGroups(config.Project);
            var group = groupList.FirstOrDefault(o => o.AccountName.Contains(groupName));  // you can also use DisplayName

            Identity sids = gss.ReadIdentity(SearchFactor.Sid, group.Sid, QueryMembership.Expanded);

            //// there are no users
            //if (sids.Members.Length == 0) { }
            //    return null;}

            // convert to a list
            List<Identity> contributors = gss.ReadIdentities(SearchFactor.Sid, sids.Members, QueryMembership.Expanded).ToList();

            DataTable myTable = new DataTable();

            //oluşan listeyi datatableda gösteriyoruz, yukarıda datatable tanımladık ve aşağıda göstereceğimiz columnları yerleştirdik.

            DataRow dRow = myTable.NewRow();
            dRow.Table.Columns.Add("Displayname");
            dRow.Table.Columns.Add("AccountName");
            dRow.Table.Columns.Add("MemberOf");
            dRow.Table.Columns.Add("MailAddress");
            dRow.Table.Columns.Add("Sid");

            foreach (var user in contributors)
            {
                if (user.Type == IdentityType.WindowsUser)
                {

                    if (user != null)
                    {

                        dRow = myTable.NewRow();
                        dRow["Displayname"] = user.DisplayName;
                        dRow["AccountName"] = user.AccountName;

                        string GroupName = "";


                        for (int GroupID = 0; GroupID < groupList.Count(); GroupID++)
                        {
                            for (int MemberID = 0; MemberID < user.MemberOf.Count(); MemberID++)
                            {
                                if (groupList[GroupID].Sid == user.MemberOf[MemberID])
                                {
                                    if (GroupName != "")
                                    {
                                        GroupName = GroupName + " , " + groupList[GroupID].DisplayName;

                                    }
                                    else
                                    {
                                        GroupName = groupList[GroupID].DisplayName;
                                    }
                                }
                            }


                        }

                        dRow["MemberOf"] = GroupName;
                        dRow["MailAddress"] = user.MailAddress;
                        dRow["Sid"] = user.Sid;

                        myTable.Rows.Add(dRow);
                    }
                }

                GridList.DataSource = myTable;
                GridList.DataBind();

            }
        }
    }

}
