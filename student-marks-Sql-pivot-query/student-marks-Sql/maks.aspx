<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="maks.aspx.cs" Inherits="student_marks_Sql.maks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
            <%-- dropdown to select student ID --%>
            <div class="mb-3">
                <label for="ddlStudent" class="form-label text-white">Student ID: </label>
                <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <%-- input field for marks ID --%>
            <%--<div class="mb-3">
                <label for="txtSubject" class="form-label text-white">Marks ID : (Remember this is only when you neet to DELETE / UPDATE perticular marks record.)</label>
                <asp:TextBox ID="txtMarksID" runat="server" CssClass="form-control"></asp:TextBox>
            </div>--%>

            <%-- input field for subject --%>
            <div class="mb-3">
                <label for="txtSubject" class="form-label text-white">Subject: </label>
                <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%-- input field for marks --%>
            <div class="mb-3">
                <label for="txtMarks" class="form-label text-white">Marks: </label>
                <asp:TextBox ID="txtMarks" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%-- buttons here --%>

            <div class="container">
                <asp:Button ID="btn_add" class="btn btn-primary" runat="server" Text="Add" OnClick="btn_add_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_delete" class="btn btn-primary" runat="server" Text="Delete" OnClick="btn_delete_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_clear" class="btn btn-primary" runat="server" Text="Clear" OnClick="btn_clear_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_marks" class="btn btn-primary" runat="server" Text="Student-Table" PostBackUrl="~/student.aspx" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_report" class="btn btn-primary" runat="server" Text="Report" PostBackUrl="~/report.aspx" />
                <br />
                <br />
                <br />

            </div>

            <asp:GridView ID="GridView1" runat="server" Width="725px">
            </asp:GridView>

            
                <br />
                <h5>If you need to Update/Delete Specific Marks Record then : </h5>
                <br />   
                <div class="mb-3">
                    <label for="txtSubject" class="form-label text-white">Marks ID : </label>
                    <asp:DropDownList ID="ddlMarksID" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="txtSubject" class="form-label text-white">Subject : </label>
                    <asp:TextBox ID="txtMarksSubject" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

               <div class="mb-3">
                    <label for="txtSubject" class="form-label text-white">Marks : </label>
                    <asp:TextBox ID="txtMarksMarks" runat="server" CssClass="form-control"></asp:TextBox>
               </div>
                <asp:Button ID="btn_updatemarks" class="btn btn-primary" runat="server" Text="Update" OnClick="btn_updatemarks_Click"/>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_deletemarks" class="btn btn-primary" runat="server" Text="Delete" OnClick="btn_deletemarks_Click"/>
                <br /><br />
        </div>
    </form>
</body>
</html>
