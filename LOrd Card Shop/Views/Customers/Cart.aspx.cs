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
    public partial class Cart : System.Web.UI.Page
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
                ButtonContainer.Visible = true;
            }
            else
            {
                CartRpt.Visible = false;
                ButtonContainer.Visible = false;
                EmptyMsg.Text = response.Message;
            }
        }

        protected void CartButton_Command(object sender, CommandEventArgs e)
        {
            string cartId = e.CommandArgument.ToString();

            if(e.CommandName == "Subtract")
            {
                CartController.SubtractCartQuantity(cartId);
            }
            else if(e.CommandName == "Add")
            {
                CartController.AddCartQuantity(cartId);
            }
            else if(e.CommandName == "Remove")
            {
                CartController.RemoveCart(cartId);
            }

            Response.Redirect("Cart.aspx");

        }

        protected void CheckoutCartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            int userId = UserController.GetUserFromCookie(Request, Response, Session).UserID;

            CartController.RemoveAllCarts(userId);
            Response.Redirect("Cart.aspx");
        }
    }
}