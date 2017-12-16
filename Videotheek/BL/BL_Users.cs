using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheek.DAL;
using Videotheek.Entities;
using Videotheek.Models;
using Videotheek.Utilities;

namespace Videotheek.BL
{
    public class BL_Users
    {
        public static bool Save(Users model)
        {
            try
            {
                if (model.IsNew())
                    Create(model);
                else
                    Update(model);

            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        public static void Update(Users user, string pwd = null)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(pwd))
                {
                    user = ChangePassword(user, pwd);
                }

                DAL_Users.Update(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Users ChangePassword(Users user, string pwd)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pwd))
                    pwd = StringExtensions.GetRandomString(8);

                var _salt = SecurityExtensions.GetSalt();

                var _encryptedPwd = SecurityExtensions.Encrypt(pwd + _salt.ToString());

                user.Salt = _salt.ToString();
                user.Password = _encryptedPwd;

                return user;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Create(Users user)
        {
            try
            {
                if (user.Id == Guid.Empty)
                    user.Id = Guid.NewGuid();

                DAL_Users.Create(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(Users model)
        {
            try
            {
                model.DeletedAt = DateTime.Now;
                Save(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Authenticate(Loginmodel loginModel)
        {
            try
            {
                // 01. Check if the user exists
                var _user = Get(loginModel.CredentialName);

                if (_user == null)
                {
                    throw new UserNotFoundException(loginModel.CredentialName);
                }

                var encrypted = SecurityExtensions.Encrypt(loginModel.Password + _user.Salt);

                if (_user.Password == encrypted)
                {
                    DAL_Users.SetAuthenticatedUser(_user.Id);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Logging the current user out
        /// </summary>
        public static void Logout()
        {
            try
            {
                DAL_Users.Logout();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Any()
        {
            try
            {
                return DAL_Users.Any();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Users Get(string login)
        {
            try
            {
                if (login.IsEmailAddress())
                {
                    return GetByEmailAddress(login);
                }
                else
                {
                    return GetByUsername(login);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// gets the user by his emailaddress
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Users GetByEmailAddress(string email)
        {
            try
            {
                return DAL_Users.GetByEmailAddress(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// gets the user by its username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static Users GetByUsername(string username)
        {
            try
            {
                return DAL_Users.GetByUsername(username);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// returns the authenticated user
        /// </summary>
        /// <returns></returns>
        public static Users GetCurrentUser()
        {
            try
            {
                return DAL_Users.GetCurrentUser();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Users> GetAll()
        {
            try
            {
                return DAL_Users.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
