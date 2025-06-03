<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="LOrd_Card_Shop.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="loginContainer">
        <div class="loginTitle">
            <h1>Welcome</h1>
        </div>
        <form id="LoginForm" runat="server">
            <div class="inputContainer">
                <asp:Label Text="Username" runat="server" ID="UsernameLbl" />
                <input id="UsernameInp" type="text" runat="server" placeholder="Username" />
            </div>
            <div class="inputContainer">
                <asp:Label Text="Password" runat="server" ID="PasswordLbl" />
                <input id="PasswordInp" type="password" runat="server" placeholder="Password" />
            </div>
            <div class="checkboxContainer">
                <input type="checkbox" id="RememberMeCheck" runat="server" />
                <asp:Label Text="Remember Me" runat="server" />
            </div>
            <div class="errorContainer">
                <asp:Label Text=" " runat="server" ID="ErrorLbl" />
            </div>
            <asp:Button Text="Submit" runat="server" OnClick="LoginBtn_Click" ID="LoginBtn" />
            <p>Don't have an account? <a href="/Views/RegisterPage.aspx">Register Here</a></p>
        </form>
     </div>
</body>
</html>
<style>

    .loginContainer {
        display: flex;
        flex-direction: column;
        width: 20rem;
        margin: auto;
    }

    .loginTitle {
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

    #UsernameInp, #PasswordInp {
        width: auto;
        height: 1.7rem;
        border-radius: 5px;
        border: 1px solid black;
        padding-left: 7px;
    }

    .checkboxContainer {
        display: flex;
        flex-direction: row;
        align-items: center;
        margin-bottom: 1rem;
        gap: 5px;
    }

    #RememberMeCheck {
        width: 1rem;
        height: 1rem;
    }


    #LoginBtn {
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