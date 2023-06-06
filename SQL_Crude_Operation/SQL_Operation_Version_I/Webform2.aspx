﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webform2.aspx.cs" Inherits="SQL_Operation_Version_I.Webform2" %>
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
        <div class="container bg-dark">
            <%-- here you can operate student ID --%>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label text-white">Studen-ID : </label>
             <%--change--%>    <asp:DropDownList class="form-control" ID="ddlStudentID" runat="server"></asp:DropDownList> 
            </div>
            <%-- here you can operate student Name --%>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label text-white">Physics : </label>
                <asp:TextBox class="form-control" ID="physics" runat="server"></asp:TextBox>
            </div>
            <%-- here you can operate student Email --%>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label text-white">Science : </label>
                <asp:TextBox class="form-control" ID="science" runat="server"></asp:TextBox>
            </div>
            <%-- here you can operate student phoneNUmber --%>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label text-white">Maths : </label>
                <asp:TextBox class="form-control" ID="maths" runat="server"></asp:TextBox>
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
                <asp:Button ID="btn_joins" class="btn btn-primary" runat="server" Text="Student-Table" PostBackUrl="~/WebForm1.aspx" />
                &nbsp;&nbsp;&nbsp;                
                <asp:Button ID="btn_report" class="btn btn-primary" runat="server" Text="Report-V1" PostBackUrl="~/WebForm3.aspx" />
                <br /><br /><br />
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="731px">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                <br />
            </div>
            <%-- grid view is here to show the valuesssssss --%>   
                                 
        </div>
    </form>
</body>
</html>
