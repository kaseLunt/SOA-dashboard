<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberPage.aspx.cs" Inherits="TryItPage.MemberPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h1>Register Here!!!!</h1>
        <asp:TextBox ID="txtNewUsername" runat="server" placeholder="New Username" /><br />
<asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder="New Password" /><br />
<asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Confirm Password" /><br />
        <asp:Label ID="lblCaptchaFeedback" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="inputField" placeholder="Enter CAPTCHA" />
<asp:TextBox ID="txtCaptcha" runat="server" placeholder="Enter Captcha" /><br />
<!-- Add your captcha control or implement your own captcha logic here -->
<asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        <asp:Label ID="Alert" runat="server" CssClass="feedback-label" Text=""></asp:Label>

    </main>
</asp:Content>
