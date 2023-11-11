using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TryItPage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            //AccessControl accessControl = new AccessControl();

            if (AuthenticateUser(username, password))
            {
                // Authentication successful, redirect to the Member Page
                Response.Redirect("TryThePage.aspx");
            }
            else
            {
                // Authentication failed, display an error message
                lblLoginFeedback.Text = "Invalid username or password. Please try again.";
            }
        }

        private List<Member> members = new List<Member>();
        private const string XmlFileName = "Member.xml";
        private string XmlFilePath => HttpContext.Current.Server.MapPath($"~/App_Data/{XmlFileName}");

        private void LoadMembersFromXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlFilePath);

            XmlNodeList userNodes = xmlDoc.SelectNodes("//User");

            foreach (XmlNode userNode in userNodes)
            {
                string username = userNode.SelectSingleNode("Username").InnerText;
                string hashedPassword = userNode.SelectSingleNode("Password").InnerText;

                members.Add(new Member { Username = username, HashedPassword = hashedPassword });
            }
        }


        private bool AuthenticateUser(string username, string password)
        {
            // Retrieve the member from the collection based on the provided username
            Member user = members.FirstOrDefault(m => m.Username == username);

            // Check if the user exists and the provided password matches the stored hashed password
            if (user != null && VerifyPassword(password, user.HashedPassword))
            {
                // Authentication successful
                return true;
            }

            // Authentication failed
            return false;
        }

        // Placeholder method for password verification
        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            // Implement your password verification logic here
            // This could be calling a method from the PasswordHasher class or using another hashing library
            // For simplicity, we assume the password is already hashed in this example
            return inputPassword == hashedPassword;
        }

        // Placeholder class for Member information
        public class Member
        {
            public string Username { get; set; }
            public string HashedPassword { get; set; }
        }


    }
}