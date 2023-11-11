using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItPage
{
    public partial class MemberPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Generate and set the CAPTCHA code when the page loads
                string captchaCode = GenerateCaptchaCode();
                SetCaptchaCode(captchaCode);
            }

        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string newUsername = txtNewUsername.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

                // Implement your registration logic
                if (ValidateRegistration(newUsername, newPassword, confirmPassword)) {

                    AccessControl accessControl = new AccessControl();
                    accessControl.RegisterUser(newUsername, newPassword);
                    Alert.Text = "User is registered";

                    // Optionally, you can redirect the user to the login page after registration
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    // Display an error message or handle unsuccessful registration
                }
        }

        private bool ValidateRegistration(string username, string password, string confirmPassword)
        {
            // Placeholder: Check if username is unique
            if (IsUsernameUnique(username))
            {
                // Placeholder: Check if the password meets requirements
                if (IsPasswordValid(password))
                {
                    // Placeholder: Check if password and confirmPassword match
                    if (password == confirmPassword)
                    {
                        // All validation checks passed
                        return true;
                    }
                    else
                    {
                        // Password and confirmPassword do not match
                        // Handle this case (display an error message, etc.)
                        return false;
                    }
                }
                else
                {
                    // Password does not meet requirements
                    // Handle this case (display an error message, etc.)
                    return false;
                }
            }
            else
            {
                // Username is not unique
                // Handle this case (display an error message, etc.)
                return false;
            }
        }

        // Placeholder method: Check if username is unique
        private bool IsUsernameUnique(string username)
        {
            // Placeholder: In-memory collection to store existing usernames
            List<string> existingUsernames = new List<string> { "existingUser1", "existingUser2" };

            // Check if the provided username already exists in the collection
            bool isUnique = !existingUsernames.Contains(username);

            // Return true if the username is unique, false otherwise
            return isUnique;
        }


        // Placeholder method: Check if the password meets requirements
        private bool IsPasswordValid(string password)
        {
            // Minimum length requirement
            int minLength = 8;

            // Minimum complexity requirements (e.g., at least one uppercase letter, one lowercase letter, and one digit)
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                else if (char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }

            // Check if the password meets all requirements
            bool isPasswordValid = password.Length >= minLength && hasUpperCase && hasLowerCase && hasDigit;

            // Return true if the password is valid, false otherwise
            return isPasswordValid;
        }



        private List<Member> members = new List<Member>(); // Placeholder in-memory collection

        private void StoreNewMember(string username, string password)
        {
            // Hash or encrypt the password before storing
            string hashedPassword = HashPassword(password);

            // Placeholder: Storing new member credentials in an in-memory collection
            members.Add(new Member { Username = username, HashedPassword = hashedPassword });
        }

        // Placeholder class for Member information
        public class Member
        {
            public string Username { get; set; }
            public string HashedPassword { get; set; }
        }

        // Placeholder method for password hashing
        private string HashPassword(string password)
        {
            // Implement your password hashing logic here
            // This could be calling a method from the PasswordHasher class or using another hashing library
            // For simplicity, we assume the password is already hashed in this example
            return password;
        }

        private string GenerateCaptchaCode()
        {
            // Generate a random string for the CAPTCHA code
            Random random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(characters, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void SetCaptchaCode(string captchaCode)
        {
            // Store the CAPTCHA code in Session for verification
            TextBox1.Text = captchaCode;
            Session["CaptchaCode"] = captchaCode;
        }


        private bool VerifyCaptcha()
        {
            // Retrieve the stored CAPTCHA code from Session
            string storedCaptchaCode = Session["CaptchaCode"] as string;

            // Get the entered CAPTCHA code from the TextBox
            string enteredCaptchaCode = txtCaptcha.Text.Trim();

            // Clear the CAPTCHA code from Session to ensure one-time use
            Session["CaptchaCode"] = null;

            // Verify if the entered CAPTCHA code matches the stored code
            return string.Equals(storedCaptchaCode, enteredCaptchaCode, StringComparison.OrdinalIgnoreCase);
        }




    }
}