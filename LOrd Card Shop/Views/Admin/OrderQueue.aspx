<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="LOrd_Card_Shop.Views.Admin.OrderQueue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="orderQueueContainer">
        <div>
            <h1>Card List</h1>
        </div>
        <div class="orderQueueWrapper">
            <asp:GridView runat="server" AutoGenerateColumns="false" ID="orderQueueGv" OnRowUpdating="orderQueueGv_RowUpdating" CellPadding="8" CssClass="cellTable">
                <Columns>
                    <asp:BoundField DataField="Header.TransactionID" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="Header.Users.UserID" HeaderText="Customer ID" />
                    <asp:BoundField DataField="Header.Users.UserName" HeaderText="Customer Name" />
                    <asp:BoundField DataField="Header.Users.UserEmail" HeaderText="Customer Email" />
                    <asp:BoundField DataField="Header.TransactionDate" HeaderText="Transaction Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText="Cards Ordered">
                        <ItemTemplate>
                            <asp:Repeater runat="server" DataSource='<%# Eval("Details") %>'>
                                <ItemTemplate>
                                    - <%# Eval("Card.CardName") %><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C2}" />
                    <asp:BoundField DataField="Header.Status" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="updateBtn" runat="server" Text="Handle" CommandName="Update" Visible='<%# Eval("Header.Status").ToString() == "unhandled" %>' CssClass="updateBtn" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label Text=" " runat="server" ID="emptyMsg" />
        </div>
    </div>
    <style>
        .orderQueueContainer {
            padding-left: 0.5rem;
            padding-right: 0.5rem;
        }

        .orderQueueWrapper {
            display: flex;
            flex-direction: column;
            gap: 10px;
        }

        .cellTable td {
            word-break: break-all;
        }

        .updateBtn {
            width: 5rem;
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
