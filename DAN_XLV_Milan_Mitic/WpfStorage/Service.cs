using System;
using System.Collections.Generic;
using System.Linq;
using WpfStorage.Model;

namespace WpfStorage
{
    class Service
    {
        /// <summary>
        /// Gets all products from a DataBase and adds the to the list.
        /// </summary>
        /// <returns></returns>
        public List<tblProduct> GetAllProducts()
        {
            try
            {
                using (StorageEntities context = new StorageEntities())
                {
                    List<tblProduct> list = new List<tblProduct>();
                    list = (from x in context.tblProducts select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Sets product's boolean value Stored to true.
        /// </summary>
        /// <param name="product"></param>
        public void StoreProduct(tblProduct product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes product from database if Stored value is set do false, else writes out a message that the product can't be deleted.
        /// </summary>
        /// <param name="product"></param>
        internal void DeleteProduct(tblProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
