<%@ Page Title="" Language="C#" MasterPageFile="~/TFSWeb.Master" AutoEventWireup="true" CodeBehind="Admin/DeleteWorkItem.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <p>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SEARCH By ID" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            <Columns>

            <asp:TemplateField ItemStyle-Width="30px" HeaderText="Type">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server"
                        Text='<%#DataBinder.Eval(Container.DataItem,"Type.Name")%>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="30px" HeaderText="Title">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server">
                        <a href="DeleteDetail.aspx?DeleteID=<%#DataBinder.Eval(Container.DataItem,"Id") %>"><%#DataBinder.Eval(Container.DataItem,"Title") %>  </a>                      
                    </asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="30px" HeaderText="Id">
               
                     <ItemTemplate>
                    <asp:Label ID="lblID1" runat="server"
                        Text='<%#DataBinder.Eval(Container.DataItem,"Id")%>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        </asp:GridView>
        <br />
        <br />
    </p>
</asp:Content>
