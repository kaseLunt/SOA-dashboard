<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryItPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div>
            <h1>Welcome to All In One Application</h1>
            <p>
                This application provides the following functionality:
                <!-- Describe the functionality here -->
                    <h3>Weather Service</h3>
                    <h3>Treding News</h3>
                    <h3>News Search</h3>
                    <h3>Word Count Service</h3>


                <!-- Sign-up instructions go here -->


                <!-- Test instructions for TA/grader go here -->
            </p>

            <table>
    <tr>
        <th colspan="7">Service Directory: The team has completed the following services.</th>
    </tr>
    <tr>
        <th colspan="7">This project is developed by: Joshua Mang</th>
    </tr>

    <tr>
    <th>Provider Name</th>
    <th>Service name, with input and output types</th>
    <th>Required service?</th>
    <th>Difficult level - self estimate</th>
    <th>TryIt Link</th>
    <th>Service description</th>
    <th>Actual resources used to implement the service</th>
    </tr>
  
    <tr>
        <td>Joshua Mang</td>
        <td>Weather Service : 5 Days Weather Forecast<br>Input: string<br>Output: <string></string> </td>
        <td>Yes</td>
        <td>Medium</td>
        <td><a href="http://webstrar110.fulton.asu.edu/page10/TryThePage">TryIt Link</a></td>
        <td>This operation retrieves upcoming 5 days weather forecast</td>
        <td>Weather API is utilized</td>
    </tr>
    <tr>
        <td>Joshua Mangt</td>
        <td>News Search : Search for News Link<br>Input: string<br>Output: <string></string> </td>
        <td>Yes</td>
        <td>Hard</td>
        <td><a href="http://webstrar110.fulton.asu.edu/page10/TryThePage">TryIt Link</a></td>
        <td>This operation retrieves News related to the input topic</td>
        <td>News API is utilized</td></td>
    </tr>
    <tr>
        <td>Joshua Mang</td>
        <td>TrendingNews : Search for Trending News<br>Input: no input<br>Output: gridview </td>
        <td>No</td>
        <td>Challenging</td>
        <td><a href="http://webstrar110.fulton.asu.edu/page10/TryThePage">TryIt Link</a></td>
        <td>This operation retrieves all the trending news</td>
        <td>News API is utilized</td>
    </tr>
    <tr>
        <td>Joshua Mang</td>
        <td>WordCount : Count the word from the file<br>Input: file<br>Output: json </td>
        <td>No</td>
        <td>Hard</td>
        <td><a href="http://webstrar110.fulton.asu.edu/page10/TryThePage">TryIt Link</a></td>
        <td>This operation search for the word count from the given file</td>
        <td></td>
    </tr>
    <tr>
        <td>Joshua Mang</td>
        <td>TryIt page<br>Inputs: string<br>Outputs: listed above</td>
        <td>-</td>
        <td>Challenging</td>
        <td><a href="http://webstrar110.fulton.asu.edu/page10/TryThePage">TryIt Link</a></td>
        <td>TryIt page combining all the services.</td>
        <td>APIs from the all the services.</td>
    </tr>
</table>

            <style>
    table {
        border-collapse: collapse;
        width: 100%;
    }

    th, td {
        border: 1px solid #ddd;
        padding: 8px;
        text-align: center; /* Center the text in all cells */
    }

    th {
        background-color: #f2f2f2;
    }
</style>

            <!-- Service Directory -->
            <h2>Service Directory</h2>
            <ul>
                <!-- List of components and services with details -->
                <li>Provider: Service Provider</li>
                <li>Type: WSDL Service</li>
                <li>Operation: OperationName</li>
                <!-- Add more details as required -->

                <!-- Link to TryIt page or web presentation layer GUI -->
                <li><a href="TryThePage.aspx">TryIt Page</a></li>
            </ul>

        </div>
    </main>

</asp:Content>