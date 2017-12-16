using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheek.Data;
using Videotheek.Entities;

namespace Videotheek.DAL
{
    public class DAL_Users
    {
        /// <summary>
        /// updates a user in the database
        /// </summary>
        /// <param name="model"></param>
        public static void Update(Users model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        /// <summary>
        /// creates a new user in the database
        /// </summary>
        /// <param name="model"></param>
        public static void Create(Users model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Users.Add(model);
            ctx.SaveChanges();
        }

        public static void SetAuthenticatedUser(Guid id)
        {
            var ctx = AppDbContext.Instance();
            ctx.CurrentUserId = id;
        }

        /// <summary>
        /// Sets the current user id null
        /// </summary>
        public static void Logout()
        {
            var ctx = AppDbContext.Instance();

            ctx.CurrentUserId = null;
        }

        public static bool Any()
        {
            var ctx = AppDbContext.Instance();
            return ctx.Users.Any();
        }

        /// <summary>
        /// gets the email from the database based on the email given (search)
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Users GetByEmailAddress(string email)
        {
            var ctx = AppDbContext.Instance();

            
            return ctx.Users.SingleOrDefault(x => x.DeletedAt == null && x.Email.ToLower() == email.ToLower());
        }

        /// <summary>
        /// gets the user from the database based on the username given (search)
        /// </summary>
        public static Users GetByUsername(string username)
        {
            var ctx = AppDbContext.Instance();

            return ctx.Users.SingleOrDefault(x => x.DeletedAt == null && x.Username.ToLower() == username.ToLower());
        }

        public static Users GetCurrentUser()
        {
            var ctx = AppDbContext.Instance();
            return ctx.Users.SingleOrDefault(x => x.DeletedAt == null && x.Id == ctx.CurrentUserId);
        }

        public static List<Users> GetAll()
        {
            var ctx = AppDbContext.Instance();

            return ctx.Users
                            .Where(x => x.DeletedAt == null)
                            .ToList();
        }
    }
}
