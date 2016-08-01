<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupOperations.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.Admin.GroupOperations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 969px;
            width: 1234px;
        }
       
    </style>

</head>
<body>
    <link href="../css/StyleSheet1.css" rel="stylesheet" />
    <form id="form1" runat="server">

        <div id="ana_div">
            <div class="div" id="div1">
                <asp:Label ID="Label1" runat="server" Text="Gruplar:" Font-Bold="True" Style="margin-top: 1px" ForeColor="Black"></asp:Label>
                <asp:ListBox ID="AllGroups" runat="server" AutoPostBack="true" Height="351px" Width="300px" DataTextField="DisplayName" OnSelectedIndexChanged="AllGroupsSelectedChanged" DataValueField="Sid"></asp:ListBox>
                <asp:Label ID="Label4" runat="server" Text="Grup İsmi:" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                <asp:Button ID="BtnAddGroup" runat="server" HorizontalAlignment="Left" Margin="12,36,0,0" VerticalAlignment="Top" Text="Grup Ekle" OnClick="BtnAddGroup_Click" />
                <asp:Button ID="BtnRemoveGroup" runat="server" HorizontalAlignment="Left" Margin="130,36,0,0" VerticalAlignment="Top" Text="Grup Sil" OnClick="BtnRemoveGroupClick" />
            </div>
            <div class="div" id="div2">
                <asp:Label ID="Label2" runat="server" Text="Üyeler:" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:ListBox ID="ListAllMembers" runat="server" Height="351px" Width="300px" DataTextField="DisplayName" DataValueField="Sid"></asp:ListBox>
                <asp:Button ID="BtnRemoveUser" runat="server" Text="Kullanıcıyı Gruptan Sil" OnClick="BtnRemoveUserFromGroupClick" />
            </div>
            <div class="div" id="div3">

                <asp:Label ID="Label3" runat="server" Text="Tüm Kullanıcılar:" Font-Bold="True" ForeColor="Black"></asp:Label>
                <asp:ListBox ID="ListAllUsers" runat="server" Height="351px" Width="300px" DataTextField="DisplayName" DataValueField="Sid"  ></asp:ListBox>
                <asp:Button ID="BtnAddUser" runat="server" Text="Kullanıcıyı Gruba Ekle" OnClick="BtnAddUserToGroupClick" />
            </div>
           
        </div>


        <hr style="height: 0px" />



        <div id="esra">
            <div style="margin-top:1px">
            <asp:Label ID="Label7" runat="server" Text="Tüm Kullanıcılar:" Font-Bold="True" ></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Projeler:" Font-Bold="True"></asp:Label>
                 </div>         
        <asp:ListBox ID="AllUsersDown" runat="server" Height="257px" Width="300px"></asp:ListBox> 

         <%--   <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>--%>
            <asp:ListBox ID="Project2" runat="server" Height="256px" Width="314px" DataTextField="Name" DataValueField="Sid" SelectionMode="Multiple"></asp:ListBox>
            <asp:RadioButton ID="YzlAdd" runat="server" Font-Bold="True" Height="20px" Text="Yazılımcı Ekle" />
            <asp:RadioButton ID="MstAdd" runat="server" Font-Bold="True" Height="20px" Text="Müşteri Ekle" />     
        <asp:Button ID="SaveUser" runat="server" Font-Bold="True" Text="EKLE" Width="89px" OnClick="SaveUserClick" />
            <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" Text="KALDIR" Width="78px" />
        </div>

        
        </form>
    </body>
</html>
