<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="backBtnContainer">
        <asp:Button Text="< Back" runat="server" CssClass="backBtn" OnClick="BackBtn_Click" />
    </div>
    <div class="detailContainer">
        <h1 id="detailTitle">Transaction Details</h1>
        <div class="detailWrapper">
            <div class="headerContainer">
                <asp:Label runat="server" ID="TransactionIdLbl"></asp:Label>
                <asp:Label runat="server" ID="TransactionDateLbl"></asp:Label>
                <asp:Label runat="server" ID="TransactionTotalPriceLbl"></asp:Label>
                <asp:Label runat="server" ID="TransactionStatusLbl"></asp:Label>
            </div>
            <div class="transactionGroupContainer">
                <asp:Repeater ID="TransactionGroupRpt" runat="server">
                    <ItemTemplate>
                        <div class="transactionGroup">
                            <div class="cardBody">
                                <p class="cardTitle"><%# Eval("Card.CardName") %></p>
                                <p><strong><%# Eval("Card.CardPrice", "{0:C2}") %></strong></p>
                                <p><strong>Quantity: <%# Eval("Quantity") %></strong></p>
                                <p class="cardText">type : <%# Eval("Card.CardType") %></p>
                                <p class="cardText">is foiled : <%# Convert.ToString(Eval("Card.isFoil")) == "yes" ? "yes" : "no" %></p>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <style>
        .backBtnContainer {
            justify-content: left;
        }

        .backBtn {
            border: none;
            background-color: transparent;
            font-size: 1em;
            cursor: pointer;
        }

        .detailContainer {
            display: flex;
            flex-direction: column;
            justify-content: center;
            text-align: center;
        }

        .detailWrapper {
            display: flex;
            flex-direction: column;
            justify-content: center;
            text-align: center;
            gap: 2rem;
        }

        .headerContainer {
            display: flex;
            flex-direction: column;
            font-size: 1.2em;
        }

        .transactionGroupContainer {
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
            justify-content: center;
            gap: 1rem;
        }

        .transactionGroup {
            width: 20rem;
            min-height: 10rem;
            display: flex;
            flex-direction: column;
            align-items: center;
            text-align: center;
            border-radius: 10px;
            box-shadow: 0px 0px 5px 3px rgba(0, 0, 0, 0.2);
            padding: 0.5rem;
        }

        .cardTitle {
            font-weight: 600;
            font-size: 1.5em;
        }

        .cardBody {
            word-break: break-all;
            line-height: 0.5rem;

        }
    </style>
</asp:Content>
