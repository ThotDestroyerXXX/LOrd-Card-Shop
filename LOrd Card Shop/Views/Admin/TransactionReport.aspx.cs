using LOrd_Card_Shop.Controllers;
using LOrd_Card_Shop.Datasets;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Reportings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static LOrd_Card_Shop.Models.CombineModel;

namespace LOrd_Card_Shop.Views.Admin
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = UserController.GetUserFromCookie(Request, Response, Session);
            if (user == null || user.UserRole != "admin")
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

            CrystalReport report = new CrystalReport();

            CrystalReportViewer1.ReportSource = report;

            Response<List<TransactionGroup>> response = TransactionController.GetAllTransaction();

            if(!response.Success)
            {
                EmptyMsg.Text = response.Message;
            }
            else
            {
                DataSet data = GetData(response.Payload);
                report.SetDataSource(data);
            }

            
        }

        private DataSet GetData(List<TransactionGroup> transactions)
        {
            DataSet data = new DataSet();
            var headerTable = data.transactions;
            var detailTable = data.transaction_details;

            foreach (TransactionGroup tg in transactions)
            {
                var hrow = headerTable.NewRow();
                hrow["transaction_id"] = tg.Header.TransactionID;
                hrow["transaction_date"] = tg.Header.TransactionDate;
                hrow["customer_id"] = tg.Header.CustomerID;
                hrow["status"] = tg.Header.Status;
                hrow["grand_total"] = tg.TotalPrice;
                headerTable.Rows.Add(hrow);

                foreach (TransactionDetail td in tg.Details)
                {
                    var drow = detailTable.NewRow();
                    drow["transaction_id"] = td.TransactionID;
                    drow["card_id"] = td.CardID;
                    drow["quantity"] = td.Quantity;
                    int detailSubTotal = (int)(td.Quantity * td.Card.CardPrice);
                    drow["sub_total"] = detailSubTotal;
                    detailTable.Rows.Add(drow);


                }
            }
            return data;
        }
    }
}