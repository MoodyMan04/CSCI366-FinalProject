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

            // Get book count
            lblBookCount.Text = Convert.ToString(Book.GetBookCountAll());

            // Get return date
            lblReturnDate.Text = Convert.ToString(Book.return_date);
        }

        // Method that logs out current user when button is pressed
        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("logon.aspx", true);
        }

        // Method to change headers of grid view library (Automatically Ran when grid view library is data bound)
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

        // Method for displaying all books with no filters (same as when page loads)
        protected void btnDisplayAll_Click(object sender, EventArgs e)
        {
            // Load grid view library with all books
            gvLibrary.DataSource = Book.GetBooksAll();
            gvLibrary.DataBind();
        }

        // Method for displaying a book with the a provided book id
        protected void btnFilterBookID_Click(object sender, EventArgs e)
        {
            try
            {
                gvLibrary.DataSource = Book.GetBookById(Convert.ToInt32(tbFilterBookID.Text));
                gvLibrary.DataBind();
                lblInvalidBookID.Visible = false;
            }
            catch (Exception ex)
            {
                lblInvalidBookID.Visible = true;
            }
        }

        // Method for displaying books that has the provided book title
        protected void btnFilterTitle_Click(object sender, EventArgs e)
        {
            try
            {
                gvLibrary.DataSource = Book.GetBookByTitle(tbFilterTitle.Text);
                gvLibrary.DataBind();
                lblInvalidTitle.Visible = false;
            }
            catch (Exception ex)
            {
                lblInvalidTitle.Visible = true;
            }
        }

        // Method for displaying books that has the provided book language
        protected void btnFilterLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                gvLibrary.DataSource = Book.GetBookByLanguage(tbFilterLanguage.Text);
                gvLibrary.DataBind();
                lblInvalidLanguage.Visible = false;
            }
            catch (Exception ex) 
            {
                lblInvalidLanguage.Visible = true;
            }
        }
    }
}