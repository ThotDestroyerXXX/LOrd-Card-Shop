using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views.Admin
{
    public partial class AddCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null || user.UserRole != "admin")
            {
                Response.Redirect("/Views/LoginPage.aspx");
            }
        }

        protected void AddCardBtn_Click(object sender, EventArgs e)
        {
            string name = NameInp.Value;
            string price = PriceInp.Value;
            string description = DescriptionInp.Text;
            string type = TypeList.SelectedValue;
            string foil = FoilList.SelectedValue;

            Response<Card> response = CardController.CreateCard(name, price, description, type, foil);

            if(!response.Success)
            {
                ErrorMsg.Text = response.Message;
            }

            else
            {
                Response.Redirect("ManageCard.aspx");
            }
        }
    }
}