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
    public partial class OrderQueue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null || user.UserRole != "admin")
            {
                Response.Redirect("/Views/HomePage.aspx");
            }

            if(!IsPostBack)
            {
                RefreshGrid();
            }
        }

        protected void RefreshGrid()
        {
            Response<List<TransactionGroup>> response = TransactionController.GetAllTransaction();
            if (response.Success)
            {
                orderQueueGv.DataSource = response.Payload;
                orderQueueGv.DataBind();
                emptyMsg.Text = string.Empty;
            }
            else
            {
                orderQueueGv.Visible = false;
                emptyMsg.Text = response.Message;
            }

        }

        protected void orderQueueGv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = orderQueueGv.Rows[e.RowIndex];
            string id = row.Cells[0].Text;
            TransactionController.UpdateStatus(id);
            orderQueueGv.EditIndex = -1;
            RefreshGrid();
        }
    }
}