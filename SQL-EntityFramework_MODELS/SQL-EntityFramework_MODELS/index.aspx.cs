using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQL_EntityFramework_MODELS
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string personName = txt_PersonName.Text;
            string personPhone = txt_PersonPhone.Text;
            string personAge = txt_PersonAge.Text;

            using (var dbContext = new DBEntities())
            {
                var person = new person_db
                {
                    Person_Name = personName,
                    Person_Phone = personPhone,
                    Person_Age = personAge
                };

                dbContext.person_db.Add(person);
                dbContext.SaveChanges();
            }

            ClearInputs();
            BindGridView();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int personID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string personName = (row.FindControl("txtEditPersonName") as TextBox).Text;
            string personPhone = (row.FindControl("txtEditPersonPhone") as TextBox).Text;
            string personAge = (row.FindControl("txtEditPersonAge") as TextBox).Text;

            using (var dbContext = new DBEntities())
            {
                var person = dbContext.person_db.Find(personID);
                if (person != null)
                {
                    person.Person_Name = personName;
                    person.Person_Phone = personPhone;
                    person.Person_Age = personAge;
                    dbContext.SaveChanges();
                }
            }

            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int personID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            using (var dbContext = new DBEntities())
            {
                var person = dbContext.person_db.Find(personID);
                if (person != null)
                {
                    dbContext.person_db.Remove(person);
                    dbContext.SaveChanges();
                }
            }

            BindGridView();
        }

        private void BindGridView()
        {
            using (var dbContext = new DBEntities())
            {
                var people = dbContext.person_db.ToList();
                GridView1.DataSource = people;
                GridView1.DataBind();
            }
        }

        private void ClearInputs()
        {
            txt_PersonName.Text = string.Empty;
            txt_PersonPhone.Text = string.Empty;
            txt_PersonAge.Text = string.Empty;
        }
    }
}