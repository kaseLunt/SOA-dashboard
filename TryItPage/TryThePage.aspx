<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryThePage.aspx.cs" Inherits="TryItPage.TryThePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
        <form id="form" runat="server">
        
            <!-- Input textbox for user's name -->
            <h1>All In One Place News Dashboard</h1>
            <h2>Weather and News Dashboard</h2>
            <h1>Weather Serive</h1>
            <label for="txtName">Enter the Zipcode:</label>
            <asp:TextBox ID="txtName" runat="server" type="number" maxlength="5" pattern="\d{5}" placeholder="Enter 5-Digit Zipcode" ></asp:TextBox>
        
            <!-- Button to trigger the action -->
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

            <br />
        
            <!-- Textbox to display the result -->
            <asp:TextBox ID="txtResult" runat="server" TextMode="MultiLine" Rows="4" Columns="50" ReadOnly="true"></asp:TextBox>
            <div>
                <br />

            </div>

            <!-- Input textbox for user's name -->
            <h1> News Serach Service</h1>
            <label for="txtName">Enter keyword that you would like to search:</label>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Keyword"></asp:TextBox>
        
            <!-- Button to trigger the action -->
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnSubmit_Click1" />

            <br />
        
            <!-- Textbox for displaying the result -->
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Rows="4" Columns="50" ReadOnly="true"></asp:TextBox>
        </form>
       </div>
</body>
</html>
