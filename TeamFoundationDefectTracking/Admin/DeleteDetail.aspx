<%@ Page Language="C#" MasterPageFile="~/TFSWeb.Master" AutoEventWireup="true" CodeBehind="Admin/DeleteDetail.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.DeleteDetail" Title="Delete Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <div class="title" align="center">Delete Detail</div>
    <table align="center" border="1" cellpadding="1" cellspacing="1">

        <tr>
            <td class="label" style="width: 141px">TFS No:</td>
            <td class="dataGrid" style="width: 144px">
                <asp:Literal runat="server" ID="Id" /></td>
        </tr>
       
        <tr>
            <td class="label" style="width: 141px">Title:</td>
            <td class="dataGrid" style="width: 144px">
                <asp:Literal runat="server" ID="title" /></td>
        </tr>
       
        <tr>
            <td class="label" style="width: 141px; height: 25px;">Status:</td>
            <td class="dataGrid" style="width: 144px; height: 25px;">
                <asp:Literal runat="server" ID="status" /></td>
        </tr>
        
        <tr>
            <td class="label" style="width: 141px">Triage:</td>
            <td class="dataGrid" style="width: 144px">
                <asp:Literal runat="server" ID="triage" /></td>
        </tr>
        
        <tr>
            <td class="label"valign="top" style="width: 141px">Description:</td>
            <td class="dataGrid" style="width: 144px">
                <asp:Literal runat="server" ID="description" /></td>
        </tr>    
       
       
        <tr>
            <td class="label"  valign="top" style="width: 141px; height: 25px">History:</td>
            <td class="dataGrid" style="width: 144px; height: 25px">
                <asp:Literal runat="server" ID="history" /></td>
        </tr>
    </table>

     <br />
&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="DELETE" />
        <br />

</asp:Content>