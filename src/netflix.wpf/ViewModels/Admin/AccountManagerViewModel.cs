using netflix.Authorization.Users;
using netflix.Entities;
using netflix.wpf.Command;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace netflix.wpf.ViewModel.Admin
{
    public class AccountManagerViewModel: BaseViewModel
    {
        private ObservableCollection<SelectableItem<User>> users;
        private ObservableCollection<UserType> types;
        private ObservableCollection<Profile> profiles;
        private ICommand deleteUserCommand;

        public ICommand DeleteUserCommand
        {
            get
            {
                if (deleteUserCommand == null)
                {
                    deleteUserCommand = new RelayCommand(
                       p => true, p => deleteUser());
                }
                return deleteUserCommand;
            }
        }

        private List<SelectableItem<User>> getSelectedItems()
        {
            return users.Where(i => i.Selected = true).ToList();
        }

        void deleteUser()
        {
            var x = Users.ToList();
            x.RemoveAll(i => i.Selected == true);
            Users = new ObservableCollection<SelectableItem<User>>(x);
        }

        public ObservableCollection<SelectableItem<User>> Users
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
            //dummies
            var _users = new ObservableCollection<SelectableItem<User>>();
            for (int i=0; i<=10; i++)
            {

                var user = new SelectableItem<User>();
                user.User = new User
                {
                    Id = i,
                    UserTypeId = 1,
                    UserName = "username" + i,
                    Profiles = new List<Profile>() 
                    { 
                        new Profile()
                        {
                            Name = "profile 1",
                        },
                        new Profile()
                        {
                            Name = "profile 1",
                        },
                    },
                    
                    Name = "Ten day du cua user nay " + i,
                };
                user.Selected = false;
                _users.Add(user);
            }
            Users = _users;
        }
    }
    public class SelectableItem<T>
    {
        public T User { get;set; }
        public bool Selected { get;set; }
    }
}

