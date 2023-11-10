<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WordCountTryIt.aspx.cs" Inherits="WordCountTryItPage.WordCountTryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Word Count Service</h1>
            <h2>This Word Count Service return the word count from the txt file.</h2>
            <h3>Plese upload the txt file without .txt externsion</h3>
            <h4>The text file should have words seperated by a space.</h4>

            <asp:FileUpload ID="fileUpload" runat="server" />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

            <div>
            <!-- Add a new text box for displaying text -->
        <asp:TextBox ID="txtDisplay" runat="server" TextMode="MultiLine" Rows="1000" Columns="100"></asp:TextBox>
                </div>
        </div>
    </form>
</body>
</html>
