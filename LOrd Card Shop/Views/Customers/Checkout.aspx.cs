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
    public partial class Checkout : System.Web.UI.Page
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
            int userId = UserController.GetUserFromCookie(Request, Response, Session).UserID;
            Response<List<Carts>> response = CartController.GetCartsByUserId(userId);
            if (response.Success)
            {
                CartRpt.DataSource = response.Payload;
                CartRpt.DataBind();
                EmptyMsg.Text = string.Empty;
                PriceContainer.Visible = true;
                ButtonContainer.Visible = true;
                TotalPriceLbl.Text = "Total Price : " + response.Payload.Sum(item => item.Quantity * item.Card.CardPrice).ToString("C2");
            }
            else
            {
                Response.Redirect("/Views/HomePage.aspx");
                CartRpt.Visible = false;
                PriceContainer.Visible = false;
                ButtonContainer.Visible = false;
                EmptyMsg.Text = response.Message;

            }
        }

        protected void CheckoutCartBtn_Click(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null || user.UserRole != "customer")
            {
                Response.Redirect("/Views/HomePage.aspx");
            }

            else
            {
                int userId = user.UserID;
                Response<TransactionHeader> response = TransactionController.CheckoutCard(userId);


                if (!response.Success)
                {
                    Response.Redirect("/Views/HomePage.aspx");
                }
                else
                {
                    Response.Redirect("History.aspx");
                }
            }
        }
    }
}