using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace SQL_Operation_Version_I
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            // this is because we do not require open and close again and again..
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            //whenever page is load then this function will show the data
        }

        

        protected void btn_report_Click(object sender, EventArgs e)
        {
            ShowPopup("Report Generated");
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT T1.ID, T1.name, T2.physics, T2.science, T2.maths FROM [Table] AS T1 INNER JOIN [Table2] AS T2 ON T1.ID = T2.ID";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSourceID = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void ShowPopup(string message)
        {
            ClientScript.RegisterStartupScript(GetType(), "Popup", "alert('" + message + "');", true);
        }
    }
}