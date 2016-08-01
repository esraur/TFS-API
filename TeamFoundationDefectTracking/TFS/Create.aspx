<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" ValidateRequest="false" Inherits="CognitiveSoftware.TeamFoundation.Integration.TFS.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/yonetici.css" rel="stylesheet" />
    <script src="../ckeditor/ckeditor.js"></script>
    <style>
        .dropdownorcun {
            height: auto;
            width: 410px;
            color: black;
            text-align: left;
        }

        .tdsol {
            text-align: left;
        }
        .isim {
            color:black;
            font-size:12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center" class="title" id="pageTitle" style="margin-top: 100px">
            <div style="margin-top: 0px; margin-bottom: 10px; float: right; padding-bottom: 50px; padding-right: 20px; position: relative; top: -79px; left: -103px;">
                <asp:Label ID="Label1" runat="server" EnableTheming="false" CssClass="isim" ></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="DefaultDilYukle2">TR</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="EngDilYukle2" OnClientClick="EngDilYukle2">EN</asp:LinkButton>

            </div>
            <table border="0" id="esra" style="height: 598px">
                <tr>
                    <td class="label" id="type2" runat="server"></td>
                    <td style="margin-bottom: 10px" class="tdsol">
                        <asp:DropDownList runat="Server" ID="TypeDropdown" EnableTheming="false" CssClass="dropdownorcun">
                            <asp:ListItem runat="server" id="bug" Value="Bug"></asp:ListItem>
                            <asp:ListItem runat="server" id="changereq" Value="Change Request"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>

                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="label" runat="server" id="project2" style="height: 50px"></td>
                    <td style="height: 70px; margin-top: 0px" class="tdsol">
                        <asp:DropDownList runat="Server" ID="AreaPath" EnableTheming="false" CssClass="dropdownorcun">
                            <asp:ListItem Text="YNA" Value="YNA"></asp:ListItem>
                            <asp:ListItem Text="ARLES" Value="ARLES"></asp:ListItem>
                            <asp:ListItem Text="YNL" Value="YNL"></asp:ListItem>
                            <asp:ListItem Text="EDS" Value="EDS"></asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="label" runat="server" id="severity2" style="height: 50px"></td>
                    <td style="height: 50px" class="tdsol">
                        <asp:DropDownList runat="Server" CssClass="dropdownorcun" ID="Severity" EnableTheming="false"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary runat="server" ID="Summary" />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="label" runat="server" id="title2">
                        <asp:RequiredFieldValidator runat="server" ID="validateTitle" ControlToValidate="BugTitle" Text="*"
                            ErrorMessage="The bug title is required"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="BugTitle" Width="99%" Height="40"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="note">The title of the defect should be a short descriptive title
                that helps identify, in simple terms, what the defect is.
                    </td>
                </tr>
                <tr>
                    <td class="label" runat="server" id="description2">
                        <asp:RequiredFieldValidator runat="server" ID="validateDescription" ControlToValidate="Description" Text="*"
                            ErrorMessage="The bug description is required"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox TextMode="multiLine" runat="server" ID="Description" Width="99%" Height="100"></asp:TextBox></td>
                    <script>
                        // Replace the <textarea id="editor1"> with a CKEditor
                        // instance, using default configuration.

                        CKEDITOR.replace('Description');
                    </script>
                </tr>
                <tr>
                    <td></td>
                    <td class="note">Describe the problem in as much detail as possible.  Describe what you 
                observed, what you exepcted to observer, and the stems taken that lead to the problem.
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align: center">
<%--                        <button type="submit" runat="server" class="btn btn-default" id="Submit" onclick="Save"></button>--%>
                        <asp:Button ID="Submit" runat="server" Text="Save" OnClick="Save" CssClass="btn btn-default"/>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
