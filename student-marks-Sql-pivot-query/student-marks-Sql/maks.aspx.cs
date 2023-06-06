using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace student_marks_Sql
{
    public partial class maks : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStudentIDs();
                BindMarksIDs();
                ShowData();
            }
        }

        private void ShowData()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT m.*, s.name AS StudentName FROM [marks] m INNER JOIN [Std] s ON m.StdId = s.Id", con))
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView1.DataSourceID = null;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
            }
        }

        private void BindStudentIDs()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Id, name FROM [Std]", con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string studentId = reader["Id"].ToString();
                    string studentName = reader["name"].ToString();
                    string displayText = studentName + " ( Student ID : " + studentId + ")";
                    ddlStudent.Items.Add(new ListItem(displayText, studentId));
                }
                con.Close();
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO [Marks] ([Id], [Subject], [Marks], [StdId]) VALUES (@Id, @Subject, @Marks, @StdId)", con))
            {
                cmd.Parameters.AddWithValue("@Id", GenerateNewMarkId());
                cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
                cmd.Parameters.AddWithValue("@Marks", txtMarks.Text);
                cmd.Parameters.AddWithValue("@StdId", ddlStudent.SelectedValue);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            ClearFields();
            ShowData();
            ShowPopup("Record inserted successfully!");
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            int selectedStudentId = Convert.ToInt32(ddlStudent.SelectedValue);

            using (SqlCommand cmd = new SqlCommand("DELETE FROM [Marks] WHERE [StdId] = @StdId", con))
            {
                cmd.Parameters.AddWithValue("@StdId", selectedStudentId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            ClearFields();
            ShowData();
            ShowPopup("All records for the selected student ID have been deleted successfully!");
        }



        protected void btn_clear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtSubject.Text = "";
            txtMarks.Text = "";
            ddlStudent.SelectedIndex = 0;
        }

        private int GetSelectedMarkId()
        {
            if (GridView1.SelectedIndex != -1)
            {
                return Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            }
            return -1;
        }
        private object GenerateNewMarkId()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT MAX(Id) FROM [Marks]", con))
            {
                con.Open();
                int maxId = cmd.ExecuteScalar() == DBNull.Value ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return maxId + 1;
            }
        }
        private void ShowPopup(string message)
        {
            ClientScript.RegisterStartupScript(GetType(), "Popup", "alert('" + message + "');", true);
        }

        private void BindMarksIDs()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Id, subject, marks FROM [marks]", con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string m_Id = reader["Id"].ToString();
                    string displayText = m_Id;// +" AND ( Subjet Name : " + m_Subject + " & Marks : " + m_marks + ")";
                    ddlMarksID.Items.Add(new ListItem(displayText));
                }
                con.Close();
            }
        }

        protected void btn_updatemarks_Click(object sender, EventArgs e)
        {
            string selectedMarkId = ddlMarksID.SelectedValue;

            using (SqlCommand cmd = new SqlCommand("UPDATE [Marks] SET [Subject] = @Subject, [Marks] = @Marks WHERE [Id] = @Id", con))
            {

                cmd.Parameters.AddWithValue("@Id", selectedMarkId);
                cmd.Parameters.AddWithValue("@Subject", txtMarksSubject.Text);
                cmd.Parameters.AddWithValue("@Marks", txtMarksMarks.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            txtMarksMarks.Text = "";
            txtMarksSubject.Text = "";
            ShowData();
            ShowPopup("Record updated successfully!");
        }

        protected void btn_deletemarks_Click(object sender, EventArgs e)
        {
            string selectedMarkDisplayText = ddlMarksID.SelectedValue;
            string selectedMarkId = selectedMarkDisplayText.Substring(selectedMarkDisplayText.IndexOf(":") + 1).Trim();

            using (SqlCommand cmd = new SqlCommand("DELETE FROM [Marks] WHERE [Id] = @Id", con))
            {
                cmd.Parameters.AddWithValue("@Id", selectedMarkId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            // Remove the deleted item from the dropdown list
            ddlMarksID.Items.Remove(ddlMarksID.SelectedItem);

            ClearFields();
            ShowData();
            ShowPopup("Record deleted successfully!");
        }

    }
}