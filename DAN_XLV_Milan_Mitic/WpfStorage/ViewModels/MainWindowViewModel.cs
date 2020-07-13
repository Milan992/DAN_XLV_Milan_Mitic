using System;
using System.Windows;
using System.Windows.Input;
using WpfStorage.Views;

namespace WpfStorage.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        Service service = new Service();
        MainWindow main;

        #region Constructors

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
        }

        #endregion

        #region Properties

        private string userName;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        #endregion

        #region Commands

        private ICommand logIn;

        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(param => LogInExecute(), param => CanLogInExecute());
                }

                return logIn;
            }
        }

        private void LogInExecute()
        {
            try
            {
                if (UserName == "Man2019" && Password == "Man2019")
                {
                    Manager manager = new Manager();
                    manager.ShowDialog();
                }
                else if (UserName == "Mag2019" && Password == "Mag2019")
                {
                    Employee employee = new Employee();
                    employee.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogInExecute()
        {
            return true;
        }

        #endregion
    }
}
