using CSCI336_FinalProject.CSCI366FinalWork.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI336_FinalProject.CSCI366FinalWork.Webpages
{
    public partial class member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load grid view library with all books
            gvLibrary.DataSource = Book.GetBooksAll();
            gvLibrary.DataBind();
        }

        // Method that logs out current user when button is pressed
        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("logon.aspx", true);
        }

        // Method to change headers of grid view library
        protected void gvLibrary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Book ID";
                e.Row.Cells[1].Text = "Title";
                e.Row.Cells[2].Text = "Publisher";
                e.Row.Cells[3].Text = "Language";
                e.Row.Cells[4].Text = "Date Published";
            }
        }
    }
}