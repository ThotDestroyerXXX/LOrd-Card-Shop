<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="registerContainer">
        <div class="registerTitle">
            <h1>Register Now</h1>
        </div>
        <form id="form1" runat="server">
            <div class="inputContainer">
                <asp:Label Text="Username" runat="server" ID="UsernameLbl" />
                <input id="UsernameInp" type="text" runat="server" placeholder="Username" />
            </div>
            <div class="inputContainer">
                <asp:Label Text="Email" runat="server" ID="EmailLbl" />
                <input id="EmailInp" type="text" runat="server" placeholder="Email" />
            </div>
            <div class="inputContainer">
                <asp:Label Text="Password" runat="server" ID="PasswordLbl" />
                <input id="PasswordInp" type="password" runat="server" placeholder="Password" />
            </div>
            <div class="inputContainer">
                <asp:Label Text="Confirm Password" runat="server" ID="ConfirmLbl" />
                <input id="ConfirmInp" type="password" runat="server" placeholder="Confirm Password" />
            </div>
            <div class="inputContainer">
                <asp:Label Text="Gender" runat="server" ID="GenderLbl" />
                <asp:RadioButtonList ID="GenderList" runat="server">
                    <asp:ListItem Text="Male" Value="Male" Selected="True" />
                    <asp:ListItem Text="Female" Value="Female" />
                </asp:RadioButtonList>
            </div>
            <div class="errorContainer">
                <asp:Label Text=" " runat="server" ID="ErrorLbl" />
            </div>
            <asp:Button Text="Submit" runat="server" OnClick="RegisterBtn_Click" ID="RegisterBtn" />
        </form>
    </div>
</body>
</html>
<style>

    .registerContainer {
        display: flex;
        min-height: auto;
        flex-direction: column;
        width: 20rem;
        margin: auto;
    }

    .registerTitle {
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

    #UsernameInp, #PasswordInp, #EmailInp, #ConfirmInp {
        width: auto;
        height: 1.7rem;
        border-radius: 5px;
        border: 1px solid black;
        padding-left: 7px;
    }



    #RegisterBtn {
        width: 100%;
        height: 2rem;
        border-radius: 5px;
        border: none;
        background-color: orange;
        color: white;
        cursor: pointer;
    }

    .errorContainer {
        margin-bottom: 1rem;
        color: red;
        text-align: center;
    }
</style>