<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="SQL_Operation_Version_I.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SQL-Operations-Version-1 | CRUD-Operations</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.bundle.min.js"></script>
</head>

<body class="bg-dark text-white">
    <form id="form1" runat="server" style="margin-top: 4%;">
        <div>
            <asp:Button ID="btn_report" class="btn btn-primary" runat="server" Text="Generate-Report" OnClick="btn_report_Click"/>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_joins1" class="btn btn-primary" runat="server" Text="Student-Table" PostBackUrl="~/WebForm1.aspx" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_join2" class="btn btn-primary" runat="server" Text="Marks-Table" PostBackUrl="~/WebForm2.aspx" />
            <br />
            <br />
        </div>
        <asp:GridView ID="GridView1" runat="server" Width="976px"></asp:GridView>
    </form>
</body>

</html>
