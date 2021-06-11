using netflix.wpf.VỉewModel.Admin;
using netflix.wpf.Views.Admin;
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
            DataContext = sampleData();
        }
        private DashboardViewModel sampleData()
        {
            var ctx = new DashboardViewModel()
            {
                ActionLinks = new List<VỉewModel.Admin.Action>()
                {
                    new VỉewModel.Admin.Action()
                    {
                        Id = 1,
                        Uri = "/",
                        Description = "Quản lí media",
                        DisplayName =  "Quản lí media"
                    },
                    new VỉewModel.Admin.Action()
                    {
                        Id = 2,
                        Uri = "/test",
                        Description = "Quản lí tài khoản",
                        DisplayName =  "Quản lí tài khoản"
                    },
                    new VỉewModel.Admin.Action()
                    {
                        Id = 3,
                        Uri = "/test",
                        Description = "Số liệu thống kê",
                        DisplayName =  "Số liệu thống kê"
                    },
                }
            };
            return ctx;
        }

        private void goToAccountPage(object sender, RoutedEventArgs e)
        {
            var accPage = new AccountManagerView();
            NavigationService.Navigate(accPage);
        }
        private void goToMediaPage(object sender, RoutedEventArgs e)
        {
            var media = new MediaManagerView();
            NavigationService.Navigate(media);
        }
    }
}
