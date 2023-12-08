using CSCI336_FinalProject.CSCI366FinalWork.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI336_FinalProject.CSCI366FinalWork.Webpages
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load all grid views
            UpdateBookGV();
            UpdateUsersGV();
            UpdateAuthorGV();
            UpdateClassGV();
            UpdateCheckedOutAllGV();
            UpdateAssociatedWithGV();
            UpdateAuthoredByGV();

            // Update current return date
            UpdateCurrentReturnDate();
        }

        // Method for loading book grid view
        private void UpdateBookGV()
        {
            gvBooks.DataSource = Book.GetBooksAll();
            gvBooks.DataBind();
        }

        // Method for loading users grid view
        private void UpdateUsersGV()
        {
            gvUsers.DataSource = Users.GetUsersAll();
            gvUsers.DataBind();
        }

        // Method for loading author grid view
        private void UpdateAuthorGV()
        {
            gvAuthors.DataSource = Author.GetAuthorsAll();
            gvAuthors.DataBind();
        }

        // Method for loading class grid view
        private void UpdateClassGV()
        {
            gvClasses.DataSource = Class.GetClassAll();
            gvClasses.DataBind();
        }

        // Method for loading checked out grid view
        private void UpdateCheckedOutAllGV()
        {
           
            gvCheckedOut.DataSource = Book.GetCheckedOutAll();
            gvCheckedOut.DataBind();
        }

        // Method for loading currently checked out grid view
        private void UpdateCheckedOutCurrentlyGV()
        {
            gvCheckedOut.DataSource = Book.GetCurrentlyCheckedOutAll();
            gvCheckedOut.DataBind();
        }

        // Method for loading associated with grid view
        private void UpdateAssociatedWithGV()
        {
            gvAssociatedWith.DataSource = Book.GetAssociatedWithAll();
            gvAssociatedWith.DataBind();
        }

        // Method for loading authored by with grid view
        private void UpdateAuthoredByGV()
        {
            gvAuthoredBy.DataSource = Book.GetAuthoredByAll();
            gvAuthoredBy.DataBind();
        }

        // Method to update current return date
        private void UpdateCurrentReturnDate()
        {
            lblCurrentReturnDate.Text = Convert.ToString(Book.return_date);
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("logon.aspx", true);
        }

        // Method for setting the return date variable in Book.cs (RETURN DATE NOT CURRENTLY SAVED IN DB)
        protected void btnSetReturnDate_Click(object sender, EventArgs e)
        {
            try
            {
                Book.return_date = Convert.ToDateTime(tbReturnDate.Text);
                UpdateCurrentReturnDate();
                lblInvalidReturnDate.Visible = false;
            }
            catch (Exception ex)
            {
                lblInvalidReturnDate.Visible = true;
            }
        }

        protected void cbDisplayCheckedOutBooks_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisplayCheckedOutBooks.Checked == true)
                UpdateCheckedOutCurrentlyGV();
            else
                UpdateCheckedOutAllGV();
        }
    }
}