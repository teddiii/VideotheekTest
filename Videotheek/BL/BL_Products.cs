using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheek.DAL;
using Videotheek.Entities;

namespace Videotheek.BL
{
    /// <summary>
    /// The bussiness logic of our Products
    /// </summary>
    public class BL_Products
    {
        /// <summary>
        /// Saves the model
        /// </summary>
        public static bool Save(Product model)
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

        private static void Update(Product model)
        {
            try
            {
                DAL_Products.Update(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void Create(Product model)
        {
            try
            {
                DAL_Products.Create(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Product> GetAll()
        {
            try
            {
                return DAL_Products.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Deletes the model in the database
        /// </summary>
        /// <param name="model">The given product</param>
        public static void Delete(Product model)
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
    }
}
