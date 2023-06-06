using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//manually added
using System.Data;
using System.Data.SqlClient;

namespace student_marks_Sql
{
    public partial class student : System.Web.UI.Page
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
            //sql cmd to show the data
            cmd.CommandText = "select * from [std]";
            cmd.ExecuteNonQuery();
            //show value on grid view
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
                //Sql cmd to add the values
                cmd.CommandText = "INSERT INTO [Std] VALUES (@Id, @name,@phonenumber)";
                cmd.Parameters.AddWithValue("@Id", ID.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@phonenumber", phone.Text);
                cmd.ExecuteNonQuery();
            }
            //Clear textbox
            ID.Text = "";
            name.Text = "";
            phone.Text = "";
            //popup message
            ShowPopup("record inserted..!!");
            //to refresh the table and to show recentaly added values
            showData();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                //Sql cmd to update the values
                cmd.CommandText = "UPDATE [Std] SET name = @name, phonenumber = @phonenumber WHERE Id = @ID";
                cmd.Parameters.AddWithValue("@ID", ID.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@phonenumber", phone.Text);
                cmd.ExecuteNonQuery();
            }
            //clear textbox
            ID.Text = "";
            name.Text = "";
            phone.Text = "";
            //popup message
            ShowPopup("record updated..!!");
            //to refresh the table and to show recentaly added values
            showData();
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                //Sql cmd to delete the values
                cmd.CommandText = "DELETE FROM [Std] WHERE Id = @ID";
                cmd.Parameters.AddWithValue("@ID", ID.Text);
                cmd.ExecuteNonQuery();
            }
            ID.Text = "";
            //popup message
            ShowPopup("record deleted..!!");
            //to refresh the table and to show recentaly added values
            showData();
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            ID.Text = "";
            name.Text = "";
            phone.Text = "";

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