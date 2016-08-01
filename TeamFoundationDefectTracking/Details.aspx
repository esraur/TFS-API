<%@ Page Language="C#" MasterPageFile="TFSWeb.Master" AutoEventWireup="true" CodeBehind="ChangeDetail.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.ChangeDetail" Title="Change Request Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CenterContent" runat="server">
    <div style="margin: 0 auto; width: 1400px; align-items: center">
        <div align="center" class="title">Change Request & Bug Detail</div>
        <table align="center" border="1">
            <tr>
                <td class="label" style="width: 141px">TFS No:</td>
                <td class="dataGrid" style="width: 144px">
                    <asp:Literal runat="server" ID="Id" /></td>
            </tr>

            <tr>
                <td class="label">Title:</td>
                <td class="dataGrid">
                    <asp:Literal runat="server" ID="title" /></td>
            </tr>

            <tr>
                <td class="label">Status:</td>
                <td class="dataGrid">
                    <asp:Literal runat="server" ID="status" /></td>
            </tr>

            <tr>
                <td class="label" style="height: 26px">Triage:</td>
                <td class="dataGrid" style="height: 26px">
                    <asp:Literal runat="server" ID="triage" /></td>
            </tr>

            <tr>
                <td class="label">Description:</td>
                <td class="dataGrid">
                    <asp:Literal runat="server" ID="description" /></td>
            </tr>

            <tr>
                <td class="label">Company:</td>
                <td class="dataGrid">
                    <asp:Literal runat="server" ID="Company" /></td>
            </tr>
            <tr>
                <td class="label">History:</td>
                <td class="dataGrid">
                    <asp:Literal runat="server" ID="history" /></td>
            </tr>


        </table>
    </div>
</asp:Content>

