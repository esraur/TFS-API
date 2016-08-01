using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.Caching;
using System.Xml;
using System.Net;
using System.IO;
using System.Windows.Markup;

namespace CognitiveSoftware.TeamFoundation.Integration.Yonetici
{
    public partial class Yonetici : System.Web.UI.Page
    {
        private TfsTeamProjectCollection _tfs;
        private WorkItemStore store;


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string secim = TextBox23.Text;
            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            server.Authenticate();
            NetworkCredential myNetCredentials = new NetworkCredential(config.UserName, config.Password, config.Domain);
            ICredentials myCredentials = (ICredentials)myNetCredentials;
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(config.ServerName), myNetCredentials);
            _tfs = tpc;
            //WorkItemStoreFlags - Enum used to determine behavior of work item store object
            store = new WorkItemStore(_tfs, WorkItemStoreFlags.BypassRules);

            var service = server.GetService<WorkItemStore>();
            int a = Convert.ToInt32(secim);
            var wi = store.GetWorkItem(a);
            var dataTable = new DataTable();
            foreach (Field field in wi.Fields)
            {
                dataTable.Columns.Add(field.Name);

            }
            foreach (Revision revision in wi.Revisions)
            {
                var row = dataTable.NewRow();
                foreach (Field field in wi.Fields)
                {
                    row[field.Name] = revision.Fields[field.Name].Value;
                }
                dataTable.Rows.Add(row);
            }
            DataColumnCollection columns = dataTable.Columns;
            DataRowCollection Rows = dataTable.Rows;

