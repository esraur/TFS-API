<%@ Page Language="C#" MasterPageFile="TFSWeb.Master"  AutoEventWireup="true" CodeBehind="ReportBug.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.ReportBug" %>

<asp:Content runat="server" ContentPlaceHolderID="CenterContent" >
    <div style="width: 1400px; margin: 0 auto;">
   <div align="center" class="title"   id="pageTitle">Submit a Bug</div>
        <table  align="center"   border="0" cellspacing="0" width="70%" cellpadding="0" style="height: 598px">
            <tr>
                <td class="label" >Title: 
                <asp:RequiredFieldValidator runat="server" ID="validateTitle" ControlToValidate="BugTitle" Text="*"
                 ErrorMessage="The bug title is required"></asp:RequiredFieldValidator>
                </td>
                <td><asp:TextBox runat="server" id="BugTitle" Width="99%" Height="40"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td class="note"  >The title of the defect should be a short descriptive title
                that helps identify, in simple terms, what the defect is.
                </td>
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>
            <tr>
                <td class="label">Description:
                <asp:RequiredFieldValidator runat="server" ID="validateDescription" ControlToValidate="Description" Text="*"
                 ErrorMessage="The bug description is required"></asp:RequiredFieldValidator>
                </td>
                <td><asp:TextBox TextMode="multiLine" runat="server" ID="Description" Width="99%" Height="100"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td class="note" >Describe the problem in as much detail as possible.  Describe what you 
                observed, what you exepcted to observer, and the stems taken that lead to the problem.
                </td>
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>            
          
            <tr>
                <td class="label" style="height: 50px">Company:</td>
                <td style="height: 50px"><asp:DropDownList runat="Server" ID="Company" Width="410px" Height="16px"></asp:DropDownList></td>
            </tr>


            <tr>
                <td class="label" style="height: 50px">Severity:</td>
                <td style="height: 50px"><asp:DropDownList runat="Server" ID="Severity" Width="200"></asp:DropDownList></td>
            </tr>
            <tr><td colspan="2">
            <asp:ValidationSummary runat="server" ID="Summary" />&nbsp;
            </td></tr>
            <tr><td></td>
            <td><asp:Button runat="server" ID="Submit" Text="Submit" CssClass="button" OnClick="SubmitIssue" />
                &nbsp;
                <asp:Button runat="server" ID="Cancel" OnClientClick="window.location.href='IssuesList.aspx';return false;" Text="Cancel" CssClass="button" />
            </td></tr>
        </table> </div>
</asp:Content>
