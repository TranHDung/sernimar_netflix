using netflix.Authorization.Users;
using netflix.Entities;
using netflix.wpf.Command;
using netflix.wpf.Models;
using netflix.wpf.VỉewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace netflix.wpf.ViewModel.Admin
{
    public class AccountManagerViewModel: BaseViewModel
    {
        private List<Selectable<User>> users;
        private List<UserType> types;
        private List<Profile> profiles;
        private List<Genre> genres;
        private ICommand deleteUserCommand;
        private ICommand submitSearchCommand;
        private string searchString;
        public string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;
            }
        }
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

        public ICommand SubmitSearchCommand
        {
            get
            {
                if (submitSearchCommand == null)
                {
                    submitSearchCommand = new RelayCommand(
                       p => true, p => submitSearch());
                }
                return submitSearchCommand;
            }
        }


        private void submitSearch()
        {
            if(SearchString is not null)
            {
                // get search data
            }

        }


        void deleteUser()
        {   
            var x = Users.ToList();
            var selectedCount = x.Where(i => i.Selected == true).ToList().Count;

            if(selectedCount > 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Xóa " + selectedCount + " tài khoản?", "Xóa tài khoản", MessageBoxButton.YesNoCancel);
                if(messageBoxResult == MessageBoxResult.Yes)
                {
                    x.RemoveAll(i => i.Selected == true);
                    Users = new List<Selectable<User>>(x);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa");
            }

        }

        public List<Selectable<User>> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }
                
        public List<UserType> Types
        {
            get => types;
        }
                
        public List<Profile> Profiles
        {
            get => profiles;
            set
            {
                profiles = value;
                OnPropertyChanged();
            }
        }

        public List<Genre> Genres
        {
            get
            {
                return genres;
            }
            set
            {
                genres = value;
                OnPropertyChanged();
            }
        }

        private List<User> getAllUser()
        {
            var _users = getData<List<User>>("/api/services/app/User/GetAll");
            return _users;
        }

        public AccountManagerViewModel()
        {
            var selectableUser = getAllUser().Select(i => new Selectable<User>()
            {
                Item = i,
                Selected = false,
            }).ToList();
            Users = selectableUser;
        }
    }
}

