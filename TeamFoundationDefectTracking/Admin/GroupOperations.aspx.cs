using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using Microsoft.TeamFoundation.Framework.Client;
using System.Collections.ObjectModel;
using Microsoft.TeamFoundation.Framework.Common;
using System.Collections;

namespace CognitiveSoftware.TeamFoundation.Integration.Admin
{
    public partial class GroupOperations : System.Web.UI.Page
    {
        private TfsTeamProjectCollection _tfs;
        private IGroupSecurityService _gss;
        private ICommonStructureService _css;
        private HttpStyleUriParser _hss;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { BindData(); }

        }

        protected void BindData()
        {

            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            _css = (ICommonStructureService)server.GetService<ICommonStructureService>();
            _gss = (IGroupSecurityService)server.GetService<IGroupSecurityService>();
            var allSids = _gss.ReadIdentity(SearchFactor.AccountName,
                "Project Collection Valid Users", QueryMembership.Expanded);

            //tüm kullanıcıları listeleme
            foreach (var item in _gss.ReadIdentities(SearchFactor.Sid, allSids.Members,
               QueryMembership.None))
            {
                if (item != null && item.MailAddress != "")
                {
                    ListAllUsers.Items.Add(new ListItem(item.DisplayName, item.Sid));
                }
            }
            List<ListItem> list4 = new List<ListItem>(ListAllUsers.Items.Cast<ListItem>());

            //sort list item alphabetixcally
            list4 = list4.OrderBy(x => x.Text).ToList<ListItem>();
            ListAllUsers.Items.Clear();
            ListAllUsers.Items.AddRange(list4.ToArray<ListItem>());

            //grupları listeleme
            AllGroups.DataSource = _gss.ListApplicationGroups(config.Project);
            AllGroups.DataBind();
            List<ListItem> list3 = new List<ListItem>(AllGroups.Items.Cast<ListItem>());
            //sort list item alphabetixcally
            list3 = list3.OrderBy(x => x.Text).ToList<ListItem>();
            AllGroups.Items.Clear();
            AllGroups.Items.AddRange(list3.ToArray<ListItem>());

            //projeleri listboxa gönderme
            Project2.DataSource = _css.ListAllProjects();
            foreach (var projectinfo in _css.ListAllProjects())
            {
                Project2.Items.Add(projectinfo.Name);
            }
            List<ListItem> list2 = new List<ListItem>(Project2.Items.Cast<ListItem>());
            //sort list item alphabetixcally
            list2 = list2.OrderBy(x => x.Text).ToList<ListItem>();
            Project2.Items.Clear();
            Project2.Items.AddRange(list2.ToArray<ListItem>());

            //alttaki tüm kullanıcıları listeleme
            foreach (var item in _gss.ReadIdentities(SearchFactor.Sid, allSids.Members,
              QueryMembership.None))
            {
                if (item != null && item.MailAddress != "")
                {
                    AllUsersDown.Items.Add(new ListItem(item.DisplayName, item.Sid));
                }
            }
            List<ListItem> list = new List<ListItem>(AllUsersDown.Items.Cast<ListItem>());
            //sort list item alphabetixcally
            list = list.OrderBy(x => x.Text).ToList<ListItem>();
            AllUsersDown.Items.Clear();
            AllUsersDown.Items.AddRange(list.ToArray<ListItem>());
        }

        //listboxda grup seçme eventi
        protected void AllGroupsSelectedChanged(object sender, EventArgs e)
        {
            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            _gss = (IGroupSecurityService)server.GetService<IGroupSecurityService>();
            if (AllGroups.SelectedItem == null) return;
            var sids = _gss.ReadIdentity(SearchFactor.Sid, AllGroups.SelectedItem.Value, QueryMembership.Expanded);
            if (sids == null || sids.Members.Length == 0)
            {
                ListAllMembers.DataSource = null;
                return;
            }
            ListAllMembers.DataSource = _gss.ReadIdentities(SearchFactor.Sid, sids.Members, QueryMembership.None);
            ListAllMembers.DataBind();
            List<ListItem> list5 = new List<ListItem>(ListAllMembers.Items.Cast<ListItem>());
            //sort list item alphabetixcally
            list5 = list5.OrderBy(x => x.Text).ToList<ListItem>();
            ListAllMembers.Items.Clear();
            ListAllMembers.Items.AddRange(list5.ToArray<ListItem>());
        }

        //kullanıcıyı gruba ekle butonu
        protected void BtnAddUserToGroupClick(object sender, EventArgs e)
        {
            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            _gss = (IGroupSecurityService)server.GetService<IGroupSecurityService>();
            if (ListAllUsers.SelectedItem == null || AllGroups.SelectedItem == null) return;
            try
            {
                _gss.AddMemberToApplicationGroup(AllGroups.SelectedItem.Value, ListAllUsers.SelectedItem.Value);
                AllGroupsSelectedChanged(sender, null);
            }
            catch (Exception ex)
            {
            }
        }

