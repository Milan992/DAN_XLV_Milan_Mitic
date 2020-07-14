using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WpfStorage.Model;
using WpfStorage.Views;

namespace WpfStorage.ViewModels
{
    class ManagerViewModel : ViewModelBase
    {
        Manager manager;
        Service service = new Service();
        FileLogger fileLogger = new FileLogger();
        Notification notification = new Notification();

        #region Constructors

        public ManagerViewModel(Manager managerOpen)
        {
            manager = managerOpen;

            ProductList = service.GetAllProducts();
        }

        #endregion

        #region Properties 

        private tblProduct product;

        public tblProduct Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }


        private List<tblProduct> productList;

        public List<tblProduct> ProductList
        {
            get
            {
                return productList;
            }
            set
            {
                productList = value;
                OnPropertyChanged("ProductList");

            }
        }

        #endregion

        #region Commands

        private ICommand addProduct;

        public ICommand AddProduct
        {
            get
            {
                if (addProduct == null)
                {
                    addProduct = new RelayCommand(param => AddProductExecute(), param => CanAddProductExecute());
                }

                return addProduct;
            }
        }

        private void AddProductExecute()
        {
            try
            {
                AddProduct addProduct = new AddProduct();
                addProduct.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddProductExecute()
        {
            return true;
        }

        private ICommand editProduct;

        public ICommand EditProduct
        {
            get
            {
                if (editProduct == null)
                {
                    editProduct = new RelayCommand(param => EditProductExecute(), param => CanEditProductExecute());
                }

                return editProduct;
            }
        }

        private void EditProductExecute()
        {
            try
            {
                AddProduct addProduct = new AddProduct();
                addProduct.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditProductExecute()
        {
            return true;
        }

        private ICommand deleteProduct;

        public ICommand DeleteProduct
        {
            get
            {
                if (deleteProduct == null)
                {
                    deleteProduct = new RelayCommand(param => DeleteProductExecute(), param => CanDeleteProductExecute());
                }

                return deleteProduct;
            }
        }

        private void DeleteProductExecute()
        {
            try
            {
                service.ProductDeleted += fileLogger.LogDeletedProduct;
                service.ProductDeleted += notification.ProductDeleted;
                service.DeleteProduct(Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanDeleteProductExecute()
        {
            return true;
        }

        #endregion
    }
}
