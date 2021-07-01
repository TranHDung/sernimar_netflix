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
using System.Windows.Shapes;

namespace netflix.wpf.Views.Admin
{
    /// <summary>
    /// Interaction logic for VideoWatchView.xaml
    /// </summary>
    public partial class VideoWatchView : Window
    {
        private bool isFull { get; set; }
        private bool isMute { get; set; }
        private bool isPause { get; set; }
        public VideoWatchView(Media m)
        {
            InitializeComponent();
            DataContext = m;
            elmMedia.Play();
            isFull = false;
            isMute = false;
            isPause = false;
        }

        private void Full(object sender, RoutedEventArgs e)
        {
            if (!isFull)
            {
                this.WindowState = WindowState.Maximized;
                this.WindowStyle = WindowStyle.None;
                isFull = true;
            }
            else
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
                isFull = false;

            }
        }
        private void Pau(object sender, RoutedEventArgs e)
        {
            if (isPause)
            {
                elmMedia.Play();
                isPause = false;

            }
            else
            {
                elmMedia.Pause();
                isPause = true;

            }
        }
        private void Mute(object sender, RoutedEventArgs e)
        {
            if (isMute)
            {
                elmMedia.Volume = 50;
                isMute = false;

            }
            else
            {
                elmMedia.Volume = 0;
                isMute = true;

            }
        }

    }
}
