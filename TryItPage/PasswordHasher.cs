// PasswordHasher.cs
using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        // Generate a unique salt for each user
        byte[] salt = GenerateSalt();

        // Hash the password with the salt
        byte[] hashedPassword = HashWithSalt(Encoding.UTF8.GetBytes(password), salt);

        // Combine the salt and hashed password
        byte[] combinedBytes = new byte[salt.Length + hashedPassword.Length];
        Buffer.BlockCopy(salt, 0, combinedBytes, 0, salt.Length);
        Buffer.BlockCopy(hashedPassword, 0, combinedBytes, salt.Length, hashedPassword.Length);

        // Convert the combined bytes to a base64-encoded string
        string hashedPasswordString = Convert.ToBase64String(combinedBytes);

        return hashedPasswordString;
    }

    private static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16]; // You can adjust the size of the salt
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    private static byte[] HashWithSalt(byte[] passwordBytes, byte[] salt)
    {
        using (var sha256 = new SHA256Managed())
        {
            // Combine the password bytes and salt, then hash
            byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

            return sha256.ComputeHash(combinedBytes);
        }
    }
}
