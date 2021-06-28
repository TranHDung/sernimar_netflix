using netflix.wpf.VỉewModel.Admin;
using netflix.wpf.Views.Admin;
using netflix.wpf.Views.Auth;
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

namespace netflix.wpf.View.Admin
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            //NavigationService.bac();
        }
        
        private void goToAccountPage(object sender, RoutedEventArgs e)
        {
            var accPage = new AccountManagerView();
            NavigationService.Navigate(accPage);
        }
        private void goToMediaPage(object sender, RoutedEventArgs e)
        {
            var media = new MediaManagerView(null);
            NavigationService.Navigate(media);
        }
        private void goToGenrePage(object sender, RoutedEventArgs e)
        {
            var gen = new GenreManager();
            NavigationService.Navigate(gen);
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            var page = new LoginView();
            NavigationService.Navigate(page);
            NavigationService.RemoveBackEntry();

        }
    }
}
