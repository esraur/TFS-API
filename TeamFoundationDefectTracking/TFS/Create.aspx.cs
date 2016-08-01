using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;
using System.Data;
using CognitiveSoftware.TeamFoundation.Integration.Resources;
namespace CognitiveSoftware.TeamFoundation.Integration.TFS
{
    public partial class Create : System.Web.UI.Page
    {
        private TfsTeamProjectCollection _tfs;
        private WorkItemStore store;
        static TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
        static System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
        static Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
        static ICommonStructureService css = (ICommonStructureService)server.GetService(typeof(ICommonStructureService));



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserPrincipal isimsoyisim = UserPrincipal.Current;
                Label1.Text = isimsoyisim.Name;

                if (!IsPostBack)
                {
                    BindData();
                    DefaultDilYukle2(this, new EventArgs());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void BindData()
        {
            try
            {
                Severity.DataSource = DataManager.BugType.FieldDefinitions["Severity"].AllowedValues;
                Severity.DataBind();
                WorkItemStore wis = (WorkItemStore)server.GetService(typeof(WorkItemStore));
                Project teamProject = wis.Projects[config.Project];
                WorkItemType wit = teamProject.WorkItemTypes["Bug"];
                FieldDefinition fd = wit.FieldDefinitions["Company Of Customer"];
                AllowedValuesCollection avc = fd.AllowedValues;

            }
            catch (Exception)
            {

                throw;
            }

        }
        private void Kaydet()
        {
            try
            {
                string kullaniciadi = GetDisplayName();
                UserPrincipal isimsoyisim = UserPrincipal.Current;

                var collection = new TfsTeamProjectCollection(new Uri(config.ServerName), account);
                collection.Authenticate();
                
                var store = new WorkItemStore(collection, WorkItemStoreFlags.BypassRules);
                var secim = AreaPath.SelectedItem.Value;
                var sonuc = "";
                switch (secim)
                {
                    case "YNL":
                        sonuc = "YENI NESIL LOJISTIK (YNL)";
                        break;
                    case "YNA":
                        sonuc = "YENI NESIL ACENTELIK (YNA)";
                        break;
                    case "EDS":
                        sonuc = "Entegre Depo Sistemi (EDS) Projesi";
                        break;
                    default:
                        sonuc = "ARKAS LIMAN ENTEGRE SISTEMI (ARLES)";
                        break;
                }
                var tip = TypeDropdown.SelectedItem.Value;

                if (tip == "BUG")
                {
                    var workItem = new WorkItem(store.Projects[sonuc].WorkItemTypes["Bug"]);
                    workItem.Title = BugTitle.Text;
                    workItem.Fields["Symptom"].Value = Description.Text.Replace("\n", "<br/>");
                    workItem.Fields["Severity"].Value = Severity.SelectedItem.Text;
                    workItem.Fields["Company Of Customer"].Value = "BİMAR BİLGİ İŞLEM HİZMETLERİ A.Ş.";
                    workItem.Fields["Assigned To"].Value = isimsoyisim.DisplayName;
                    workItem.Validate();
                    if (workItem.IsValid())
                    {
                        workItem.Save();
                    }

                }
                else
                {
                    var workItem = new WorkItem(store.Projects[sonuc].WorkItemTypes["Change Request"]);
                    workItem.Title = BugTitle.Text;
                    workItem.Fields["Description"].Value = Description.Text.Replace("\n", "<br/>");
                    workItem.Fields["Severity"].Value = Severity.SelectedItem.Text;
                    workItem.Fields["Company Of Customer"].Value = "BİMAR BİLGİ İŞLEM HİZMETLERİ A.Ş.";
                    workItem.Fields["Assigned To"].Value = isimsoyisim.DisplayName;
                    workItem.Validate();
                    if (workItem.IsValid())
                    {
                        workItem.Save();
                       
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void Save(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    Kaydet();
                    Response.Redirect("../TFS/index.aspx",false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public string GetDisplayName()
        {
            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                UserPrincipal user = UserPrincipal.Current;
                return user.SamAccountName;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DefaultDilYukle2(object sender, EventArgs e)
        {
            type2.InnerText = TR.type2;
            project2.InnerText = TR.project2;
            severity2.InnerText = TR.severity2;
            title2.InnerText = TR.title2;
            description2.InnerText = TR.description2;
            bug.Text = TR.bug;
            changereq.Text = TR.changereq;
           // Submit.InnerText = TR.Submit;
            Submit.Text = TR.Submit;
        }

        protected void EngDilYukle2(object sender, EventArgs e)
        {
            type2.InnerText = EN.type2;
            project2.InnerText = EN.project2;
            severity2.InnerText = EN.severity2;
            title2.InnerText = EN.title2;
            description2.InnerText = EN.description2;
            bug.Text = EN.bug;
            changereq.Text = EN.changereq;
          //  Submit.InnerText = EN.Submit;
            Submit.Text = EN.Submit;
        }

    }
}