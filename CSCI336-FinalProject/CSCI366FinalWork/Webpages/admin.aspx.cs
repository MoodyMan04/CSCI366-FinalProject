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
            // Check if current user is an admin, if not, log out automatically
            CheckUserAdmin();

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

        // Method for checking if current user is an admin
        private void CheckUserAdmin()
        {
            try
            {
                // Log out user if user is not an admin
                if (!Users.CheckUserAdmin(Page.User.Identity.Name))
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("logon.aspx", true);
                }
            }
            catch
            {
                // Log out user if error thrown
                FormsAuthentication.SignOut();
                Response.Redirect("logon.aspx", true);
            }
            
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

        // Method that updates the checked out grid view depending on if the admin wishes to display all or current
        protected void cbDisplayCheckedOutBooks_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisplayCheckedOutBooks.Checked == true)
                UpdateCheckedOutCurrentlyGV();
            else
                UpdateCheckedOutAllGV();
        }

        // Method to add book
        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                Book.AddBook(tbBookTitle.Text.Trim(), tbBookPublisher.Text.Trim(),
                    tbBookLanguage.Text.Trim(), Convert.ToDateTime(tbBookDatePublished.Text.Trim()));
                lblInvalidBookInfo.Visible = false;
                UpdateBookGV();
            }
            catch
            {
                lblInvalidBookInfo.Visible = true;
            }
        }

        // Method to update book
        protected void btnUpdateBook_Click(object sender, EventArgs e)
        {
            try
            {
                Book.UpdateBook(tbBookTitle.Text.Trim(), tbBookPublisher.Text.Trim(),
                    tbBookLanguage.Text.Trim(), Convert.ToDateTime(tbBookDatePublished.Text.Trim()), 
                    Convert.ToInt32(tbBookID.Text.Trim()));
                lblInvalidBookInfo2.Visible = false;
                UpdateBookGV();
            }
            catch
            {
                lblInvalidBookInfo2.Visible = true;
            }
        }

        //Method to delete book
        protected void btnDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                Book.DeleteBook(Convert.ToInt32(tbBookID.Text.Trim()));
                lblInvalidBookID.Visible = false;
                UpdateBookGV();
                UpdateAuthoredByGV();
                UpdateAssociatedWithGV();
                UpdateCheckedOutAllGV();
            }
            catch
            {
                lblInvalidBookInfo.Visible = true;
            }
        }

        //Method to add user
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                Users.AddUser(tbUserFirstname.Text.Trim(), tbUserLastname.Text.Trim(), 
                    chkUserIsAdmin.Checked, tbUserEmail.Text.Trim(),
                    tbUserUsername.Text.Trim(), tbUserPassword.Text.Trim());
                lblInvalidUserInfo.Visible = false;
                UpdateUsersGV();
            }
            catch
            {
                lblInvalidUserInfo.Visible = true;
            }
        }

        //Method to update user
        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                Users.UpdateUser(tbUserFirstname.Text.Trim(), tbUserLastname.Text.Trim(), 
                    chkUserIsAdmin.Checked, tbUserEmail.Text.Trim(),
                    tbUserUsername.Text.Trim(), tbUserPassword.Text.Trim(),
                    Convert.ToInt32(tbUserID.Text.Trim()));
                lblInvalidUserInfo2.Visible = false;
                UpdateUsersGV();
            }
            catch
            {
                lblInvalidUserInfo2.Visible = true;
            }
        }

        //Method to delete user
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                Users.DeleteUser(Convert.ToInt32(tbUserID.Text.Trim()));
                lblInvalidUserID.Visible = false;
                UpdateUsersGV();
                UpdateCheckedOutAllGV();
            }
            catch
            {
                lblInvalidUserID.Visible = true;
            }
        }

        // Method for adding Author
        protected void btnAddAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                Author.AddAuthor(tbAuthorFirstname.Text.Trim(), tbAuthorLastname.Text.Trim());
                lblInvalidAuthorInfo.Visible = false;
                UpdateAuthorGV();
            }
            catch
            {
                lblInvalidAuthorInfo.Visible = true;
            }
        }

        // Method for updating an Author
        protected void btnUpdateAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                Author.UpdateAuthor(tbAuthorFirstname.Text.Trim(), tbAuthorLastname.Text.Trim(),
                    Convert.ToInt32(tbAuthorID.Text.Trim()));
                lblInvalidAuthorInfo2.Visible = false;
                UpdateAuthorGV();
            }
            catch
            {
                lblInvalidAuthoredByInfo2.Visible = true;
            }
        }

        // Method for deleting an Author
        protected void btnDeleteAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                Author.DeleteAuthor(Convert.ToInt32(tbAuthorID.Text.Trim()));
                lblInvalidAuthorID.Visible = false;
                UpdateAuthorGV();
                UpdateAuthoredByGV();
            }
            catch
            {
                lblInvalidAuthorID.Visible = true;
            }
        }

        // Method for adding Class
        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            try
            {
                Class.AddClass(tbClassName.Text.Trim(), tbClassDescription.Text.Trim());
                lblInvalidClassInfo.Visible = false;
                UpdateClassGV();
            }
            catch
            {
                lblInvalidClassInfo.Visible = true;
            }
        }

        // Method for updating Class
        protected void btnUpdateClass_Click(object sender, EventArgs e)
        {
            try
            {
                Class.UpdateClass(tbClassName.Text.Trim(), tbClassDescription.Text.Trim(),
                    Convert.ToInt32(tbClassID.Text.Trim()));
                lblInvalidClassInfo2.Visible = false;
                UpdateClassGV();
            }
            catch
            {
                lblInvalidClassInfo2.Visible = true;
            }
        }

        // Method for deleting Class
        protected void btnDeleteClass_Click(object sender, EventArgs e)
        {
            try
            {
                Class.DeleteClass(Convert.ToInt32(tbClassID.Text.Trim()));
                lblInvalidClassID.Visible = false;
                UpdateClassGV();
                UpdateAssociatedWithGV();
            }
            catch
            {
                lblInvalidClassID.Visible = true;
            }
        }

        // Method to add AuthoredBy
        protected void btnAddAuthoredBy_Click(object sender, EventArgs e)
        {
            try
            {
                Book.AddAuthoredBy(Convert.ToInt32(tbAuthorByAuthorID.Text.Trim()), Convert.ToInt32(tbAuthoredByBookID.Text.Trim()));
                lblInvalidAuthoredByInfo.Visible = false;
                UpdateAuthoredByGV();
            }
            catch
            {
                lblInvalidAuthoredByInfo.Visible = true;
            }
        }

        // Method to Delete AuthoredBy
        protected void btnDeleteAuthoredBy_Click(object sender, EventArgs e)
        {
            try
            {
                Book.DeleteAuthoredBy(Convert.ToInt32(tbAuthorByAuthorID.Text.Trim()), Convert.ToInt32(tbAuthoredByBookID.Text.Trim()));
                lblInvalidAuthoredByInfo2.Visible = false;
                UpdateAuthoredByGV();
            }
            catch
            {
                lblInvalidAuthoredByInfo2.Visible = true;
            }
        }

        protected void btnAddAssociatedWith_Click(object sender, EventArgs e)
        {
            try
            {
                Book.AddAssociatedWith(Convert.ToInt32(tbAssociatedWithBookID.Text.Trim()), Convert.ToInt32(tbAssociatedWithClassID.Text.Trim()), chkIsRequired.Checked);
                lblInvalidAssociationInfo.Visible = false;
                UpdateAssociatedWithGV();
            }
            catch
            {
                lblInvalidAssociationInfo.Visible = true;
            }
        }

        protected void btnUpdateAssociatedWith_Click(object sender, EventArgs e)
        {
                Book.UpdateAssociatedWith(Convert.ToInt32(tbAssociatedWithBookID.Text.Trim()), Convert.ToInt32(tbAssociatedWithClassID.Text.Trim()), 
                    chkIsRequired.Checked);
                lblInvalidAssociationInfo2.Visible = false;
                UpdateAssociatedWithGV();
        }

        protected void btnDeleteAssociatedWith_Click(object sender, EventArgs e)
        {
            try
            {
                Book.DeleteAssociatedWith(Convert.ToInt32(tbAssociatedWithBookID.Text.Trim()), Convert.ToInt32(tbAssociatedWithClassID.Text.Trim()));
                lblInvalidAssociationInfo3.Visible = false;
                UpdateAssociatedWithGV();
            }
            catch
            {
                lblInvalidAssociationInfo3.Visible = true;
            }
        }
    }
}