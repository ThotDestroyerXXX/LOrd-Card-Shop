using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LOrd_Card_Shop.Models.CombineModel;

namespace LOrd_Card_Shop.Views.Admin
{
    public partial class ViewTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null || user.UserRole != "admin")
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
            Response<List<TransactionGroup>> response = TransactionController.GetAllTransaction();
            if (response.Success)
            {
                TransactionGroupRpt.DataSource = response.Payload;
                TransactionGroupRpt.DataBind();
                EmptyMsg.Text = string.Empty;
            }
            else
            {
                TransactionGroupRpt.Visible = false;
                EmptyMsg.Text = response.Message;
            }
        }

        protected void HistoryBtn_Command(object sender, CommandEventArgs e)
        {
            string transactionId = e.CommandArgument.ToString();

            if (e.CommandName == "Details")
            {
                Response.Redirect("/Views/TransactionDetailPage.aspx?id=" + transactionId);
            }
        }
    }
}