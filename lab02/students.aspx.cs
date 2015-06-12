using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lab02.Models;
using System.Web.ModelBinding;

namespace lab02
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the user has posted back
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        // connect to database and output results to gridview
        protected void GetStudents()
        {           
            using (MyDatabase1Entities db = new MyDatabase1Entities())
            {
                IQueryable<Student> deps = from s in db.Students select s;
                grdStudents.DataSource = deps.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_DeleteRow(object sender, GridViewDeleteEventArgs e)
        {
            // connect to db
            using (MyDatabase1Entities db = new MyDatabase1Entities())
            {
                // find the student and delete them
                int StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);
                Student s = (from stu in db.Students where stu.StudentID == StudentID select stu).FirstOrDefault();
                db.Students.Remove(s);
                // save
                db.SaveChanges();
                // update grid
                GetStudents();
            }
        }
    }
}