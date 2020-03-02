
namespace RepositorywithDI.Extension
{
    #region Using
    using RepositorywithDI.Models;
    using System.Collections.Generic;
    using System.Linq;
    #endregion


    /// <summary>
    /// ExtensionMethods
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Withouts the passwords.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        public static IEnumerable<Employee> WithoutPasswords(this IEnumerable<Employee> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        /// <summary>
        /// Withouts the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static Employee WithoutPassword(this Employee user)
        {
            user.Password = null;
            return user;
        }
        /// <summary>
        /// Encrypts the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string Encrypt(string key)
        {
            var aes = new SimpleAES();
            var encryptStr = aes.EncryptToString(key);
            return encryptStr;
        }

        /// <summary>
        /// Decrypts the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string Decrypt(string key)
        {
            var aes = new SimpleAES();
           return aes.DecryptString(key);
        }
    }

}
