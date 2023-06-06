using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace student_marks_Sql
{
    public partial class report_V2 : System.Web.UI.Page
    {
        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Connection string
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            // Query to retrieve the report data using a pivot query
            string query = @"SELECT s.name AS [name],
                            pvt.Maths AS [Maths],
                            pvt.Science AS [Science]
                            FROM ( SELECT m.StdId, m.subject, m.marks FROM [marks] m INNER JOIN [Std] s ON m.StdId = s.Id ) 
                            AS src PIVOT ( MAX(marks) FOR subject IN ([Maths], [Science] )) 
                            AS pvt INNER JOIN [Std] s ON pvt.StdId = s.Id;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridViewReport.DataSource = dt;
                        GridViewReport.DataBind();
                    }
                }
            }
        }
    }
}