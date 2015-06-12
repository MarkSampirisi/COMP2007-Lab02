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
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the user has posted back
            if (!IsPostBack)
            {
                GetDepartments();
            }
        }

        // connect to database and output results to gridview
        protected void GetDepartments()
        {
            using (MyDatabase1Entities db = new MyDatabase1Entities())
            {
                IQueryable<Department> deps = from d in db.Departments select d;
                grdDepartments.DataSource = deps.ToList();
                grdDepartments.DataBind();
            }
        }

        protected void grdDepartments_DeleteRow(object sender, GridViewDeleteEventArgs e)
        {
            // connect to db
            using (MyDatabase1Entities db = new MyDatabase1Entities())
            {
                // find Department and delete it
                int DepartmentID = Convert.ToInt32(grdDepartments.DataKeys[e.RowIndex].Values["DepartmentID"]);                
                Department d = (from dep in db.Departments where dep.DepartmentID == DepartmentID select dep).FirstOrDefault();
                db.Departments.Remove(d);
                // save
                db.SaveChanges();
                // update grid
                GetDepartments();
            }
        }
    }
}