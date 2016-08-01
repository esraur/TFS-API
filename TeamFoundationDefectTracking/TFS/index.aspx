<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.TFS.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TFS </title>
    <link href="../css/yonetici.css" rel="stylesheet" />
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <style>
        .viewortalama {
            text-align: center;
        }

        .esra {
            font-size:12px;
            color:black;
            font-weight:bold;

        }
    </style>
</head>
<body>
    <style></style>
    <form id="form1" runat="server">

        <div id="main" style="width: 100%; height: 100%; position: absolute;">
            <div style="margin-top: 0px; margin-bottom: 10px; float: right; padding-bottom: 50px; padding-right: 20px; position: relative">
                <asp:Label ID="Label1" runat="server" EnableTheming="false" CssClass="esra"></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="DefaultDilYukle2">TR</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="EngDilYukle2" OnClientClick="EngDilYukle2">EN</asp:LinkButton>
                
            </div>
            <br />
            <br />
            <div class="title2" id="pageTittle2" style="width: 0 auto; text-align: center">

                <a href="~/Admin/UserList.aspx" runat="server" visible="false" id="adminuserlistbtn" style="" class="btn btn-default"></a>
                <a href="~/Yonetici/Yonetici.aspx" runat="server" visible="false" id="yoneticibtn" class="btn btn-default"></a>
                <a href="~/Admin/DeleteWorkItem.aspx" runat="server" visible="false" id="admindeletebtn" class="btn btn-default"></a>
                <a href="~/Yonetici/Listeleme.aspx" runat="server" visible="false" id="yonetcilistbtn" class="btn btn-default"></a>
                <a href="~/Admin/GroupOperations.aspx" runat="server" visible="false" id="admingroupopbtn" class="btn btn-default"></a>
                <a href="Create.aspx" runat="server" visible="false" id="createworkitem" class="btn btn-default"></a>
            </div>
            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="30px">

                        <ItemTemplate>
                            <asp:Label ID="LableId" runat="server"
                                Text='<%#DataBinder.Eval(Container.DataItem,"ID")%>'>
                            </asp:Label>
                        </ItemTemplate>

                        <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:Label ID="LabelState" runat="server">
                        <%#DataBinder.Eval(Container.DataItem,"State") %></asp:Label>
                        </ItemTemplate>

                        <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:Label ID="LabelType" runat="server"
                                Text='<%#DataBinder.Eval(Container.DataItem,"Type.Name")%>'>
                            </asp:Label>
                        </ItemTemplate>


                        <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:Label ID="LableAreaPath" runat="server"
                                Text='<%#DataBinder.Eval(Container.DataItem,"AreaPath")%>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:Label ID="LabelTitle" runat="server"
                                Text='<%#DataBinder.Eval(Container.DataItem,"Title")%>'> 
                            </asp:Label>
                        </ItemTemplate>


                        <ItemStyle HorizontalAlign="Left" Width="30px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:Label ID="LabelReason" runat="server">
                        <%#DataBinder.Eval(Container.DataItem,"Reason") %></asp:Label>
                        </ItemTemplate>


                        <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="30px">
                        <ItemTemplate>
                            <asp:Label ID="LabelDetail" runat="server" CssClass="viewortalama">

                        <a href="details.aspx?ID=<%#DataBinder.Eval(Container.DataItem,"Id") %>" target='popup' onclick="window.open('details.aspx?ID=<%#DataBinder.Eval(Container.DataItem,"Id") %>','name','width=1024,height=720')" >View</a></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    

                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle CssClass="headerstyle" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="GridviewScrollPager" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle CssClass="rowstyle" BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>

    </form>

</body>
</html>
