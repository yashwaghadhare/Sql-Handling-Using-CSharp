<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="student_marks_Sql.report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SQL-Operations-Version-1 | CRUD-Operations</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.bundle.min.js"></script>
    <style>
        table {
            border-collapse: collapse;
        }
        th, td {
            border: 1px solid black;
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnGenerateReport" class="btn btn-primary" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_student" class="btn btn-primary" runat="server" Text="Student-Table" PostBackUrl="~/student.aspx" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_marks" class="btn btn-primary" runat="server" Text="Student-Table" PostBackUrl="~/maks.aspx" />
            <hr />
            <asp:Literal ID="litReport" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
