using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfStorage.Model;
using WpfStorage.Views;

namespace WpfStorage.ViewModels
{
    class AddProductViewModel : ViewModelBase
    {
        AddProduct addProduct;
        Service service = new Service();
        FileLogger fileLogger = new FileLogger();
        Notification notification = new Notification();

        #region Constructors

        public AddProductViewModel(AddProduct addProductOpen)
        {
            product = new tblProduct();
            addProduct = addProductOpen;
        }

        public AddProductViewModel(AddProduct addProductOpen, tblProduct productedit)
        {
            product = productedit;
            addProduct = addProductOpen;
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

        #endregion

        #region Commands

        private ICommand addNewProduct;

        public ICommand AddNewProduct
        {
            get
            {
                if (addNewProduct == null)
                {
                    addNewProduct = new RelayCommand(param => AddNewProductExecute(), param => CanAddNewProductExecute());
                }

                return addNewProduct;
            }
        }

        private void AddNewProductExecute()
        {
            try
            {
                service.ProductAdded += fileLogger.LogAddedProduct;
                service.ProductAdded += notification.ProductAdded;
                service.ProductEdited += fileLogger.LogEditedProduct;
                service.ProductEdited += notification.ProductEdited;
                service.AddProduct(Product);
                addProduct.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddNewProductExecute()
        {
            return true;
        }

        #endregion
    }
}
