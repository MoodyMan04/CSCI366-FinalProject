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
            DataTable dt = new DataTable("Checked Out");
            dt.Columns.Add(new DataColumn("User_id", typeof(int)));
            dt.Columns.Add(new DataColumn("Book_id", typeof(int)));
            dt.Columns.Add(new DataColumn("is_checkedout", typeof(bool)));
            dt.Columns.Add(new DataColumn("checked_out_time", typeof(DateTime)));
            List<(int, int, bool, DateTime)> checkedOutBooks = Book.GetCheckedOutAll();
            foreach ((int, int, bool, DateTime) checkedOutBook in checkedOutBooks)
            {
                var row = dt.NewRow();
                row[0] = checkedOutBook.Item1;
                row[1] = checkedOutBook.Item2;
                row[2] = checkedOutBook.Item3;
                row[3] = checkedOutBook.Item4;

                dt.Rows.Add(row);
            }

            gvCheckedOut.DataSource = dt;
            gvCheckedOut.DataBind();
        }

        // Method for loading associated with grid view
        private void UpdateAssociatedWithGV()
        {
            DataTable dt = new DataTable("Associated With");
            dt.Columns.Add(new DataColumn("Class_id", typeof(int)));
            dt.Columns.Add(new DataColumn("Book_id", typeof(int)));
            dt.Columns.Add(new DataColumn("is_required", typeof(bool)));
            List<(int, int, bool)> associatedWithLinks = Book.GetAssociatedWithAll();
            foreach ((int, int, bool) associatedWithLink in associatedWithLinks)
            {
                var row = dt.NewRow();
                row[0] = associatedWithLink.Item1;
                row[1] = associatedWithLink.Item2;
                row[2] = associatedWithLink.Item3;

                dt.Rows.Add(row);
            }

            gvAssociatedWith.DataSource = dt;
            gvAssociatedWith.DataBind();
        }

        // Method for loading authored by with grid view
        private void UpdateAuthoredByGV()
        {
            DataTable dt = new DataTable("Authored By");
            dt.Columns.Add(new DataColumn("Author_id", typeof(int)));
            dt.Columns.Add(new DataColumn("Book_id", typeof(int)));
            List<(int, int)> authoredByLinks = Book.GetAuthoredByAll();
            foreach ((int, int) authoredByLink in authoredByLinks)
            {
                var row = dt.NewRow();
                row[0] = authoredByLink.Item1;
                row[1] = authoredByLink.Item2;

                dt.Rows.Add(row);
            }

            gvAuthoredBy.DataSource = dt;
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
    }
}