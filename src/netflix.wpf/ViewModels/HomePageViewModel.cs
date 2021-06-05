using netflix.wpf.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using netflix.wpf;
using netflix.wpf.View.Admin;

namespace netflix.wpf.VỉewModel
{
    public class HomePageViewModel: BaseViewModel
    {
        private NavigationService _nav;

        private ICommand _goToAdminPage;

        public ICommand GoToAdminPage {

            get
            {
                if(_goToAdminPage == null)
                {
                    _goToAdminPage = new RelayCommand(
                        p => canGotoAdminPage(), p => _navigateToAdminPage());
                }
                return _goToAdminPage;
            }
        }

        private void _navigateToAdminPage()
        {
            var db = new Dashboard();
            _nav.Navigate(db);
        }

        private bool canGotoAdminPage()// check that action can invoke, like: validate ...
        {
            return true;
        }
    }
}
