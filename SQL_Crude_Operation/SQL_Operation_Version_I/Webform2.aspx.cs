using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//manually added
using System.Data;
using System.Data.SqlClient;

namespace SQL_Operation_Version_I
{
    public partial class Webform2 : System.Web.UI.Page
    {
        // connecting sql datasource
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        //page load 
        protected void Page_Load(object sender, EventArgs e)
        {
            // this is because we do not require open and close again and again..
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            //whenever page is load then this function will show the data
            showData();
        }



        public void showData()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            // SQL command to populate the DropDownList with student IDs from Table1
            cmd.CommandText = "SELECT ID FROM [Table]";
            SqlDataReader reader = cmd.ExecuteReader();
            ddlStudentID.Items.Clear();
            while (reader.Read())
            {
                ListItem item = new ListItem();
                item.Text = reader["ID"].ToString();
                item.Value = reader["ID"].ToString();
                ddlStudentID.Items.Add(item);
            }
            reader.Close();
            // SQL command to show the data from Table2 based on the selected student ID
            cmd.CommandText = "SELECT * FROM [Table2] WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", ddlStudentID.SelectedValue);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSourceID = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }



        protected void btn_add_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;

                // Check if a record with the same primary key already exists
                cmd.CommandText = "SELECT COUNT(*) FROM [Table2] WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", ddlStudentID.SelectedValue);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    // No record with the same primary key exists, so proceed with the insertion
                    cmd.CommandText = "INSERT INTO [Table2] (ID, physics, science, maths) VALUES (@ID, @physics, @science, @maths)";
                    cmd.Parameters.AddWithValue("@ID", ddlStudentID.SelectedItem.Text); // Use SelectedItem.Text to get the selected value from the DropDownList
                    cmd.Parameters.AddWithValue("@physics", physics.Text);
                    cmd.Parameters.AddWithValue("@science", science.Text);
                    cmd.Parameters.AddWithValue("@maths", maths.Text);
                    cmd.ExecuteNonQuery();

                    // Clear textboxes
                    physics.Text = "";
                    science.Text = "";
                    maths.Text = "";
                    // Popup message
                    ShowPopup("Record inserted successfully!");
                    // Refresh the table and show recently added values
                    showData();
                }
                else
                {
                    // A record with the same primary key already exists
                    ShowPopup("A record with the same ID already exists!");
                }
            }
        }



        protected void btn_update_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                // SQL cmd to update the values in Table2
                cmd.CommandText = "UPDATE [Table2] SET physics = @physics, science = @science, maths = @maths WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", ddlStudentID.SelectedValue);
                cmd.Parameters.AddWithValue("@physics", physics.Text);
                cmd.Parameters.AddWithValue("@science", science.Text);
                cmd.Parameters.AddWithValue("@maths", maths.Text);
                cmd.ExecuteNonQuery();
            }
            // Clear textboxes
            physics.Text = "";
            science.Text = "";
            maths.Text = "";
            // Popup message
            ShowPopup("Record updated successfully!");
            // Refresh the table and show recently added values
            showData();
        }



        protected void btn_delete_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                // SQL cmd to delete the values from Table2
                cmd.CommandText = "DELETE FROM [Table2] WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@ID", ddlStudentID.SelectedValue);
                cmd.ExecuteNonQuery();
            }
            // Clear the DropDownList selection
            ddlStudentID.SelectedIndex = -1;
            // Popup message
            ShowPopup("Record deleted successfully!");
            // Refresh the table and show recently added values
            showData();
        }



        protected void btn_clear_Click(object sender, EventArgs e)
        {
            physics.Text = "";
            science.Text = "";
            maths.Text = "";
            //popup message
            ShowPopup("Textbox cleared..!!");
            //to refresh the table and to show recentaly added values
            showData();
        }

        private void ShowPopup(string message)
        {
            ClientScript.RegisterStartupScript(GetType(), "Popup", "alert('" + message + "');", true);
            //popup message
            //ShowPopup("works");
        }
    }
}