            foreach (DataColumn dr in dataTable.Columns)
            {
                if (dr.ColumnName == "Title")
                {
                    if (wi.Fields["Title"].Value == null)
                    {
                        TextBox1.Text = string.Empty;
                    }
                    else
                    {
                        TextBox1.Text = wi.Title;
                    }
                }
                if (dr.ColumnName == "G/O")
                {
                    if (wi.Fields["G/O"].Value == null)
                    {
                        TextBox19.Text = string.Empty;
                    }
                    else
                    {
                        TextBox19.Text = wi.Fields["G/O"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Assigned To")
                {
                    if (wi.Fields["Assigned To"].Value == null)
                        TextBox13.Text = string.Empty;
                    else
                    {
                        TextBox13.Text = wi.Fields["Assigned To"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Resolved Reason")
                {
                    if (wi.Fields["Resolved Reason"].Value == null)
                    {
                        TextBox4.Text = string.Empty;
                    }
                    else
                    {
                        TextBox4.Text = wi.Fields["Resolved Reason"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Triage")
                {
                    if (wi.Fields["Triage"].Value == null)
                    {
                        TextBox10.Text = string.Empty;
                    }
                    else
                    {
                        TextBox10.Text = wi.Fields["Triage"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Severity")
                {
                    if (wi.Fields["Severity"].Value == null)
                    {
                        TextBox18.Text = string.Empty;
                    }
                    else
                    {
                        TextBox18.Text = wi.Fields["Severity"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "State")
                {
                    if (wi.Fields["State"].Value == null)
                    {
                        TextBox12.Text = string.Empty;
                    }
                    else
                    {
                        TextBox12.Text = wi.State;
                    }
                }
                if (dr.ColumnName == "Area Path")
                {
                    if (wi.Fields["Area Path"].Value == null)
                    {
                        TextBox16.Text = string.Empty;
                    }
                    else
                    {
                        TextBox16.Text = wi.AreaPath;
                    }
                }
                if (dr.ColumnName == "Iteration Path")
                {
                    if (wi.Fields["Iteration Path"].Value == null)
                    {
                        TextBox14.Text = string.Empty;
                    }
                    else
                    {
                        TextBox14.Text = wi.IterationPath;
                    }
                }
                if (dr.ColumnName == "Priority")
                {
                    if (wi.Fields["Priority"].Value == null)
                    {
                        TextBox17.Text = string.Empty;
                    }
                    else
                    {
                        TextBox17.Text = wi.Fields["Priority"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Ordering")
                {
                    if (wi.Fields["Ordering"].Value == null)
                    {
                        TextBox2.Text = string.Empty;
                    }
                    else
                    {
                        TextBox2.Text = wi.Fields["Ordering"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Integration")
                {
                    if (wi.Fields["Integration"].Value == null)
                    {
                        TextBox20.Text = string.Empty;
                    }
                    else
                    {
                        TextBox20.Text = wi.Fields["Integration"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Platform")
                {
                    if (wi.Fields["Platform"].Value == null)
                    {
                        TextBox15.Text = string.Empty;
                    }
                    else
                    {
                        TextBox15.Text = wi.Fields["Platform"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "ReportStatus")
                {
                    if (wi.Fields["ReportStatus"].Value == null)
                    {
                        TextBox11.Text = string.Empty;
                    }
                    else
                    {
                        TextBox11.Text = wi.Fields["ReportStatus"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Reason")
                {
                    if (wi.Fields["Reason"].Value == null)
                    {
                        TextBox3.Text = string.Empty;
                    }
                    else
                    {
                        TextBox3.Text = wi.Fields["Reason"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Estimated Duration")
                {
                    if (wi.Fields["Estimated Duration"].Value == null)
                    {
                        TextBox5.Text = string.Empty;
                    }
                    else
                    {
                        TextBox5.Text = wi.Fields["Estimated Duration"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Original Estimate")
                {
                    if (wi.Fields["Original Estimate"].Value == null)
                    {
                        TextBox7.Text = string.Empty;
                    }
                    else
                    {
                        TextBox7.Text = wi.Fields["Original Estimate"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Completed Work")
                {

                    if (wi.Fields["Completed Work"].Value == null)
                    {
                        TextBox6.Text = string.Empty;
                    }
                    else
                    {

                        TextBox6.Text = wi.Fields["Completed Work"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Overtime Work Duration")
                {
                    if (wi.Fields["Overtime Work Duration"].Value == null)
                    {
                        TextBox2.Text = string.Empty;
                    }
                    else
                    {
                        TextBox9.Text = wi.Fields["Overtime Work Duration"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Finish Date")
                {
                    if (wi.Fields["Finish Date"].Value == null)
                    {
                        TextBox8.Text = null;
                    }
                    else
                    {
                        TextBox8.Text = wi.Fields["Finish Date"].Value.ToString().Substring(0, 10);
                    }
                }
                if (dr.ColumnName == "Company Of Customer")
                {
                    if (wi.Fields["Company Of Customer"].Value == null)
                    {
                        TextBox21.Text = string.Empty;
                    }
                    else
                    {
                        TextBox21.Text = wi.Fields["Company Of Customer"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Customer Of Request")
                {
                    if (wi.Fields["Customer Of Request"].Value == null)
                    {
                        TextBox22.Text = string.Empty;
                    }
                    else
                    {
                        TextBox22.Text = wi.Fields["Customer Of Request"].Value.ToString();
                    }
                }
                if (dr.ColumnName == "Description")
                {
                    if (wi.Fields["Description"].Value == null)
                    {
                        editor2.Text = string.Empty;
                    }
                    else
                    {
                        editor2.Text = wi.Fields["Description"].Value.ToString();
                    }
                }
            }

        }


        //SAVE BUTTON
        protected void Button3_Click(object sender, EventArgs e)
        {
            TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
            System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
            Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
            server.Authenticate();
            NetworkCredential myNetCredentials = new NetworkCredential(config.UserName, config.Password, config.Domain);
            ICredentials myCredentials = (ICredentials)myNetCredentials;
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri(config.ServerName), myNetCredentials);


            _tfs = tpc;
            //WorkItemStoreFlags - Enum used to determine behavior of work item store object
            store = new WorkItemStore(_tfs, WorkItemStoreFlags.BypassRules);

            string secim = TextBox23.Text;
            int a = Convert.ToInt32(secim);
            WorkItem workItem = store.GetWorkItem(a);


            workItem.Open();

            if (workItem.Type.Name == "Change Request")
            {
                workItem.Fields["Title"].Value = TextBox1.Text;

                if (TextBox19.Text == "")
                {
                    workItem.Fields["G/O"].Value = null;
                }
                else
                {
                    workItem.Fields["G/O"].Value = TextBox19.Text;
                }

                workItem.Fields["Assigned To"].Value = TextBox13.Text;

                if (TextBox4.Text == "")
                {
                    workItem.Fields["Resolved Reason"].Value = null;
                }
                else
                {
                    workItem.Fields["Resolved Reason"].Value = TextBox4.Text;
                }

                if (TextBox22.Text == "")
                {
                    workItem.Fields["Customer Of Request"].Value = null;
                }
                else
                {
                    workItem.Fields["Customer Of Request"].Value = TextBox22.Text;
                }

                if (TextBox21.Text == "")
                {
                    workItem.Fields["Company Of Customer"].Value = null;
                }
                else
                {
                    workItem.Fields["Company Of Customer"].Value = TextBox21.Text;
                }

                if (TextBox8.Text == "")
                {
                    workItem.Fields["Finish Date"].Value = null;
                }
                else
                {
                    workItem.Fields["Finish Date"].Value = TextBox8.Text;
                }


                if (TextBox9.Text == "")
                {
                    workItem.Fields["Overtime Work Duration"].Value = null;
                }
                else
                {
                    workItem.Fields["Overtime Work Duration"].Value = TextBox9.Text;
                }


                if (TextBox6.Text == "")
                {
                    workItem.Fields["Completed Work"].Value = null;
                }
                else
                {
                    workItem.Fields["Completed Work"].Value = TextBox6.Text;
                }


                if (TextBox7.Text == "")
                {
                    workItem.Fields["Original Estimate"].Value = null;
                }
                else
                {
                    workItem.Fields["Original Estimate"].Value = TextBox7.Text;
                }

                if (TextBox5.Text == "")
                {
                    workItem.Fields["Estimated Duration"].Value = null;
                }
                else
                {
                    workItem.Fields["Estimated Duration"].Value = TextBox5.Text;
                }

                if (TextBox3.Text == "")
                {
                    workItem.Fields["Reason"].Value = null;
                }
                else
                {
                    workItem.Fields["Reason"].Value = TextBox3.Text;
                }

                if (TextBox11.Text == "")
                {
                    workItem.Fields["ReportStatus"].Value = null;
                }
                else
                {
                    workItem.Fields["ReportStatus"].Value = TextBox11.Text;
                }

                if (TextBox15.Text == "")
                {
                    workItem.Fields["Platform"].Value = null;
                }
                else
                {
                    workItem.Fields["Platform"].Value = TextBox15.Text;
                }

                if (TextBox20.Text == "")
                {
                    workItem.Fields["Integration"].Value = null;
                }
                else
                {
                    workItem.Fields["Integration"].Value = TextBox20.Text;
                }

                if (TextBox2.Text == "")
                {
                    workItem.Fields["Ordering"].Value = null;
                }
                else
                {
                    workItem.Fields["Ordering"].Value = TextBox2.Text;
                }

                if (TextBox17.Text == "")
                {
                    workItem.Fields["Priority"].Value = null;
                }
                else
                {
                    workItem.Fields["Priority"].Value = TextBox17.Text;
                }

                if (TextBox14.Text == "")
                {
                    workItem.Fields["Iteration Path"].Value = null;
                }
                else
                {
                    workItem.Fields["Iteration Path"].Value = TextBox14.Text;
                }



                if (TextBox16.Text == "")
                {
                    workItem.Fields["Area Path"].Value = null;
                }
                else
                {
                    workItem.Fields["Area Path"].Value = TextBox16.Text;
                }

                if (TextBox12.Text == "")
                {
                    workItem.Fields["State"].Value = null;
                }
                else
                {
                    workItem.Fields["State"].Value = TextBox12.Text;
                }

                if (TextBox18.Text == "")
                {
                    workItem.Fields["Severity"].Value = null;
                }
                else
                {
                    workItem.Fields["Severity"].Value = TextBox18.Text;
                }

                if (TextBox10.Text == "")
                {
                    workItem.Fields["Triage"].Value = null;
                }
                else
                {
                    workItem.Fields["Triage"].Value = TextBox10.Text;
                }
                if (editor2.Text != "")
                {
                    workItem.Fields["Description"].Value = editor2.Text;
                }
                else {
                    workItem.Fields["Description"].Value = null;
                }

            }
            else
            {
                workItem.Fields["Title"].Value = TextBox1.Text;
                workItem.Fields["Assigned To"].Value = TextBox13.Text;

                if (TextBox4.Text == "")
                {
                    workItem.Fields["Resolved Reason"].Value = null;
                }
                else
                {
                    workItem.Fields["Resolved Reason"].Value = TextBox4.Text;
                }
                if (TextBox22.Text == "")
                {
                    workItem.Fields["Customer Of Request"].Value = null;
                }
                else
                {
                    workItem.Fields["Customer Of Request"].Value = TextBox22.Text;
                }

                if (TextBox21.Text == "")
                {
                    workItem.Fields["Company Of Customer"].Value = null;
                }
                else
                {
                    workItem.Fields["Company Of Customer"].Value = TextBox21.Text;
                }


                if (TextBox21.Text == "")
                {
                    workItem.Fields["Company Of Customer"].Value = null;
                }
                else
                {
                    workItem.Fields["Company Of Customer"].Value = TextBox21.Text;
                }

                if (TextBox8.Text == "")
                {
                    workItem.Fields["Finish Date"].Value = null;
                }
                else
                {
                    workItem.Fields["Finish Date"].Value = TextBox8.Text;
                }


                if (TextBox9.Text == "")
                {
                    workItem.Fields["Overtime Work Duration"].Value = null;
                }
                else
                {
                    workItem.Fields["Overtime Work Duration"].Value = TextBox9.Text;
                }


                if (TextBox6.Text == "")
                {
                    workItem.Fields["Completed Work"].Value = null;
                }
                else
                {
                    workItem.Fields["Completed Work"].Value = TextBox6.Text;
                }

                if (TextBox7.Text == "")
                {
                    workItem.Fields["Original Estimate"].Value = null;
                }
                else
                {
                    workItem.Fields["Original Estimate"].Value = TextBox7.Text;
                }

                if (TextBox5.Text == "")
                {
                    workItem.Fields["Estimated Duration"].Value = null;
                }
                else
                {
                    workItem.Fields["Estimated Duration"].Value = TextBox5.Text;
                }
                if (TextBox15.Text == "")
                {
                    workItem.Fields["Platform"].Value = null;
                }
                else
                {
                    workItem.Fields["Platform"].Value = TextBox15.Text;
                }

                if (TextBox20.Text == "")
                {
                    workItem.Fields["Integration"].Value = null;
                }
                else
                {
                    workItem.Fields["Integration"].Value = TextBox20.Text;
                }

                if (TextBox2.Text == "")
                {
                    workItem.Fields["Ordering"].Value = null;
                }
                else
                {
                    workItem.Fields["Ordering"].Value = TextBox2.Text;
                }

                if (TextBox17.Text == "")
                {
                    workItem.Fields["Priority"].Value = null;
                }
                else
                {
                    workItem.Fields["Priority"].Value = TextBox17.Text;
                }

                if (TextBox14.Text == "")
                {
                    workItem.Fields["Iteration Path"].Value = null;
                }
                else
                {
                    workItem.Fields["Iteration Path"].Value = TextBox14.Text;
                }



                if (TextBox16.Text == "")
                {
                    workItem.Fields["Area Path"].Value = null;
                }
                else
                {
                    workItem.Fields["Area Path"].Value = TextBox16.Text;
                }

                if (TextBox12.Text == "")
                {
                    workItem.Fields["State"].Value = null;
                }
                else
                {
                    workItem.Fields["State"].Value = TextBox12.Text;
                }

                if (TextBox18.Text == "")
                {
                    workItem.Fields["Severity"].Value = null;
                }
                else
                {
                    workItem.Fields["Severity"].Value = TextBox18.Text;
                }

                if (TextBox10.Text == "")
                {
                    workItem.Fields["Triage"].Value = null;
                }
                else
                {
                    workItem.Fields["Triage"].Value = TextBox10.Text;
                }
                if (editor2.Text != "")
                {
                    workItem.Fields["Description"].Value = editor2.Text;
                }
                else
                {
                    workItem.Fields["Description"].Value = null;
                }

            }
            if (workItem.IsValid())
            {
                workItem.Save();
            }
            else
            {

            }
        }

        //        protected void Button3_Click(object sender, EventArgs e)
        //        {
        //            string file = @"<Window x:Class=""WpfApplication1.MainWindow""
        //        xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
        //        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        //        Title=""MainWindow"" Height=""350"" Width=""525"">
        //    <Grid x:Name=""Content"">
        //
        //
        //    </Grid>
        //</Window>";

        //            var doc = XDocument.Load(new StringReader(file));
        //            XNamespace xmlns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
        //            XNamespace x = "http://schemas.microsoft.com/winfx/2006/xaml";
        //            var gridElement = doc.Root.Elements(xmlns + "Grid").Where(p => p.Attribute(x + "Name") != null && p.Attribute(x + "Name").Value == "Content");

        //            StringReader stringReader = new StringReader(Button3);
        //            XmlReader xmlReader = XmlReader.Create(stringReader);
        //            Button readerLoadButton = (Button)XamlReader.Load(xmlReader);
        //        }
    }

}


