using netflix.wpf.Models;
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

namespace netflix.wpf.Views.Client
{
    /// <summary>
    /// Interaction logic for PaymentHistoryView.xaml
    /// </summary>
    public partial class PaymentHistoryView : UserControl
    {
        public PaymentHistoryView()
        {
            InitializeComponent();
            DataContext = new OrderHistoryViewModel(null);
        }
    }
}
