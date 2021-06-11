using netflix.Authorization.Users;
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

namespace netflix.wpf.Views.Admin
{
    /// <summary>
    /// Interaction logic for AccountManagerView.xaml
    /// </summary>
    public partial class AccountManagerView : Page
    {
        public AccountManagerView()
        {
            InitializeComponent();
            DataContext = new ViewModel.Admin.AccountManagerViewModel();
        }
        private void OrderHistory(object sender, RoutedEventArgs e)
        {
            var user =(User)((Button)sender).Tag;
            var orderHistoryPage = new OrderHistoryView(user);
            NavigationService.Navigate(orderHistoryPage);
        }
        private void EditUser(object sender, RoutedEventArgs e)
        {
            var user =(User)((Button)sender).Tag;
            var editAccountView = new AddOrEditAccountView(user);
            NavigationService.Navigate(editAccountView);
        }
    }
}
