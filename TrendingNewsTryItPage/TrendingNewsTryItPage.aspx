<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="NewsApp.News" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>News App</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>News App</h1>
            <h2>Trending News</h2>
            <asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="Description" HeaderText="Description" />
        <asp:BoundField DataField="PublishedAt" HeaderText="Published At" />
        <asp:BoundField DataField="Source" HeaderText="Source" />
        <asp:HyperLinkField DataTextField="Url" DataTextFormatString="<a href='{0}'>Read More</a>" HeaderText="Link" />
        <asp:ImageField DataImageUrlField="UrlToImage" HeaderText="Image" />
    </Columns>
</asp:GridView>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>


        </div>
    </form>
</body>
</html>
