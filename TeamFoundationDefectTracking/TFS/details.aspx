<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="CognitiveSoftware.TeamFoundation.Integration.TFS.details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../ckeditor/ckeditor.js"></script>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <style>
        .orcun {
            text-align: center;
            align-items: center;
        }

        detay  {
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="genel" style="width:100%">
            <a href="index.aspx" class="btn btn-default" style="align-content: center">BACK</a>
            <div id="orcun" style=" height: 90%; width: 90%">
                <asp:TextBox ID="detay" runat="server" TextMode="MultiLine"  Rows="10" cols="500"></asp:TextBox>
                <script>
                    CKEDITOR.replace('detay', {
                        on:
                        {
                            'instanceReady': function (evt) {
                                //CKEDITOR.config.height = 8000;
                               // CKEDITOR.config.width = 1024;
                                evt.editor.execCommand('maximize');
                            }
                        }
                    }
    );

                </script>
            </div>
        </div>
    </form>
</body>
</html>