        //kullanıcıyı gruptan silme butonu
        protected void BtnRemoveUserFromGroupClick(object sender, EventArgs e)
        {
            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            _gss = (IGroupSecurityService)server.GetService<IGroupSecurityService>();
            if (ListAllMembers.SelectedItem == null || AllGroups.SelectedItem == null) return;
            _gss.RemoveMemberFromApplicationGroup(AllGroups.SelectedItem.Value, ListAllMembers.SelectedItem.Value);
            AllGroupsSelectedChanged(sender, null);
        }

        //grup ekle butonu
        protected void BtnAddGroup_Click(object sender, EventArgs e)
        {

            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            _gss = (IGroupSecurityService)server.GetService<IGroupSecurityService>();
            if (string.IsNullOrEmpty(txtGroupName.Text)) return;
            server.Authenticate();
            NetworkCredential myNetCredentials = new NetworkCredential(config.UserName, config.Password, config.Domain);
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(config.ServerName), myNetCredentials);
            _css = tpc.GetService<ICommonStructureService>();
            var service = server.GetService<TswaClientHyperlinkService>();
            var projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(config.ServerName));
            var cssService = projectCollection.GetService<ICommonStructureService3>();
            var project = cssService.GetProjectFromName(config.Project);
            var home = service.GetHomeUrl(new Uri(project.Uri));
            string prjuri = project.Uri;
            var groupname = txtGroupName.Text;
            try
            {
                var result = _gss.CreateApplicationGroup(prjuri, groupname, "Your Group Description");
                AllGroups.Items.Add(result);
                BindData();
            }
            catch (Exception ex)
            {
            }
        }
        //grup silme butonu
        protected void BtnRemoveGroupClick(object sender, EventArgs e)
        {
            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            _gss = (IGroupSecurityService)server.GetService<IGroupSecurityService>();
            if (AllGroups.SelectedItem == null) return;
            _gss.DeleteApplicationGroup(AllGroups.SelectedItem.Value);
            BindData();
        }

        //yazılımcı/müşteri ekle
        protected void SaveUserClick(object sender, EventArgs e)
        {
            if (YzlAdd.Checked == false && MstAdd.Checked == false) return;
            if (YzlAdd.Checked == true)
            {
                TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
                System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
                Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
                _gss = (IGroupSecurityService)server.GetService<IGroupSecurityService>();
                NetworkCredential myNetCredentials = new NetworkCredential(config.UserName, config.Password, config.Domain);
                ICredentials myCredentials = (ICredentials)myNetCredentials;
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(config.ServerName), myNetCredentials);
                const string projectName = "Default Collection";
                const string groupName = "Project Administrators";
                const string projectUri = "<<TFS PROJECT COLLECTION>>";
                TfsTeamProjectCollection projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://10.35.104.27:8080/tfs/defaultcollection"));
                ICommonStructureService css = (ICommonStructureService)projectCollection.GetService(typeof(ICommonStructureService));
                IGroupSecurityService gss = projectCollection.GetService<IGroupSecurityService>();

                // get the tfs project
                var projectList = css.ListAllProjects();
                var project = projectList.FirstOrDefault(o => o.Name.Contains(config.Project));
                // project doesn't exist
                if (project == null) return;
                // get the tfs group
                var groupList = gss.ListApplicationGroups(null);
                if (AllUsersDown.SelectedItem == null) return;
                try
                {
                    //Arkas Holding Yeni Kullanıcı   
                    if (!_gss.IsMember("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-2558778465-1744192584-2786095430-1642773759", AllUsersDown.SelectedItem.Value))
                    { _gss.AddMemberToApplicationGroup("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-2558778465-1744192584-2786095430-1642773759", AllUsersDown.SelectedItem.Value); }
                    
                    //Bimar YG Departmanı          
                    if (!_gss.IsMember("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-3792407965-21261647-3085318828-2147828389", AllUsersDown.SelectedItem.Value))                                    
                    { _gss.AddMemberToApplicationGroup("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-3792407965-21261647-3085318828-2147828389", AllUsersDown.SelectedItem.Value); }
                    //SW Development Team    
                    if (!_gss.IsMember("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-2939572628-669194053-2828883337-590241807", AllUsersDown.SelectedItem.Value))
                    { _gss.AddMemberToApplicationGroup("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-2939572628-669194053-2828883337-590241807", AllUsersDown.SelectedItem.Value); }

                    //Project SW Development Team
                    foreach (ListItem item in Project2.Items)
                    {
                        if (item.Selected)
                        {
                            string sID = "";
                            string projectvalue = item.Value.ToString();
                            var groupList2 = _gss.ListApplicationGroups(projectvalue);
                            for (int i = 0; i < groupList2.Count(); i++)
                            {
                                if (groupList2[i].DisplayName == "Project SW Development Team")
                                {
                                    sID = groupList2[i].Sid;
                                }
                            }
                            if (!_gss.IsMember(sID, AllUsersDown.SelectedItem.Value))
                            { _gss.AddMemberToApplicationGroup(sID, AllUsersDown.SelectedItem.Value); }
                        }
                    }
                }
                catch (Exception ex)
                {                  
                }
            }
            if (MstAdd.Checked == true)
            {
                TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
                System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
                Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
                _gss = (IGroupSecurityService)server.GetService<IGroupSecurityService>();
                NetworkCredential myNetCredentials = new NetworkCredential(config.UserName, config.Password, config.Domain);
                ICredentials myCredentials = (ICredentials)myNetCredentials;
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(config.ServerName), myNetCredentials);
                const string projectName = "Default Collection";
                const string groupName = "Project Administrators";
                const string projectUri = "<<TFS PROJECT COLLECTION>>";
                TfsTeamProjectCollection projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://10.35.104.27:8080/tfs/defaultcollection"));
                ICommonStructureService css = (ICommonStructureService)projectCollection.GetService(typeof(ICommonStructureService));
                IGroupSecurityService gss = projectCollection.GetService<IGroupSecurityService>();
                // get the tfs project
                var projectList = css.ListAllProjects();
                var project = projectList.FirstOrDefault(o => o.Name.Contains(config.Project));
                // project doesn't exist
                if (project == null) return;
                // get the tfs group
                var groupList = gss.ListApplicationGroups(null);
                if (AllUsersDown.SelectedItem == null) return;
                //if (YzlAdd.Checked == true || MstAdd.Checked == true) return;
                try
                {
                    //Arkas Holding Yeni Kullanıcı
                    _gss.AddMemberToApplicationGroup("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-2558778465-1744192584-2786095430-1642773759", AllUsersDown.SelectedItem.Value);
                }

                catch (Exception ex)
                {                   
                }

            }
        }

        //kullanıcıyı silme
        protected void Button1_Click(object sender, EventArgs e)
        {
             TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
                System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
                Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
                _gss = (IGroupSecurityService)server.GetService<IGroupSecurityService>();
                NetworkCredential myNetCredentials = new NetworkCredential(config.UserName, config.Password, config.Domain);
                ICredentials myCredentials = (ICredentials)myNetCredentials;
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(config.ServerName), myNetCredentials);
                const string projectName = "Default Collection";
                const string groupName = "Project Administrators";
                const string projectUri = "<<TFS PROJECT COLLECTION>>";
                TfsTeamProjectCollection projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://10.35.104.27:8080/tfs/defaultcollection"));
                ICommonStructureService css = (ICommonStructureService)projectCollection.GetService(typeof(ICommonStructureService));
                IGroupSecurityService gss = projectCollection.GetService<IGroupSecurityService>();

                // get the tfs project
                var projectList = css.ListAllProjects();
                var project = projectList.FirstOrDefault(o => o.Name.Contains(config.Project));
                // project doesn't exist
                if (project == null) return;
                // get the tfs group
                var groupList = gss.ListApplicationGroups(null);
                if (AllUsersDown.SelectedItem == null) return;
                try
                {
                    //Arkas Holding Yeni Kullanıcı   
                    if (_gss.IsMember("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-2558778465-1744192584-2786095430-1642773759", AllUsersDown.SelectedItem.Value))
                    { _gss.RemoveMemberFromApplicationGroup("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-2558778465-1744192584-2786095430-1642773759", AllUsersDown.SelectedItem.Value); }

                    //Bimar YG Departmanı          
                    if (_gss.IsMember("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-3792407965-21261647-3085318828-2147828389", AllUsersDown.SelectedItem.Value))
                    { _gss.RemoveMemberFromApplicationGroup("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-3792407965-21261647-3085318828-2147828389", AllUsersDown.SelectedItem.Value); }
                    //SW Development Team    
                    if (_gss.IsMember("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-2939572628-669194053-2828883337-590241807", AllUsersDown.SelectedItem.Value))
                    { _gss.RemoveMemberFromApplicationGroup("S-1-9-1551374245-3746373664-2755988043-2622905486-1821688266-1-2939572628-669194053-2828883337-590241807", AllUsersDown.SelectedItem.Value); }
                    foreach (ListItem item in Project2.Items)
                    {
                        if (item.Selected)
                        {
                            string sID = "";
                            string projectvalue = item.Value.ToString();
                            var groupList2 = _gss.ListApplicationGroups(projectvalue);
                            for (int i = 0; i < groupList2.Count(); i++)
                            {
                                if (groupList2[i].DisplayName == "Project SW Development Team")
                                {
                                    sID = groupList2[i].Sid;
                                }
                            }
                            if (_gss.IsMember(sID, AllUsersDown.SelectedItem.Value))
                            { _gss.RemoveMemberFromApplicationGroup(sID, AllUsersDown.SelectedItem.Value); }
                        }
                    }
                }
                catch
                {
                }
        }

    }
}


