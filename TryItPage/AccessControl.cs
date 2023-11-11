using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;

public class AccessControl
{
    //public string XmlFilePath = HttpContext.Current.Server.MapPath("~/App_Data/Member.xml");
    private const string XmlFileName = "Member.xml";
    private string XmlFilePath => HttpContext.Current.Server.MapPath($"~/App_Data/{XmlFileName}");


    public bool AuthenticateUser(string username, string password)
    {
        // Load the XML file
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(XmlFilePath);

        // Find the user with the provided username
        XmlNode userNode = xmlDoc.SelectSingleNode($"//User[Username='{username}']");

        if (userNode != null)
        {
            // Get the hashed password stored in the XML
            string storedPassword = userNode.SelectSingleNode("Password").InnerText;

            // Verify the entered password against the stored hashed password
            return VerifyPassword(password, storedPassword);
        }

        // User not found or password incorrect
        return false;
    }

    public void RegisterUser(string username, string password)
    {
        // Load the XML file
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(XmlFilePath);

        // Check if the username already exists
        if (UserExists(xmlDoc, username))
        {
            // Handle case where username is not unique (display an error, throw an exception, etc.)
            return;
        }

        // Create a new user element
        XmlElement userElement = xmlDoc.CreateElement("User");

        // Create username and password elements
        XmlElement usernameElement = xmlDoc.CreateElement("Username");
        usernameElement.InnerText = username;
        XmlElement passwordElement = xmlDoc.CreateElement("Password");
        passwordElement.InnerText = HashPassword(password);

        // Append username and password elements to the user element
        userElement.AppendChild(usernameElement);
        userElement.AppendChild(passwordElement);

        // Append the user element to the root element
        xmlDoc.DocumentElement.AppendChild(userElement);

        // Save the modified XML document
        xmlDoc.Save(XmlFilePath);
    }

    private bool UserExists(XmlDocument xmlDoc, string username)
    {
        // Check if a user with the provided username already exists in the XML
        return xmlDoc.SelectSingleNode($"//User[Username='{username}']") != null;
    }

    private bool VerifyPassword(string inputPassword, string hashedPassword)
    {
        // Verify the entered password against the stored hashed password
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convert the entered password string to bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(inputPassword);

            // Compute the hash value
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            // Convert the hash bytes to a hexadecimal string
            string enteredPasswordHash = BitConverter.ToString(hashBytes).Replace("-", "");

            // Compare the entered password hash with the stored hash
            return string.Equals(enteredPasswordHash, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }

    private string HashPassword(string password)
    {
        // Use a secure hashing algorithm like SHA-256
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convert the password string to bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Compute the hash value
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            // Convert the hash bytes to a hexadecimal string
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}
