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
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the user has posted back
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0)
                {
                    GetDepartment();
                }
            }
        }

        protected void GetDepartment()
        {
            //connect to db
            using (MyDatabase1Entities conn = new MyDatabase1Entities())
            {
                //get id from url parameter and store in a variable
                Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
                var d = (from dep in conn.Departments where dep.DepartmentID == DepartmentID select dep).FirstOrDefault();

                //populate the form from our department object
                txtName.Text = d.Name;
                txtBudget.Text = d.Budget.ToString();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //connect
            using (MyDatabase1Entities db = new MyDatabase1Entities())
            {
                //instantiate a new deparment object in memory
                Department d = new Department();

                if (Request.QueryString.Count > 0)
                {
                    Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    d = (from dep in db.Departments where dep.DepartmentID == DepartmentID select dep).FirstOrDefault();
                }

                //fill the properties of our object from the form inputs
                d.Name = txtName.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);
                //save
                if (Request.QueryString.Count == 0)
                    db.Departments.Add(d);
                db.SaveChanges();
                //redirect to (updated) departments page
                Response.Redirect("departments.aspx");
            }
        }
    }
}