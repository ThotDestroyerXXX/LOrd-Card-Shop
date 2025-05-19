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

namespace LOrd_Card_Shop.Views
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null || (user.UserRole != "customer" && user.UserRole != "admin"))
            {
                Response.Redirect("HomePage.aspx");
            }

            if (!IsPostBack)
            {
                RefreshGrid();
            }
        }

        protected void RefreshGrid()
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);

            string transactionId = Request.QueryString["id"];

            if (user.UserRole.Equals("customer"))
            {
                int userId = ((Users)Session["user"]).UserID;
                Response<TransactionGroup> response = TransactionController.GetTransactionByCustomerIdAndTransactionId(userId, transactionId);
                if (!response.Success)
                {

                    Response.Redirect("/Views/HomePage.aspx");
                }
                else
                {
                    TransactionGroupRpt.DataSource = response.Payload.Details;
                    TransactionGroupRpt.DataBind();
                    TransactionIdLbl.Text = "Transaction ID : " + response.Payload.Header.TransactionID.ToString();
                    TransactionDateLbl.Text = "Transaction Date : " + response.Payload.Header.TransactionDate.ToString("yyyy-MM-dd");
                    TransactionTotalPriceLbl.Text = "Total Price : " + response.Payload.TotalPrice.ToString("C2");
                    TransactionStatusLbl.Text = "Status : " + response.Payload.Header.Status;
                }
            }
            
            else if(user.UserRole.Equals("admin"))
            {
                Response<TransactionGroup> response = TransactionController.GetTransactionByTransactionId(transactionId);
                if (!response.Success)
                {
                    Response.Redirect("/Views/HomePage.aspx");
                }
                else
                {
                    TransactionGroupRpt.DataSource = response.Payload.Details;
                    TransactionGroupRpt.DataBind();
                    TransactionIdLbl.Text = "Transaction ID : " + response.Payload.Header.TransactionID.ToString();
                    TransactionDateLbl.Text = "Transaction Date : " + response.Payload.Header.TransactionDate.ToString("yyyy-MM-dd");
                    TransactionTotalPriceLbl.Text = "Total Price : " + response.Payload.TotalPrice.ToString("C2");
                    TransactionStatusLbl.Text = "Status : " + response.Payload.Header.Status;
                }
            }
            
            else
            {
                TransactionIdLbl.Text = string.Empty;
                TransactionDateLbl.Text = string.Empty;
                TransactionTotalPriceLbl.Text = string.Empty;
                TransactionStatusLbl.Text = string.Empty;
                Response.Redirect("/Views/HomePage.aspx");
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null)
            {
                Response.Redirect("/Views/HomePage.aspx");
            }
            else if (user.UserRole == "customer")
            {
                Response.Redirect("/Views/Customers/History.aspx");
            }
            else if (user.UserRole == "admin")
            {
                Response.Redirect("/Views/Admin/ViewTransaction.aspx");
            }
            else
            {
                Response.Redirect("/Views/HomePage.aspx");
            }
        }
    }
}