using MahApps.Metro.Controls;
using netflix.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace netflix.wpf.Views.Client
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : MetroWindow
    {
        public Index(Profile profile)
        {
            InitializeComponent();
            this.DataContext = new IndexViewModel(profile);
            HamburgerMenuControl.SelectedIndex = 0;
        }
        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            this.HamburgerMenuControl.Content = e.InvokedItem;

            if (!e.IsItemOptions && this.HamburgerMenuControl.IsPaneOpen)
            {
                // You can close the menu if an item was selected
                this.HamburgerMenuControl.IsPaneOpen = false;
            }
        }


        private void HamburgerMenuControl_OptionsItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (HamburgerMenuControl.IsPaneOpen)
            {
                // You can close the menu if an item was selected
                this.HamburgerMenuControl.IsPaneOpen = false;
            }
        }
    }
}
