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
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameInp.Value;
            string email = EmailInp.Value;
            string password = PasswordInp.Value;
            string confirmPassword = ConfirmInp.Value;
            string gender = GenderList.SelectedValue;

            Response<Users> response = UserController.RegisterUser(username, email, password, confirmPassword, gender);

            if(!response.Success)
            {
                ErrorLbl.Text = response.Message;
            }

            else
            {
                ErrorLbl.Text = " ";
                Session["user"] = response.Payload;

                Response.Redirect("HomePage.aspx");
            }
        }
    }
}