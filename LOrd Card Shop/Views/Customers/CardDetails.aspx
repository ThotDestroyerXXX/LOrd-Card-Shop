<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="CardDetails.aspx.cs" Inherits="LOrd_Card_Shop.Views.Customers.CardDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="backBtnContainer">
        <asp:Button Text="< Back" runat="server" CssClass="backBtn" OnClick="BackBtn_Click" />
    </div>
    <div class="detailContainer">
        <h1 id="detailTitle">Card Details</h1>
        <div class="cardContainer">
            <asp:Label Text="Card Name : " runat="server" ID="NameLbl" />
            <asp:Label Text="Card Price : " runat="server" ID="PriceLbl" />
            <asp:Label Text="Card Description : " runat="server" ID="DescriptionLbl" />
            <asp:Label Text="Card Type : " runat="server" ID="TypeLbl" />
            <asp:Label Text="Is the Card Foiled? : " runat="server" ID="FoilLbl" />
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

        .cardContainer {
            display: flex;
            flex-direction: column;
            justify-content: center;
            text-align: center;
            gap: 0.5rem;
            font-size: 1.3em;
        }
    </style>
</asp:Content>
