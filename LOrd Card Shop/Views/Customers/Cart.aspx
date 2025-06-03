<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="LOrd_Card_Shop.Views.Customers.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        window.onpageshow = function(event) {
            if (event.persisted) {
                window.location.reload();
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cartRow">
        <h1 id="cartTitle">Your Carts</h1>
        <div>
            <div class="clearCart">
                <asp:Button Text="Clear Cart" runat="server" ID="ClearCartBtn" OnClick="ClearCartBtn_Click" CssClass="clearCartBtn" />
            </div>
            <hr id="fistHr" />
            <asp:Repeater ID="CartRpt" runat="server">
                <ItemTemplate>
                    <div class="cartTemplateContainer">
                        <div class="cartBody">
                            <h1 class="cartTitle"><%# Eval("Card.CardName") %></h1>
                            <p class="cartText"><strong><%# Eval("Card.CardPrice", "{0:C2}") %></strong></p>
                            <p class="cartText">type : <%# Eval("Card.CardType") %></p>
                            <p class="cartText">is foiled : <%# Convert.ToString(Eval("Card.isFoil")) == "yes" ? "yes" : "no" %></p>
                        </div>

                        <div class="cartAddRemoveButton">
                            <div class="cartAddSubtractBtn">
                                <asp:Button Text="-" runat="server" CssClass="changeBtn subtractBtn" CommandName="Subtract" OnCommand="CartButton_Command" CommandArgument='<%# Eval("CartID") %>' />
                                <p class="cartText"><%# Eval("Quantity") %></p>
                                <asp:Button Text="+" runat="server" CssClass="changeBtn addBtn" CommandName="Add" OnCommand="CartButton_Command" CommandArgument='<%# Eval("CartID") %>' />
                            </div>
                            <div class="cartRemoveButton">
                                <asp:Button Text="Remove" runat="server" CssClass="removeBtn subtractBtn" CommandName="Remove" OnCommand="CartButton_Command" CommandArgument='<%# Eval("CartID") %>' />
                            </div>
                        </div>
                    </div>
                    <hr id="hrLine" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="buttonContainer" id="ButtonContainer" runat="server">
            <asp:Button Text="Checkout" runat="server" CssClass="buttonCart" ID="CheckoutCartBtn" OnClick="CheckoutCartBtn_Click" />
        </div>
        <asp:Label Text=" " runat="server" ID="EmptyMsg" />
    </div>

    <style>
        .cartRow {
            display: flex;
            flex-direction: column;
            flex-wrap: wrap;
            gap: 1rem;
            justify-content: center;
            width: 80vw;
            margin: auto;
        }

        #cartTitle {
            text-align: center;
        }

        #fistHr:first-child {
            border: 1px dashed black;
        }

        #hrLine {
            border: 1px dashed black;
        }

        .clearCartBtn {
            background-color: orangered;
            color: white;
            padding: 0.6rem;
            border-radius: 5px;
            border: none;
            cursor: pointer;
            font-size: 1.1em;
        }

        .cardCardContainer {
            background-color: red;
            width: 20rem;
            height: 20rem;
        }

        .cartTemplateContainer {
            display: flex;
            flex-direction: row;
            justify-content: space-between;
        }


        .cartAddRemoveButton {
            display: flex;
            flex-direction: row;
            gap: 2rem;
            align-self: end;
            height: 2rem;
        }

        .cartAddSubtractBtn {
            display: flex;
            flex-direction: row;
            align-items: center;
            gap: 1rem;
        }

        .cartRemoveButton {
            display: flex;
            
        }

        .removeBtn {
            border-radius: 5px;
            border: none;
            color: white;
            padding: 0.5rem;
            cursor: pointer;
        }

        .changeBtn {
            width: 1.7rem;
            height: 1.7rem;
            border-radius: 5px;
            border: none;
            color: white;
            font-size: 1em;
            cursor: pointer;
        }

        .addBtn {
            background-color: limegreen;
        }

        .subtractBtn {
            background-color: orangered;
        }


        .cartTitle {
            font-weight: 600;
            font-size: 1.5em;
        }

        .cartBody {
            word-break: break-all;
            line-height: 0.8rem;
        }

        .buttonContainer {
            width: inherit;
            display: flex;
            justify-content: center;
        }

        .buttonCart {
            width: inherit;
            height: 2.5rem;
            font-size: 1em;
            border-radius: 5px;
            border: none;
            background-color: orange;
            color: white;
            font-weight: 600;
            cursor: pointer;
        }

        .totalPrice {
            font-size: 1.3em;
        }
    </style>
</asp:Content>
