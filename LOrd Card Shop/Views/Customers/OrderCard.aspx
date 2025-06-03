<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderCard.aspx.cs" Inherits="LOrd_Card_Shop.Views.Customers.OrderCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cardContainer">
        <div class="cardRow">
            <asp:Repeater ID="CardRpt" runat="server">
                <ItemTemplate>
                    <div class="cardTemplateContainer">
                        <div class="cardBody">
                            <h1 class="cardTitle"><%# Eval("CardName") %></h1>
                            <p class="cardText"><strong><%# Eval("CardPrice", "{0:C2}") %></strong></p>
                            <p class="cardText">type : <%# Eval("CardType") %></p>
                            <p class="cardText">is foiled : <%# Convert.ToString(Eval("isFoil")) == "yes" ? "yes" : "no" %></p>
                        </div>
                        <div>
                            <asp:Label Text="Quantity : " runat="server" />
                            <asp:TextBox runat="server" ID="QuantityTb" />
                        </div>
                        <div class="buttonContainer">
                            <asp:Button Text="Add to Cart" runat="server" CssClass="buttonCard" ID="AddCardBtn" CommandName="Add" OnCommand="CardButton_Command" CommandArgument='<%# Eval("CardID") %>' />
                            <asp:Button Text="Details" runat="server" CssClass="buttonCard" CommandName="Details" 
                        CommandArgument='<%# Eval("CardID") %>' 
                        OnCommand="CardButton_Command" ID="DetailCardBtn" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:Label Text=" " runat="server" ID="EmptyMsg" />
    </div>
    
    <style>

        .cardRow {
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
            gap: 1rem;
            justify-content: center;
        }

        

        .cardCardContainer {
            background-color: red;
            width: 20rem;
            height: 20rem;
        }

        .cardTemplateContainer {
            width: 20rem;
            min-height: 10rem;
            display: flex;
            flex-direction: column;
            align-items: center;
            text-align: center;
            border-radius: 10px;
            box-shadow: 0px 0px 5px 3px rgba(0, 0, 0, 0.2);
            padding: 0.5rem;
            gap: 0.5rem;
        }

        .cardTitle {
            font-weight: 600;
            font-size: 1.5em;
        }

        .cardBody {
            word-break: break-all;
            line-height: 0.8rem;
        }

        .buttonContainer {
            display: inline-grid;
            grid-template-columns: 1fr 1fr;
            grid-gap: 5px;
            width: inherit;
            padding-left: 1rem;
            padding-right: 1rem;
        }

        .buttonCard {
            height: 2rem;
            border-radius: 5px;
            border: none;
            background-color: orange;
            color: white;
            font-weight: 600;
            cursor: pointer;
        }
    </style>
</asp:Content>
