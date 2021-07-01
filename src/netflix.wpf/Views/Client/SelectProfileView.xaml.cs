using MahApps.Metro.Controls;
using netflix.Entities;
using netflix.wpf.Models;
using netflix.wpf.ViewModels.Client;
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
    /// Interaction logic for SelectProfileView.xaml
    /// </summary>
    public partial class SelectProfileView : MetroWindow
    {
        public SelectProfileView()
        {
            InitializeComponent();
            DataContext = new SelectProfileViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var profile = (Profile)((Button)sender).Tag;
            AuthToken.setProfileId(profile.Id.ToString());
            var index = new Index(profile);
            index.ShowDialog();
            this.Show();

        }
    }
}
