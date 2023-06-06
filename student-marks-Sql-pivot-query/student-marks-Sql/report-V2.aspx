<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="report-V2.aspx.cs" Inherits="student_marks_Sql.report_V2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" OnClick="btnGenerateReport_Click" />
        <asp:GridView ID="GridViewReport" runat="server" Width="881px">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
