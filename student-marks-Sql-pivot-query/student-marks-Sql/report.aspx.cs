using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace student_marks_Sql
{
    public partial class report : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT s.name AS StudentName, m.Subject, m.Marks FROM [Std] s INNER JOIN [Marks] m ON s.Id = m.StdId", con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string reportHtml = "<table>";
                string currentStudentName = string.Empty;
                bool firstRow = true;

                while (reader.Read())
                {
                    string studentName = reader["StudentName"].ToString();
                    string subject = reader["Subject"].ToString();
                    string marks = reader["Marks"].ToString();

                    if (studentName != currentStudentName)
                    {
                        // Close previous student's section if it exists
                        if (!firstRow)
                        {
                            reportHtml += "</table><br />";
                        }

                        // Start new student's section
                        reportHtml += "<h5>" + studentName + "</h5>";
                        reportHtml += "<table>";
                        reportHtml += "<tr><th>Subject</th><th>Marks</th></tr>";
                        currentStudentName = studentName;
                        firstRow = false;
                    }

                    reportHtml += "<tr><td>" + subject + "</td><td>" + marks + "</td></tr>";
                }

                reportHtml += "</table>";
                litReport.Text = reportHtml;

                con.Close();
            }
        }
    }
}