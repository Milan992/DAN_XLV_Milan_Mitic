using System;
using System.Collections.Generic;
using System.Linq;
using WpfStorage.Model;

namespace WpfStorage
{
    class Service
    {
        #region Delegates and events

        public delegate void ProductStoredEventHandler(object source, EventArgs args);

        public event ProductStoredEventHandler ProductStored;

        public delegate void ProductNotStoredEventHandler(object source, EventArgs args);

        public event ProductNotStoredEventHandler ProductNotStored;

        public delegate void ProductDeletedEventHandler(object source, EventArgs args);

        public event ProductDeletedEventHandler ProductDeleted;

        public delegate void ProductAddedEventHandler(object source, EventArgs args);

        public event ProductAddedEventHandler ProductAdded;

        public delegate void ProductEditedEventHandler(object source, EventArgs args);

        public event ProductEditedEventHandler ProductEdited;

        protected virtual void OnProductStored()
        {
            if (ProductStored != null)
                ProductStored(this, EventArgs.Empty);
        }

        protected virtual void OnProductNotStored()
        {
            if (ProductNotStored != null)
                ProductNotStored(this, EventArgs.Empty);
        }
        protected virtual void OnProductAdded()
        {
            if (ProductAdded != null)
                ProductAdded(this, EventArgs.Empty);
        }

        protected virtual void OnProductEdited()
        {
            if (ProductEdited != null)
                ProductEdited(this, EventArgs.Empty);
        }

        protected virtual void OnProductDeleted()
        {
            if (ProductDeleted != null)
                ProductDeleted(this, EventArgs.Empty);
        }

        #endregion

        #region Methods

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
            OnProductStored();

            OnProductNotStored();
        }

        /// <summary>
        /// Deletes product from database if Stored value is set do false, else writes out a message that the product can't be deleted.
        /// </summary>
        /// <param name="product"></param>
        public void DeleteProduct(tblProduct product)
        {
            using (StorageEntities context = new StorageEntities())
            {
                tblProduct productToDelete = (from p in context.tblProducts where p.ID == product.ID select p).First();
                context.tblProducts.Remove(productToDelete);
                context.SaveChanges();
                OnProductDeleted();
            }
        }

        /// <summary>
        /// Adds new product to the table or updates one if product with same ID already exists.
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(tblProduct product)
        {
            OnProductAdded();

            OnProductEdited();
        }

        /// <summary>
        /// Sums all products amount.
        /// </summary>
        /// <returns></returns>
        public int SumAllStoredProducts()
        {
            List<tblProduct> list = GetAllProducts();
            int amount = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Stored)
                {
                    amount = amount = list[i].Amount;
                }
            }

            return amount;
        }

        #endregion
    }
}
