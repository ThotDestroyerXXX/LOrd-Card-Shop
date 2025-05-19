<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageCard.aspx.cs" Inherits="LOrd_Card_Shop.Views.Admin.ManageCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cardListContainer">
        <div>
            <h1>Card List</h1>
        </div>
        <div class="cardListWrapper">
            <asp:Button Text="Add Card" runat="server" OnClick="addCardBtn_Click" ID="AddBtn" CssClass="AddBtn" />
            <asp:GridView runat="server" AutoGenerateColumns="false" ID="cardGv" OnRowEditing="cardGv_RowEditing" OnRowDeleting="cardGv_RowDeleting" CellPadding="8" CssClass="cellTable">
                <Columns>
                    <asp:BoundField DataField="CardID" HeaderText="ID" />
                    <asp:BoundField DataField="CardName" HeaderText="Name" />
                    <asp:BoundField DataField="CardPrice" HeaderText="Price"  />
                    <asp:BoundField DataField="CardDesc" HeaderText="Description" HeaderStyle-Width="150px" />
                    <asp:BoundField DataField="CardType" HeaderText="Card Type"  />
                    <asp:BoundField DataField="isFoil" HeaderText="Is Foil" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="editBtn" runat="server" Text="Edit" CommandName="Edit" />
                            <asp:Button ID="deleteBtn" runat="server" Text="Delete" CommandName="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label Text=" " runat="server" ID="emptyMsg" />
        </div>
    </div>
    <style>
        .cardListContainer {
            padding-left: 0.5rem;
            padding-right: 0.5rem;
        }
        .cardListWrapper {
            display: flex;
            flex-direction: column;
            gap: 10px;
        }

        .AddBtn {
            width: 7rem;
            height: 2rem;
            border-radius: 5px;
            border: none;
            background-color: orange;
            color: white;
            font-weight: 600;
            cursor: pointer;
        }

        .cellTable td {
            word-break: break-all;
        }
    </style>
</asp:Content>

