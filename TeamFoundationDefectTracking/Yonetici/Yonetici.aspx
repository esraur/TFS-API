<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="Yonetici.aspx.cs" validateRequest="false" Inherits="CognitiveSoftware.TeamFoundation.Integration.Yonetici.Yonetici" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <title>TFS</title>
    <link href="../css/yonetici.css" rel="stylesheet" />
    <script src="../ckeditor/ckeditor.js"></script>

</head>

<body style="text-align: start">

    <form id="form1" runat="server">
        <div id="genel" class="container" style="overflow: auto; position: relative">
            <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="Button2" class="btn btn-default" runat="server" Text="GETİR" OnClick="Button2_Click" />

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="TextBox23"
                ErrorMessage="Id Kısmı Boş Olamaz."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
            <p>
                Title<asp:TextBox ID="TextBox1" runat="server" Width="1057px"></asp:TextBox>
            </p>
            <div id="status" class="status">
                <p>
                    <asp:Label ID="Label1" runat="server" Text="STATUS" Font-Bold="True"></asp:Label>
                </p>
                <p style="margin-right: 15px">
                    Assigned To:    
                    <asp:TextBox ID="TextBox13" runat="server" Width="70%" CssClass="txtbox"></asp:TextBox>
                </p>
                <p>
                    State:          
                    <asp:TextBox ID="TextBox12" runat="server" Width="68%" CssClass="txtbox1"></asp:TextBox>
                </p>
                <p>
                    State Reason:   
                    <asp:TextBox ID="TextBox3" runat="server" Width="70%"></asp:TextBox>
                </p>
                <p>
                    Resolved Reason:
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="txtbox" Width="65%" ></asp:TextBox>
                </p>
                <p>
                    Triage:         
                    <asp:TextBox ID="TextBox10" runat="server" Width="70%" CssClass="txtbox2"></asp:TextBox>
                </p>
                <p>
                    Report Status:  
                    <asp:TextBox ID="TextBox11" runat="server" Width="70%"></asp:TextBox>
                </p>
            </div>
            <div id="classification" class="classification">
                <asp:Label ID="Label9" runat="server" Text="CLASSIFICATION:" Font-Bold="True"></asp:Label>
                <p></p>
                <p>
                    AreaDropDown:<asp:DropDownList ID="AreaDropdown" runat="server">
                    </asp:DropDownList>
                </p>
                <p>
                    Iteration Dropdown:<asp:DropDownList ID="IterationDropdown" runat="server">
                    </asp:DropDownList>
                </p>

                <p>
                    Area:<asp:TextBox ID="TextBox16" runat="server" Width="90%"></asp:TextBox>
                </p>
                <p>
                    Iteration:<asp:TextBox ID="TextBox14" runat="server" Width="90%"></asp:TextBox>
                </p>
                <p>
                    Platform:<asp:TextBox ID="TextBox15" runat="server" Width="90%"></asp:TextBox>
                </p>
                <p>
                    Priority:<asp:TextBox ID="TextBox17" runat="server" Width="90%"></asp:TextBox>
                </p>
                <p>
                    Severity:<asp:TextBox ID="TextBox18" runat="server" Width="90%"></asp:TextBox>
                </p>
                <p>
                    Ordering:<asp:TextBox ID="TextBox2" runat="server" Width="80%"></asp:TextBox>
                </p>
                <p>
                    G/O:<asp:TextBox ID="TextBox19" runat="server" Width="90%"></asp:TextBox>
                </p>
                <p>
                    Integration:<asp:TextBox ID="TextBox20" runat="server" Width="85%"></asp:TextBox>
                </p>

            </div>
            <div id="planning1" class="planning1">
                <asp:Label ID="Label18" runat="server" Text="PLANNING-COMPLETED EFFORTY(HOUR)" Font-Bold="True"></asp:Label>
                <p></p>
                <p style="float: right; position: relative; text-align: right">
                    Complated Work: 
                    <asp:TextBox ID="TextBox6" runat="server" Width="40%"></asp:TextBox>
                </p>
                <p>
                    Estimated Duration:<asp:TextBox ID="TextBox5" runat="server" Width="30%"></asp:TextBox>
                </p>


                <p style="float: right; width: 50%">
                    Overtime Work Duration:
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </p>
                <p>
                    Orginal Estimate:<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </p>


            </div>
            <div id="planning2" class="planning2">

                <p style="float: left; width: 50%; position: relative">
                    <asp:Label ID="Label2" runat="server"> Finish Date: </asp:Label>
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </p>

            </div>
            <div id="requested" class="requested">
                <asp:Label ID="Label24" runat="server" Text="REQUESTED BY" Font-Bold="True"></asp:Label>
                <p></p>
                <p>
                    Company:<asp:TextBox ID="TextBox21" runat="server" Width="635px" CssClass="txtbox"></asp:TextBox>
                </p>
                <p>
                    Requested By:<asp:TextBox ID="TextBox22" runat="server" Width="635px" CssClass="txtbox"></asp:TextBox>
                </p>

            </div>
            <div id="details" class="details">
            </div>
        </div>
        <p>
            &nbsp;
        </p>
        <div>
            </div>
                <asp:TextBox ID="editor2" runat="server" TextMode="MultiLine" Rows="10" cols="80"></asp:TextBox>
                <script>
                    // Replace the <textarea id="editor1"> with a CKEditor
                    // instance, using default configuration.
                    CKEDITOR.replace('editor2');
                </script>

        </div>
       
        <%--<p>
            <asp:Button ID="Button3" class="btn btn-default" runat="server" Text="AREA PATH" OnClick="Button3_Click" />
        </p>--%>


         <p>
            <asp:Button ID="Button3" class="btn btn-default" runat="server" OnClick="Button3_Click" Text="SAVE" />
        </p>
    </form>

       

</body>
</html>
