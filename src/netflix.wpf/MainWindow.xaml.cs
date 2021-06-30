using netflix.wpf.View;
using netflix.wpf.View.Admin;
using netflix.wpf.ViewModels.Auth;
using netflix.wpf.Views.Auth;
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

namespace netflix.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
            //_mainFrame.Navigate(new LoginView());
        }
        private void GoToHomePage(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var win2 = new Views.Client.Index();
            win2.ShowDialog();
            this.Show();
        }
        private void GoToAdminPage(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var dashboard = new Views.Admin.DashBoardWindow();
            dashboard.ShowDialog();
            this.Show();
        }

        private void OpenForgetPassTab(object sender, RoutedEventArgs e)
        {
            //mainTab.SelectedIndex = 2;
            forgetTabItem.IsSelected = true;
        }

        private void AdminChecked(object sender, RoutedEventArgs e)
        {
            
        }
        private void IsLoggedInChecked(object sender, RoutedEventArgs e)
        {
            if ((bool)cbAdmin.IsChecked && (bool)cbLogin.IsChecked) // admin, goto admin page
            {
                this.Hide();
                var dashboard = new Views.Admin.DashBoardWindow();
                dashboard.ShowDialog();
                this.Show();
            }
            else if((bool)cbLogin.IsChecked) // goto inedx page
            {
                this.Hide();
                var dashboard = new Views.Client.Index();
                dashboard.ShowDialog();
                this.Show();
            }
            cbAdmin.IsChecked = false;
            cbLogin.IsChecked = false;
        }
    }
}
