using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Videotheek.Utilities
{
    /// <summary>
    /// Hashing and generated salts
    /// </summary>
    public static class SecurityExtensions
    {
        private static int saltLengthLimit = 32;

        /// <summary>
        /// Generates salt with default limit of 32 characters
        /// </summary>
        /// <returns>the salt</returns>
        public static string GetSalt()
        {
            return GetSalt(saltLengthLimit);
        }

        /// <summary>
        /// Generates salt with a specific maximum length
        /// </summary>
        /// <param name="maximumLength">Max nr of characters</param>
        /// <returns>the salt</returns>
        public static string GetSalt(int maximumLength)
        {
            var salt = new byte[maximumLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return Encoding.ASCII.GetString(salt);
        }

        /// <summary>
        /// encrypts the value with SHA 25
        /// </summary>
        public static string Encrypt(string v)
        {
            var sha = new SHA256CryptoServiceProvider();
            return Encoding.ASCII.GetString(sha.ComputeHash(Encoding.ASCII.GetBytes(v)));
        }
    }
}
