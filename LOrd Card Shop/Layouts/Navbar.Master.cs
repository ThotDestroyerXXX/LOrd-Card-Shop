using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Handlers;
using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Layouts
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null)
            {
                customerLink.Visible = false;
                adminLink.Visible = false;
                LogoutBtn.Visible = false;
                Login.Visible = true;
            }

            if(user != null && user.UserRole == "customer")
            {
                customerLink.Visible = true;
                adminLink.Visible = false;
                LogoutBtn.Visible = true;
                Login.Visible = false;
                UserLbl.Text = "Welcome, " + user.UserName;
            }

            else if (user != null && user.UserRole == "admin")
            {
                customerLink.Visible = false;
                adminLink.Visible = true;
                LogoutBtn.Visible = true;
                Login.Visible = false;
                UserLbl.Text = "Welcome, " + user.UserName;
            }

            else
            {
                customerLink.Visible = false;
                adminLink.Visible = false;
                LogoutBtn.Visible = false;
                Login.Visible = true;
                UserLbl.Text = "Welcome, Guest";
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            if (Response.Cookies["user_cookie"] != null)
            {
                HttpCookie cookie = new HttpCookie("user_cookie");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Session.Abandon();
            Response.Redirect("/Views/LoginPage.aspx");
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if(user == null)
            {
                Response.Redirect("/Views/LoginPage.aspx");
            }
            else if(user.UserRole == "admin")
            {
                Response.Redirect("/Views/Admin/ManageCard.aspx?search=" + SearchInp.Value);
            }
            else if(user.UserRole == "customer")
            {
                Response.Redirect("/Views/Customers/OrderCard.aspx?search=" + SearchInp.Value);
            }
            else
            {
                Response.Redirect("/Views/LoginPage.aspx");
            }
        }
    }
}