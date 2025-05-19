<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="ViewTransaction.aspx.cs" Inherits="LOrd_Card_Shop.Views.Admin.ViewTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="historyContainer">
        <h1 id="HistoryTitle">Transaction History</h1>
        <div>
            <hr class="hrLine" />
            <asp:Repeater ID="TransactionGroupRpt" runat="server">
                <ItemTemplate>
                    <div class="transactionGroup">
                        <div class="textGroup">
                            <p>Transaction ID : <%# Eval("Header.TransactionID") %></p>
                            <p>User ID : <%# Eval("Header.CustomerID") %></p>
                            <p>User Name : <%# Eval("Header.Users.UserName") %></p>
                            <p>User Email : <%# Eval("Header.Users.UserEmail") %></p>
                            <p>Transaction Date: <%# Eval("Header.TransactionDate", "{0:yyyy-MM-dd}") %></p>
                            <p>Status : <%# Eval("Header.Status") %></p>
                            <p>Ordered <%# Eval("TotalQuantity") %> item(s)</p>
                            <p>Total Price : <%# Eval("TotalPrice", "{0:C2}") %></p>
                        </div>
                        <asp:Button Text="Detail" runat="server" CssClass="detailBtn" CommandName="Details" CommandArgument='<%# Eval("Header.TransactionID") %>' OnCommand="HistoryBtn_Command" />
                    </div>
                    <hr class="hrLine" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:Label Text=" " runat="server" ID="EmptyMsg" />
    </div>
    <style>
        .historyContainer {
            display: flex;
            flex-direction: column;
            width: 80vw;
            margin: auto;
            gap: 1rem;
        }

        #HistoryTitle {
            justify-content: center;
            display: flex;
            align-items: center;
        }

        .hrLine {
            border: 1px dashed black;
        }

        .transactionGroup {
            display: flex;
            flex-direction: column;
            gap: 1rem;
        }

        .detailBtn {
            width: 100%;
            height: 2rem;
            border-radius: 5px;
            border: none;
            background-color: orange;
            color: white;
            cursor: pointer;
            font-weight: 600;
        }
    </style>
</asp:Content>
