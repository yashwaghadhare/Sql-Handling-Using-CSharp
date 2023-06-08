using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQL_Entity_Framework_PivoteQuery
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneratePivoteQeries();
        }

        private void GeneratePivoteQeries()
        {
            // Assuming you have an instance of your DbContext called "db"
            using (var db = new DatabaseEntities())
            {
                // Pivot query to get the desired data
                var query = from mark in db.Marks
                            join student in db.Students on mark.StudentId equals student.Id
                            group mark by new { student.Name } into pivotGroup
                            select new
                            {
                                StudentName = pivotGroup.Key.Name,
                                Hindi = pivotGroup.FirstOrDefault(m => m.Subject == "Hindi").Marks,
                                English = pivotGroup.FirstOrDefault(m => m.Subject == "English").Marks
                            };

                // Bind the resulting data to the GridView
                dtgGeneratePivoteQeries.DataSource = query.ToList();
                dtgGeneratePivoteQeries.DataBind();
            }
        }
    }
}