using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheek.Entities;

namespace Videotheek.Data
{
    public class AppDbContext : DbContext
    {
        private static AppDbContext _instance;

        public AppDbContext() : this(@"Data Source=laptop-fac37men\sqlexpress;Initial Catalog=Videotheek;User ID=sa;Password=syntra")
        {

        }

        private AppDbContext(string conn): base(conn) { }

        #region Database sets

        /// <summary>
        /// Gets/sets the DB Set for the products
        /// </summary>
        public DbSet<Product> Products { get; set; }

        #endregion

        /// <summary>
        /// Implementation of the singleton pattern
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static AppDbContext Instance(string connectionString = null)
        {
            if (_instance == null)
            {
                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    _instance = new AppDbContext(connectionString);
                }
            }

            return _instance;
        }
    }
}
