<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SQL_EntityFramework_MODELS.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.bundle.min.js"></script>
</head>
<body>
    
            <br />
            <br />
    <form id="form1" runat="server">

        <div class="container">

            <%-- Input For Person Name --%>
            <div class="mb-3">
                <label class="form-label">Enter Person Name :</label>
                <asp:TextBox ID="txt_PersonName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <br />

            <%-- Input For Person Phone --%>
            <div class="mb-3">
                <label class="form-label">Enter Person Phone :</label>
                <asp:TextBox ID="txt_PersonPhone" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <br />

            <%-- Input For Person Age --%>
            <div class="mb-3">
                <label class="form-label">Enter Person Age :</label>
                <asp:TextBox ID="txt_PersonAge" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <br />

            <%-- Button Group to ADD, Delete, Update Values --%>
            <div class="btn_Group">
                <asp:Button ID="btn_Add" CssClass="btn btn-primary" runat="server" Text="Add" OnClick="btn_Add_Click" />
            </div>

            <br />

            <%-- Grid View to Display Data --%>
            <asp:GridView ID="GridView1" runat="server" Width="813px" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="Person_ID" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Person_ID" HeaderText="Person ID" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Person Name">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonName" runat="server" Text='<%# Eval("Person_Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditPersonName" runat="server" Text='<%# Eval("Person_Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Person Phone">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonPhone" runat="server" Text='<%# Eval("Person_Phone") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditPersonPhone" runat="server" Text='<%# Eval("Person_Phone") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Person Age">
                        <ItemTemplate>
                            <asp:Label ID="lblPersonAge" runat="server" Text='<%# Eval("Person_Age") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditPersonAge" runat="server" Text='<%# Eval("Person_Age") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

        </div>

    </form>

</body>
</html>
