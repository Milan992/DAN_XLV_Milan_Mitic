﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WpfStorage.Model;
using WpfStorage.Views;

namespace WpfStorage.ViewModels
{
    class EmployeeViewModel : ViewModelBase
    {
        Employee employee;
        Service service = new Service();

        #region Constructors

        public EmployeeViewModel(Employee employeeOpen)
        {
            employee = employeeOpen;

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

        private ICommand storeProduct;

        public ICommand StoreProduct
        {
            get
            {
                if (storeProduct == null)
                {
                    storeProduct = new RelayCommand(param => StoreProductExecute(), param => CanStoreProductExecute());
                }

                return storeProduct;
            }
        }

        private void StoreProductExecute()
        {
            try
            {
                service.StoreProduct(Product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanStoreProductExecute()
        {
            return true;
        }

        #endregion
    }
}