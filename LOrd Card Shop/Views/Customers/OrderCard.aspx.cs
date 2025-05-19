using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views.Customers
{
    public partial class OrderCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null || user.UserRole != "customer")
            {
                Response.Redirect("/Views/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                RefreshGrid();
            }
        }

        protected void RefreshGrid()
        {
            Response<List<Card>> response = CardController.GetAllCards();
            if (response.Success)
            {
                CardRpt.DataSource = response.Payload;
                CardRpt.DataBind();
                EmptyMsg.Text = string.Empty;
            }
            else
            {
                CardRpt.Visible = false;
                EmptyMsg.Text = response.Message;
            }
        }

        protected void CardButton_Command(object sender, CommandEventArgs e)
        {
            string cardId = e.CommandArgument.ToString();
            int userId = UserController.GetUserFromCookie(Request, Response, Session).UserID;

            if (e.CommandName == "Details")
            {
                Response.Redirect($"CardDetails.aspx?id={cardId}");
            }

            else if(e.CommandName == "Add")
            {
                Response<Carts> response = CartController.AddCardtoCart(cardId, userId);
                Response.Redirect("OrderCard.aspx");
            }
        }
    }
}