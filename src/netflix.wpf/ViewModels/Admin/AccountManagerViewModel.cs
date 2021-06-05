using netflix.Authorization.Users;
using netflix.Entities;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.wpf.ViewModel.Admin
{
    public class AccountManagerViewModel: BaseViewModel
    {
        private ObservableCollection<User> users;
        private ObservableCollection<UserType> types;
        private ObservableCollection<Profile> profiles;

        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }
                
        public ObservableCollection<UserType> Types
        {
            get => types;
        }
                
        public ObservableCollection<Profile> Profiles
        {
            get => profiles;
            set
            {
                profiles = value;
                OnPropertyChanged();
            }
        }

        public AccountManagerViewModel()
        {
            // get data
            
        }

    }
}
