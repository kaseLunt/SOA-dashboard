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
            <h2>Weather Serive</h2>
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

                    <div>
            <h2>Trending News</h2>
                        <asp:Button ID="Button3" runat="server" Text="Read Trending News" OnClick="btnSubmit_Click3" />

                        <div>
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


        </div>

            <!-- Input textbox for user's name -->
            <h2> News Serach Service</h2>
            <label for="txtName">Enter keyword that you would like to search:</label>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Keyword"></asp:TextBox>
        
            <!-- Button to trigger the action -->
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnSubmit_Click1" />

            <br />
        
            <!-- Textbox for displaying the result -->
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Rows="4" Columns="50" ReadOnly="true"></asp:TextBox>

            <div>
                <br />
            </div>

            <div>
    <h1>Word Count Service</h1>
    <h2>This Word Count Service return the word count from the txt file.</h2>
    <h3>Plese upload the txt file without .txt externsion</h3>
    <h4>The text file should have words seperated by a space.</h4>

    <asp:FileUpload ID="fileUpload" runat="server" />
    <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="btnSubmit_Click2" />

    <div>
    <!-- Add a new text box for displaying text -->
<asp:TextBox ID="txtDisplay" runat="server" TextMode="MultiLine" Rows="100" Columns="100"></asp:TextBox>
        </div>
</div>



        </form>
       </div>
</body>
</html>
