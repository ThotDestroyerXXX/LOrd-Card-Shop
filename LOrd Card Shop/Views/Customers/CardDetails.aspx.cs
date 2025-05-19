using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views.Customers
{
    public partial class CardDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null || user.UserRole != "customer")
            {
                Response.Redirect("/Views/LoginPage.aspx");
            }

            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (id == null)
                {
                    Response.Redirect("OrderCard.aspx");
                }
                else
                {
                    Response<Card> response = CardController.GetCardById(id);

                    if (!response.Success)
                    {
                        Response.Redirect("OrderCard.aspx");
                    }
                    else
                    {
                        NameLbl.Text += response.Payload.CardName;
                        PriceLbl.Text += response.Payload.CardPrice.ToString("C2");
                        DescriptionLbl.Text += response.Payload.CardDesc;
                        TypeLbl.Text += response.Payload.CardType;
                        FoilLbl.Text += (response.Payload.isFoil ? "yes" : "no");
                    }
                }
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderCard.aspx");
        }
    }
}