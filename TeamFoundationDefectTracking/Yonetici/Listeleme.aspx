<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listeleme.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.Yonetici.Listeleme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link href="css/bootstrap.css" rel="stylesheet" />--%>
    <title></title>

</head>
<body style="height: 542px">
   
    <form id="form1" runat="server">
    <div style="height: 555px">
        <div align="center">
        <td class="label">
                <asp:label runat="server" ID="label1"  align="center" text="TFS ID:" Font-Bold="True"></asp:label>               
                </td>
        <td><asp:TextBox runat="server" align="center" ID="Id" Width="9%" Height="32px"></asp:TextBox></td>

     <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="GETIR" BackColor="#99CCFF" Font-Bold="True" />
              
            <br />
            &nbsp &nbsp &nbsp &nbsp
            <asp:ListBox ID="ListBox1" runat="server" Width="30%" Height="150px"></asp:ListBox>
           
</div>
        <div style="overflow:scroll; table-layout:fixed; Width:1000px;">
         &nbsp &nbsp &nbsp &nbsp
        <asp:GridView ID="dgWiHistory" runat="server" RowStyle-Wrap="true" RowHeaderColumn="50px" FooterStyle-Width="50px"  OnRowDataBound="GridView1_RowDataBound" Style="position: static" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle Width="50px" />
            
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            
           
        </asp:GridView>

      </div>

    </div>
    </form>
</body>
</html>
