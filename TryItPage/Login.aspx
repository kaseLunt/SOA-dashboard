<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TryItPage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        #formContainer {
            text-align: center;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 8px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .inputField {
            width: 250px;
            padding: 10px;
            margin: 5px;
            font-size: 16px;
        }

        .buttonStyle {
            width: 250px;
            padding: 10px;
            margin: 10px 0;
            font-size: 18px;
        }

        .linkStyle {
            font-size: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="formContainer">
            <asp:TextBox ID="txtUsername" runat="server" CssClass="inputField" placeholder="Username" /><br />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="inputField" TextMode="Password" placeholder="Password" /><br />
            <asp:Button ID="btnLogin" runat="server" CssClass="buttonStyle" Text="Login" OnClick="btnLogin_Click" /><br />
            <asp:Label ID="lblLoginFeedback" runat="server" CssClass="feedback-label" Text=""></asp:Label>
            <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="MemberPage.aspx" CssClass="linkStyle" Text="Register" />
        </div>
    </form>

</body>
</html>
