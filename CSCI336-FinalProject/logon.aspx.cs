using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSCI336_FinalProject;
using CSCI336_FinalProject.CSCI366FinalWork.Objects;

namespace CSCI336_FinalProject
{
    public partial class logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Method that redirects user based on login credentials
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            // Use Users.Login method to get login status (0 = fail, 1 = member, 2 = admin)
            int loginStatus = Users.Login(Login1.UserName, Login1.Password);

            switch (loginStatus)
            {
                case 0:
                    Response.Redirect("logon.aspx", true);
                    break;
                case 1:
                    FormsAuthentication.SetAuthCookie(Login1.UserName, true);
                    Response.Redirect("~/CSCI366FinalWork/Webpages/member.aspx", true);
                    break;
                case 2:
                    FormsAuthentication.SetAuthCookie(Login1.UserName, true);
                    Response.Redirect("~/CSCI366FinalWork/Webpages/admin.aspx", true);
                    break;
            }
        }
    }
}