using netflix.Entities;
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

namespace netflix.wpf.Views.Client
{
    /// <summary>
    /// Interaction logic for HomePageTabView.xaml
    /// </summary>
    public partial class HomePageTabView : UserControl
    {
        public HomePageTabView()
        {
            InitializeComponent();
            DataContext = new HomePageTabViewModel();
            FeatVideo.Volume = 0;
            FeatVideo.Position = TimeSpan.FromSeconds(1);
            FeatVideo.Play();
            FeatVideo.SpeedRatio = 0.3;
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            var g = sender as Grid;
            var m = g.FindName("EmlMedia") as MediaElement;
            m?.Play();
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            var g = sender as Grid;
            var m = g.FindName("EmlMedia") as MediaElement;
            m?.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            var m = (Media)b.Tag;
            var detail = new MediaDetailView(m);
            detail.ShowDialog();
        }
    }
}
