using System.Collections.Generic;
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
    }
}
