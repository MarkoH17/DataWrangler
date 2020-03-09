using System;
using System.Security.Cryptography;

namespace DataWrangler.DBOs
{
    public class UserAccount
    {
        public bool Active { get; set; }
        public int Id { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public string Password { get; set; }
        public string Username { get; set; }

        private static string _genPasswordHash(string password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            var hash = pbkdf2.GetBytes(20);

            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            var generatedHash = Convert.ToBase64String(hashBytes);

            return generatedHash;
        }

        public static string GetPasswordHash(string input, byte[] salt = null)
        {
            if (salt == null)
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            return _genPasswordHash(input, salt);
        }
    }
}