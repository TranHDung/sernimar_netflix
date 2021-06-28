using netflix.wpf.View.Admin;
using netflix.wpf.ViewModels.Auth;
using netflix.wpf.Views.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace netflix.wpf.Views.Auth
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void GoToHomePage(object sender, RoutedEventArgs e)
        {
            var db = new ClientIndexView();
            NavigationService.Navigate(db);
        }
        private void GoToAdminPage(object sender, RoutedEventArgs e)
        {
            var db = new Dashboard();
            NavigationService.Navigate(db);
        }

        private void OpenForgetPassTab(object sender, RoutedEventArgs e)
        {
            //mainTab.SelectedIndex = 2;
            forgetTabItem.IsSelected = true;
        }
    }
}
