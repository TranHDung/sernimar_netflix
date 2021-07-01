using netflix.Entities;
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
using System.Windows.Shapes;

namespace netflix.wpf.Views.Client
{
    /// <summary>
    /// Interaction logic for MediaDetailView.xaml
    /// </summary>
    public partial class MediaDetailView : Window
    {
        public MediaDetailView(Media m)
        {
            InitializeComponent();
            this.DataContext = m;
            FeatVideo.Volume = 0;
            FeatVideo.Position = TimeSpan.FromSeconds(1);
            FeatVideo.Play();
            FeatVideo.SpeedRatio = 0.3;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            var m = (Media)b.Tag;
            var detail = new VideoWatchView(m);
            this.Hide();
            detail.ShowDialog();
            this.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
