using System.Windows.Controls;

namespace netflix.wpf.View.Admin
{
    /// <summary>
    /// Interaction logic for AccountManagerView.xaml
    /// </summary>
    public partial class AccountManagerView : UserControl
    {
        public AccountManagerView()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Admin.AccountManagerViewModel();
        }
    }
}
