<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="EditCard.aspx.cs" Inherits="LOrd_Card_Shop.Views.Admin.EditCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="updateCardContainer">
        <div class="updateCardTitle">
            <h1>Edit Card</h1>
        </div>
        <div>
            <div class="inputContainer">
                <asp:Label Text="Card Name" runat="server" ID="NameLbl" />
                <input type="text" id="NameInp" runat="server" />
            </div>
            <div class="inputContainer">
                <asp:Label Text="Card Price" runat="server" ID="PriceLbl" />
                <input type="text" id="PriceInp" runat="server" />
            </div>
            <div class="inputContainer">
                <asp:Label Text="Card Description" runat="server" ID="DescriptionLbl" />
                <asp:TextBox ID="DescriptionInp" runat="server" TextMode="MultiLine" lines="10" cols="10" Wrap="true" CssClass="DescriptionInp" />
            </div>
            <div class="inputContainer">
                <asp:Label Text="Card Type" runat="server" ID="TypeLbl" />
                <asp:RadioButtonList ID="TypeList" runat="server">
                    <asp:ListItem Text="Spell" Value="Spell" Selected="true" />
                    <asp:ListItem Text="Monster" Value="Monster" />
                </asp:RadioButtonList>
            
            </div>
            <div class="inputContainer">
                <asp:Label Text="Is the card foiled?" runat="server" ID="FoilLbl" />
                <asp:RadioButtonList ID="FoilList" runat="server">
                    <asp:ListItem Text="Yes" Value="yes" Selected="true" />
                    <asp:ListItem Text="No" Value="no" />
                </asp:RadioButtonList>
            </div>
            <div class="errorContainer">
                <asp:Label Text=" " runat="server" ID="ErrorMsg" />
            </div>
        
            <asp:Button Text="Update Card" runat="server" OnClick="UpdateCardBtn_Click" CssClass="UpdateBtn" />
        </div>
    </div>
    <style>
        .updateCardContainer {
            display: flex;
            flex-direction: column;
            width: 20rem;
            margin: auto;
        }

        .updateCardTitle {
            justify-content: center;
            display: flex;
            align-items: center;
        }

        .inputContainer {
            display: flex;
            flex-direction: column;
            gap: 5px;
            margin-bottom: 1rem;
        }

        #NameInp, #PriceInp, .DescriptionInp, #TypeList, #FoilList {
            width: auto;
            height: 1.7rem;
            border-radius: 5px;
            border: 1px solid black;
            padding-left: 7px;
        }

        .DescriptionInp {
            resize: vertical;
        }

        .UpdateBtn {
            width: 100%;
            height: 2rem;
            border-radius: 5px;
            border: none;
            background-color: orange;
            color: white;
            cursor: pointer;
            font-weight: 600;
        }

        .errorContainer {
            margin-bottom: 1rem;
            color: red;
            text-align: center;
        }
    </style>
</asp:Content>
