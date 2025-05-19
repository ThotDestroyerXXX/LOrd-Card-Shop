using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user != null && (user.UserRole == "customer" || user.UserRole == "admin"))
            {
                WelcomeTitle.InnerText = "Welcome, " + user.UserName;
            }
            else
            {
                WelcomeTitle.InnerText = "Welcome, Guest";
            }
            
        }
    }
}