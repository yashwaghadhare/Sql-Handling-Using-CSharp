<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="student_marks_Sql.student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<head id="Head1">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SQL-Operations-Version-1 | CRUD-Operations</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.bundle.min.js"></script>
</head>
<body class="bg-dark text-white">
    <form id="form1" runat="server" style="margin-top: 4%;">
        <div class="container bg-dark">
            <%-- here you can operate student ID --%>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label text-white">Studen-ID : </label>
                <asp:TextBox class="form-control" ID="ID" runat="server"></asp:TextBox>
            </div>
            <%-- here you can operate student Name --%>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label text-white">Studen-Name : </label>
                <asp:TextBox class="form-control" ID="name" runat="server"></asp:TextBox>
            </div>
            <%-- here you can operate student phoneNUmber --%>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label text-white">Student-Phone : </label>
                <asp:TextBox class="form-control" ID="phone" runat="server"></asp:TextBox>
            </div>

            <%-- buttons here --%>

            <div class="container">
                <asp:Button ID="btn_add" class="btn btn-primary" runat="server" Text="Add" OnClick="btn_add_Click"/>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_update" class="btn btn-primary" runat="server" Text="Update" OnClick="btn_update_Click"/>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_delete" class="btn btn-primary" runat="server" Text="Delete" OnClick="btn_delete_Click"/>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_clear" class="btn btn-primary" runat="server" Text="Clear" OnClick="btn_clear_Click"/>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_maks" class="btn btn-primary" runat="server" Text="Marks-Table" PostBackUrl="~/maks.aspx" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_report" class="btn btn-primary" runat="server" Text="Report" PostBackUrl="~/report.aspx" />
                <br /><br /><br />
                
            </div>
            <%-- grid view is here to show the valuesssssss --%>
                <asp:GridView ID="GridView1" runat="server" Width="680px">
                </asp:GridView>
                <br />

        </div>
    </form>
</body>

</html>
