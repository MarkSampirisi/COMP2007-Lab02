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
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the user has posted back
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    GetStudent();
                }
            }
        }

        protected void GetStudent()
        {
            //connect to the database
            using (MyDatabase1Entities db = new MyDatabase1Entities())
            {
                //get id from url parameter and store in a variable
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                var d = (from studs in db.Students where studs.StudentID == StudentID select studs).FirstOrDefault();

                //populate the form from our department object
                txtfirst.Text = d.FirstMidName;
                txtlast.Text = d.LastName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect to db
            using (MyDatabase1Entities db = new MyDatabase1Entities())
            {
                //instantiate a new department object in memory
                Student d = new Student();

                if (Request.QueryString.Count > 0)
                {
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                    d = (from studs in db.Students where studs.StudentID == StudentID select studs).FirstOrDefault();
                }

                //fill the properties of our object from the form inputs
                d.LastName = txtlast.Text;
                d.FirstMidName = txtfirst.Text;
                //save
                if (Request.QueryString.Count == 0)
                    db.Students.Add(d);
                db.SaveChanges();
                //redirect to (updated) departments page
                Response.Redirect("students.aspx");
            }
        }
    }
}