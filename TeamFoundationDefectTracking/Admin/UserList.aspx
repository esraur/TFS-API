<%@ Page Title="" Language="C#" MasterPageFile="~/TFSWeb.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.Admin.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <p>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ProjeAdLabel" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </p>
</asp:Content>
