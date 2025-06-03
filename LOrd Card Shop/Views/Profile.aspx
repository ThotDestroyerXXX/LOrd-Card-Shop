<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Navbar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LOrd_Card_Shop.Views.Customers.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        window.onpageshow = function (event) {
            if (event.persisted) {
                window.location.reload();
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profileContainer">
        <div class="profileTitle">
            <h1>Profile Page</h1>
        </div>
        <div>
            <div class="inputContainer">
                <asp:Label runat="server" Text="Name" ID="NameLbl" />
                <input type="text" id="NameInp" runat="server" class="inputInput" />
            </div>
            <div class="inputContainer">
                <asp:Label runat="server" Text="Email" ID="EmailLbl" />
                <input type="text" id="EmailInp" runat="server" class="inputInput" />
            </div>
            <div class="inputContainer">
                <asp:Label runat="server" Text="Password" ID="OldPasswordLbl" />
                <input type="password" id="OldPasswordInp" runat="server" class="inputInput" />
            </div>
            <div class="inputContainer" id="NewPasswordContainer" runat="server">
                <asp:Label runat="server" Text="New Password" ID="NewPasswordLbl" />
                <input type="password" id="NewPasswordInp" runat="server" class="inputInput" />
            </div>
            <div class="inputContainer" id="ConfirmPasswordContainer" runat="server">
                <asp:Label runat="server" Text="Confirm Password" ID="ConfirmPasswordLbl" />
                <input type="password" id="ConfirmPasswordInp" runat="server" class="inputInput" />
            </div>
            <div>
                <asp:Label runat="server" Text="Gender" ID="GenderLbl" />
                <asp:RadioButtonList ID="GenderList" runat="server">
                    <asp:ListItem Text="Male" Value="Male" />
                    <asp:ListItem Text="Female" Value="Female" />
                </asp:RadioButtonList>
            </div>
            <div class="errorContainer">
                <asp:Label Text=" " runat="server" ID="ErrorMsg" />
            </div>

            <asp:Button Text="Update" runat="server" CssClass="UpdateBtn" OnClick="UpdateBtn_Click" />
        </div>

    </div>
    <style>
        .profileContainer {
            display: flex;
            min-height: auto;
            flex-direction: column;
            width: 20rem;
            margin: auto;
        }

        .profileTitle {
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

        .inputInput {
            width: auto;
            height: 1.7rem;
            border-radius: 5px;
            border: 1px solid black;
            padding-left: 7px;
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
