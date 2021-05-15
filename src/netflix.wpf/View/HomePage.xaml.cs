using netflix.wpf.View.Admin;
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

namespace netflix.wpf.View
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dashboard = new Dashboard();
            this.NavigationService.Navigate(dashboard);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dashboard = new Dashboard(); // Thay bang trang Dang Nhap
            this.NavigationService.Navigate(dashboard);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var dashboard = new Dashboard(); // Thay bang trang Nguoi Dung
            this.NavigationService.Navigate(dashboard);
        }
    }
}
