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
    /// Interaction logic for AddOrEditGenreView.xaml
    /// </summary>
    public partial class AddOrEditGenreView : Page
    {
        public AddOrEditGenreView(Genre gen)
        {
            InitializeComponent();
            DataContext = new AddOrEditGenreViewModel(gen);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
