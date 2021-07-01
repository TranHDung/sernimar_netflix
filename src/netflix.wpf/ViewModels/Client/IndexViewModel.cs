using netflix.Entities;
using netflix.wpf.VỉewModel;
using netflix.wpf.Views.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace netflix.wpf.ViewModels.Client
{
    public class IndexViewModel : BaseViewModel
    {
        private Profile profile;
        private ObservableCollection<NavItem> navigationItems;
        public ObservableCollection<NavItem> NavigationItems
        {
            get => navigationItems;
            set
            {
                navigationItems = value;
            }
        }
        public Profile Profile
        {
            get => profile;
            set
            {
                profile = value;
            }
        }

        public IndexViewModel(Profile p)
        {
            Profile = p;
            initTab();
        }
        private void initTab()
        {
            NavigationItems = new ObservableCollection<NavItem>();
            var t = new TestView();
            NavigationItems.Add(new NavItem()
            {
                Control = t,
                Title = "Test"
            });
        }
    }
    public class NavItem
    {
        public string Title { get; set; }
        public UserControl Control { get; set; }
    }
}
