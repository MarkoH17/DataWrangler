using System;
using System.Security.Cryptography;

namespace DataWrangler.DBOs
{
    internal class UserAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public static string GetPasswordHash(string input)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            return _genPasswordHash(input, salt);
        }

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

        public static bool VerifyPassword(string storedHash, string password)
        {
            var hashBytes = Convert.FromBase64String(storedHash);

            var salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var calculatedHash = _genPasswordHash(password, salt);

            return calculatedHash.Equals(storedHash);
        }
    }
}