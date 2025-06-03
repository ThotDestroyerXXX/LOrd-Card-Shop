using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameInp.Value;
            string password = PasswordInp.Value;

            Response<Users> response = UserController.LoginUser(username, password);

            if(!response.Success)
            {
                ErrorLbl.Text = response.Message;
            }
            else
            {
                ErrorLbl.Text = " ";
                Session["user"] = response.Payload;
                if(RememberMeCheck.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = response.Payload.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddDays(3);

                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("HomePage.aspx");
            }
        }
    }
}