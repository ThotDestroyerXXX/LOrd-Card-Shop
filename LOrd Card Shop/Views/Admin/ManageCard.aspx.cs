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
    public partial class ManageCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            string searchParam = Request.QueryString["search"];

            if (user == null || user.UserRole != "admin")
            {
                Response.Redirect("~/Views/LoginPage.aspx");
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
                cardGv.DataSource = response.Payload;
                cardGv.DataBind();
                emptyMsg.Text = string.Empty;
            }
            else
            {
                cardGv.Visible = false;
                emptyMsg.Text = response.Message;
            }

        }

        protected void cardGv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = cardGv.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text;
            if (!string.IsNullOrEmpty(id))
            {
                emptyMsg.Text = string.Empty;
                Response.Redirect("EditCard.aspx?id=" + id);
            }
            else
            {
                emptyMsg.Text = "ID not valid!";
            }
        }

        protected void cardGv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string searchParam = Request.QueryString["search"];
            GridViewRow row = cardGv.Rows[e.RowIndex];
            string id = row.Cells[0].Text;
            CardController.DeleteCardById(id);
            cardGv.EditIndex = -1;
            RefreshGrid(searchParam);
        }

        protected void addCardBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCard.aspx");
        }
    }
}