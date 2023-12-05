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
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Update current return date
            lblCurrentReturnDate.Text = Convert.ToString(Book.return_date);

            // Update Book grid view
            gvBooks.DataSource = Book.GetBooksAll();
            gvBooks.DataBind();
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("logon.aspx", true);
        }
    }
}