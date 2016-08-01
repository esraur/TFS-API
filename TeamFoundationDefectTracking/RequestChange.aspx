<%@ Page Language="C#" MasterPageFile="TFSWeb.Master" AutoEventWireup="true" CodeBehind="RequestChange.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.RequestChange" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="CenterContent">
    <div style="width: 1400px; margin: 0 auto;">
   <div class="title" align="center">Submit a Change Request</div>
    
         <table  align="center"   border="0" cellspacing="0" cellpadding="0" style="height: 598px; width: 85%;">
            <tr>
                <td class="label">Title:
                <asp:RequiredFieldValidator runat="server" ID="validateTitle" ControlToValidate="ChangeTitle" Text="*"
                 ErrorMessage="The requst title is required"></asp:RequiredFieldValidator>
                </td>
                <td><asp:TextBox  runat="server" id="ChangeTitle" Width="99%" Height="40"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td class="note" >The title of the change request should be a short descriptive title
                that helps identify, in simple terms, what the request is.
                </td>
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>
            <tr>
                <td class="label">Description:
                <asp:RequiredFieldValidator runat="server" ID="validateDescription" ControlToValidate="Description" Text="*"
                 ErrorMessage="The request description is required"></asp:RequiredFieldValidator>
                </td>
                <td><asp:TextBox  TextMode="multiLine" runat="server" ID="Description" Width="99%" Height="100"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td class="note" >Describe the change request in as much detail as possible.
                </td>
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>                                  
                     
               <tr>
                <td class="label" style="height: 50px">Company:</td>
                <td style="height: 50px"><asp:DropDownList runat="Server" ID="Company" Width="410px" AppendDataBoundItems="True" Height="16px"></asp:DropDownList></td>
            </tr>
            <tr><td></td>
            <td><asp:Button runat="server" ID="Submit" Text="Submit" CssClass="button" OnClick="SubmitIssue" />
                &nbsp;
                <asp:Button runat="server" ID="Cancel" OnClientClick="window.location.href='IssuesList.aspx';return false;" Text="Cancel" CssClass="button" />
            </td></tr>
        </table> </div>
</asp:Content>
