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
    class DAL_Products
    {
        /// <summary>
        /// Creates a new product in the database
        /// </summary>
        /// <param name="model">The new product</param>
        public static void Create(Product model)
        {
             var ctx = AppDbContext.Instance();

             ctx.Products.Add(model);
             ctx.SaveChanges();
        }

        public static void Update(Product model)
        {
            var ctx = AppDbContext.Instance();

            ctx.Entry(model).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static List<Product> GetAll()
        {
            var ctx = AppDbContext.Instance();

            return ctx.Products.Where(p => p.DeletedAt == null).ToList();
                        
        }
    }
}
