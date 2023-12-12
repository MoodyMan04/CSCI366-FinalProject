using CSCI336_FinalProject.CSCI366FinalWork.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI336_FinalProject.CSCI366FinalWork.Webpages
{
    public partial class member : System.Web.UI.Page
    {
        // Instance variable for user name
        private string userName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get username
            userName = Page.User.Identity.Name;

            // Display username
            lblUserName.Text = userName;

            // Load all grid views
            UpdateLibraryGV();
            UpdateCheckedOutGV(userName);
            UpdateUserInfoGV(userName);
            
            // Get book count
            lblBookCount.Text = Convert.ToString(Book.GetBookCountAll());

            // Get return date
            lblReturnDate.Text = Convert.ToString(Book.return_date);
        }

        // Method to load grid view of library
        private void UpdateLibraryGV()
        {
            // Load grid view library with all books
            gvLibrary.DataSource = Book.GetBooksAll();
            gvLibrary.DataBind();
        }

        // Method to load grid view of currently checked out books
        private void UpdateCheckedOutGV(string userName)
        {
            // Load grid view user currently checked out books
            List<(Book, DateTime)> checkedOutBooks = Book.GetCurrentCheckedOutForUser(Users.GetCurrentUserId(userName));
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Book ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("Publisher", typeof(string)));
            dt.Columns.Add(new DataColumn("Language", typeof(string)));
            dt.Columns.Add(new DataColumn("Date Published", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Checked Out Time", typeof(DateTime)));
            foreach ((Book, DateTime) checkedOutBook in checkedOutBooks)
            {
                var row = dt.NewRow();
                row[0] = checkedOutBook.Item1.Book_id;
                row[1] = checkedOutBook.Item1.title;
                row[2] = checkedOutBook.Item1.publisher;
                row[3] = checkedOutBook.Item1.dev_language;
                row[4] = checkedOutBook.Item1.date_published;
                row[5] = checkedOutBook.Item2;

                dt.Rows.Add(row);
            }

            gvCheckedOutBooks.DataSource = dt;
            gvCheckedOutBooks.DataBind();
        }

        // Method to load grid view of user info
        private void UpdateUserInfoGV(string userName)
        {
            // Load grid view user info with current user info
            gvCurrentUserInfo.DataSource = Users.GetCurrentUser(userName);
            gvCurrentUserInfo.DataBind();
        }

        // Method that logs out current user when button is pressed
        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("logon.aspx", true);
        }

        // Method to change headers of grid view library (Automatically ran when grid view library is data bound)
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

        // Method to change headers of grid view current user info (Automatically ran when grid view library is data bound)
        protected void gvCurrentUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "----";
                e.Row.Cells[1].Text = "First Name";
                e.Row.Cells[2].Text = "Last Name";
                e.Row.Cells[3].Text = "Admin?";
                e.Row.Cells[4].Text = "Email";
                e.Row.Cells[5].Text = "Username";
                e.Row.Cells[6].Text = "Password";
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
                gvLibrary.DataSource = Book.GetBookById(Convert.ToInt32(tbFilterBookID.Text.Trim()));
                gvLibrary.DataBind();
                lblInvalidBookID.Visible = false;
            }
            catch
            {
                lblInvalidBookID.Visible = true;
            }
        }

        // Method for displaying books that has the provided book title
        protected void btnFilterTitle_Click(object sender, EventArgs e)
        {
            try
            {
                gvLibrary.DataSource = Book.GetBookByTitle(tbFilterTitle.Text.Trim());
                gvLibrary.DataBind();
                lblInvalidTitle.Visible = false;
            }
            catch
            {
                lblInvalidTitle.Visible = true;
            }
        }

        // Method for displaying books that has the provided book language
        protected void btnFilterLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                gvLibrary.DataSource = Book.GetBookByLanguage(tbFilterLanguage.Text.Trim());
                gvLibrary.DataBind();
                lblInvalidLanguage.Visible = false;
            }
            catch
            {
                lblInvalidLanguage.Visible = true;
            }
        }

        // Method for displaying books that has the provided author lastname
        protected void btnFilterAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                gvLibrary.DataSource = Book.GetBookByAuthor(tbFilterAuthor.Text.Trim());
                gvLibrary.DataBind();
                lblInvalidAuthor.Visible = false;
            }
            catch
            {
                lblInvalidAuthor.Visible = true;
            }
        }

        // Method for displaying books that has the provided class 
        protected void btnFilterClass_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbIsRequired.Checked)
                    gvLibrary.DataSource = Book.GetBookByRequiredClass(tbFilterClass.Text.Trim());
                else
                    gvLibrary.DataSource = Book.GetBookByClass(tbFilterClass.Text.Trim());

                gvLibrary.DataBind();
                lblInvalidClass.Visible = false;
            }
            catch
            {
                lblInvalidClass.Visible = true;
            }
        }

        // Method to check out a book as the current user
        protected void btnCheckOutBook_Click(object sender, EventArgs e)
        {
            try
            {
                Book.CheckOutBook(Users.GetCurrentUserId(userName), Convert.ToInt32(tbCheckOutBook.Text.Trim()));
                UpdateCheckedOutGV(userName);
                lblInvalidBookID2.Visible = false;
            }
            catch
            {
                lblInvalidBookID2.Visible = true;
            }
        }

        // Method to return a checked out book as the current user
        protected void btnReturnBook_Click(object sender, EventArgs e)
        {
            try
            {
                Book.ReturnBook(Users.GetCurrentUserId(userName), Convert.ToInt32(tbReturnBook.Text.Trim()));
                UpdateCheckedOutGV(userName);
                lblInvalidBookID3.Visible = false;
            }
            catch
            {
                lblInvalidBookID3.Visible = true;
            }
        }

        // Method to update current user info
        protected void btnUpdateUserInfo_Click(object sender, EventArgs e)
        {
            try
            {
                bool updated = Users.UpdateCurrentUserInfo(Users.GetCurrentUserId(userName),
                    tbUserFirstname.Text.Trim(), tbUserLastname.Text.Trim(),
                    tbUserEmail.Text.Trim(), tbUserUsername.Text.Trim(), tbUserCurrentPassword.Text.Trim(),
                    tbUserNewPassword.Text.Trim());

                if (updated)
                {
                    userName = tbUserUsername.Text.Trim();
                    UpdateUserInfoGV(userName);
                    lblUserName.Text = userName;
                    lblUserUpdated.Visible = true;
                    lblInvalidCurrentPassword.Visible = false;
                }
                else
                {
                    lblUserUpdated.Visible = false;
                    lblInvalidCurrentPassword.Visible = true;
                }

                lblInvalidInfo.Visible = false;
            }
            catch
            {
                lblInvalidInfo.Visible = true;
            }
        }
    }
}