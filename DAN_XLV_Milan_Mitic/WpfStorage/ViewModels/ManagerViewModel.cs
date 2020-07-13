using System.Collections.Generic;
using WpfStorage.Model;
using WpfStorage.Views;

namespace WpfStorage.ViewModels
{
    class ManagerViewModel : ViewModelBase
    {
        Manager manager;
        Service service = new Service();

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
    }
}
