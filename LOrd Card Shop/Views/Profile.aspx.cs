using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views.Customers
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null)
            {
                Response.Redirect("/Views/HomePage.aspx");
            }

            if(!IsPostBack)
            {
                if (user != null)
                {
                    NameInp.Value = user.UserName;
                    EmailInp.Value = user.UserEmail;
                    GenderList.Text = user.UserGender ?? "Female";
                }
            }
            

        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null)
            {
                Response.Redirect("/Views/HomePage.aspx");
            }
            string username = NameInp.Value;
            string email = EmailInp.Value;
            string oldPassword = OldPasswordInp.Value;
            string newPassword = NewPasswordInp.Value;
            string confirmPassword = ConfirmPasswordInp.Value;
            string gender = GenderList.Text;

            Response<Users> response = UserController.UpdateUser(user.UserID, username, email, oldPassword, user.UserPassword, newPassword, confirmPassword, gender);


            ErrorMsg.Text = response.Message;
            ErrorMsg.ForeColor = response.Success ? Color.Green : Color.Red;

            if (response.Success)
            {
                Session["user"] = response.Payload;
                OldPasswordInp.Value = "";
                NewPasswordInp.Value = "";
                ConfirmPasswordInp.Value = "";
            }
        }
    }
}