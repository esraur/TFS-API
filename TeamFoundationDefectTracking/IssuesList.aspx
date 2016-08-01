<%@ Page Language="C#" MasterPageFile="TFSWeb.Master" AutoEventWireup="true" CodeBehind="IssuesList.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.IssuesList" %>

<asp:Content runat="server" ContentPlaceHolderID="CenterContent" >
    <div class="title2" id="pageTittle2" style="width: 0 auto; margin-right: 0 auto; text-align: right">
        <a href="Admin/UserList.aspx" style="" class="btn btn-default">User List </a>
        <a href="Yonetici/Yonetici.aspx" class="btn btn-default">Yönetici</a>
        <a href="Admin/DeleteWorkItem.aspx" class="btn btn-default">DeleteWorkItem</a>
        <a href="Yonetici/Listeleme.aspx" class="btn btn-default">WorkItemHistory</a>
        <a href="Admin/GroupOperations.aspx" class="btn btn-default">GroupOperations</a>

    </div>

    <div style="width:100%;height:100%; margin: 0px 0px; text-align: center">
        <div class="title" id="pageTitle">Issue List</div>
        <div id="tools">
            <link href="css/bootstrap.css" rel="stylesheet" />
            <a href="ReportBug.aspx" class="btn btn-default">Report a Bug</a>
            <a href="RequestChange.aspx" class="btn btn-default">Request a Change</a>
            <p></p>
        </div>




        <asp:GridView ID="GridView1" CssClass="grid" runat="server" AutoGenerateColumns="False" Width="1186px">
            <Columns>

                <asp:TemplateField ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="orcun" HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server"
                            Text='<%#DataBinder.Eval(Container.DataItem,"ID")%>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="orcun" HeaderText="Type">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server"
                            Text='<%#DataBinder.Eval(Container.DataItem,"Type.Name")%>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="30px" HeaderStyle-CssClass="orcun" ItemStyle-HorizontalAlign="Left" HeaderText="Title">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server">                            
                        <a href="Details.aspx?IssueID=<%#DataBinder.Eval(Container.DataItem,"Id") %>"><%#DataBinder.Eval(Container.DataItem,"Title") %>  </a>                      
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="orcun" HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server">
                        <%#DataBinder.Eval(Container.DataItem,"State") %></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="orcun" HeaderText="Severity">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server">                        
                    <%#DataBinder.Eval(Container.DataItem,"Type.Name").ToString()=="Change Request" ? "" : DataBinder.Eval(Container.DataItem,"Fields['Severity'].Value").ToString() %>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="orcun" HeaderText="Submitted On">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server">
                        <%#DataBinder.Eval(Container.DataItem,"CreatedDate")%>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
