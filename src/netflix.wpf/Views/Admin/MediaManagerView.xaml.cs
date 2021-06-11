using netflix.Entities;
using netflix.wpf.ViewModels.Admin;
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
    /// Interaction logic for MediaManagerView.xaml
    /// </summary>
    public partial class MediaManagerView : Page
    {
        public MediaManagerView()
        {
            InitializeComponent();
            this.DataContext = new MediaManagerViewModel();
        }

        private void AddOrEditMedia(object sender, RoutedEventArgs e)
        {
            // goto add media page
            var media = (Media)((Button)sender).Tag;
            var orderHistoryPage = new AddOrEditMediaView(media);
            NavigationService.Navigate(orderHistoryPage);
        }
    }
}
