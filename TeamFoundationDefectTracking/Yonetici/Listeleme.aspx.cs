using System.Diagnostics;
using Microsoft.TeamFoundation.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.Framework.Client;
using System.Web.UI.WebControls;

namespace CognitiveSoftware.TeamFoundation.Integration.Yonetici
{
    public partial class Listeleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
 
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
                System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName, config.Password, config.Domain);
                Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName, account);
                server.Authenticate();
                var service = server.GetService<WorkItemStore>();
                int WitemID = Convert.ToInt32(Id.Text);               
                var wi = service.GetWorkItem(WitemID);              
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

           
                dgWiHistory.Width = 500;
                dgWiHistory.Height = 100;
                dgWiHistory.DataSource = dataTable;
                dgWiHistory.DataBind();

                
                dgWiHistory.AutoGenerateColumns = true;
                var visualize = new List<string>() { "Title", "State", "Rev", "Reason", "Iteration Path", "Assigned To", "Effort", "Area Path" };
                ListBox1.Items.Add(String.Format("Work Item: {0}{1}", wi.Id, Environment.NewLine));
                for (int i = 0; i < dgWiHistory.Rows.Count; i++)
                {
                    var currentRow = dgWiHistory.Rows[i];

                    if (i + 1 < dgWiHistory.Rows.Count)
                    {
                        var currentRowPlus1 = dgWiHistory.Rows[i + 1];

                        ListBox1.Items.Add(String.Format("Comparing Revision {0} to {1} {2}", i, i + 1,
                                                          Environment.NewLine));
                        bool title = false;
                        for (int j = 0; j < currentRow.Cells.Count; j++)
                        {
                            if (!title)
                            {
                                ListBox1.Items.Add(
                              String.Format(String.Format("Changed By '{0}' On '{1}'{2}",
                                                           currentRow.Cells[33].Text,
                                                          currentRow.Cells[42].Text, Environment.NewLine)));
                                title = true;
                            }

                            if (visualize.Contains(dataTable.Columns[j].ColumnName))
                            {
                                if (currentRow.Cells[j].Text.ToString() != currentRowPlus1.Cells[j].Text.ToString())
                                {
                                    ListBox1.Items.Add(String.Format("[{0}]: '{1}' => '{2}' {3}",
                                                                     dataTable.Columns[j].ColumnName,
                                                                    currentRow.Cells[j].Text,
                                                                    currentRowPlus1.Cells[j].Text,
                                                                      Environment.NewLine));
                                }
                            }
                        }
                    }


                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Width = 70;
                    e.Row.Cells[i].Wrap = false;
                    DataControlRowType rtype = e.Row.RowType;
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                   
                }
                
            }
            
        }
    }

}