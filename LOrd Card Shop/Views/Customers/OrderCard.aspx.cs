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
            string searchParam = Request.QueryString["search"];
            if (user == null || user.UserRole != "customer")
            {
                Response.Redirect("/Views/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                RefreshGrid(searchParam);
            }
        }

        protected void RefreshGrid(string searchParam)
        {

            Response<List<Card>> response = (string.IsNullOrEmpty(searchParam) ? CardController.GetAllCards() : CardController.GetAllCardsBySearchFilter(searchParam));

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
                // Get the reference to the button that triggered the event
                Button clickedButton = (Button)sender;

                // Find the parent container (e.g., NamingContainer)
                Control parentContainer = clickedButton.NamingContainer;

                // Locate the QuantityTb TextBox within the same container
                TextBox quantity = (TextBox)parentContainer.FindControl("QuantityTb");

                int tes;

                if (string.IsNullOrWhiteSpace(quantity.Text))
                {
                    Response<Carts> response = CartController.AddCardtoCart(cardId, userId, 1.ToString());
                    Response.Redirect("OrderCard.aspx");
                }
                
                else if (quantity != null && int.TryParse(quantity.Text, out tes) && tes > 0)
                {
                    Response<Carts> response = CartController.AddCardtoCart(cardId, userId, quantity.Text);
                    Response.Redirect("OrderCard.aspx");
                }

                
            }
        }
    }
}