﻿using netflix.Entities;
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
    /// Interaction logic for AddOrEditMediaView.xaml
    /// </summary>
    public partial class AddOrEditMediaView : Page
    {
        public AddOrEditMediaView(Media media)
        {
            InitializeComponent();
            this.DataContext = new AddOrEditMediaViewModel(media);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
