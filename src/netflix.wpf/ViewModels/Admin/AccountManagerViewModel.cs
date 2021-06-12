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
        private ObservableCollection<Selectable<User>> users;
        private ObservableCollection<UserType> types;
        private ObservableCollection<Profile> profiles;
        private ObservableCollection<Genre> genres;
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
                    Users = new ObservableCollection<Selectable<User>>(x);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa");
            }

        }

        public ObservableCollection<Selectable<User>> Users
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

        public ObservableCollection<Genre> Genres
        {
            get
            {
                var client = new RestClient("https://localhost:44391");
                var request = new RestRequest("api/services/app/Genre/GetAll");
                var data = client.Post<ApiResponse<Genre>>(request).Data;
                var _genres = new ObservableCollection<Genre>();
                foreach (var item in data.result)
                {
                    _genres.Add(item);
                }
                return _genres;
            }
            set
            {
                genres = value;
                OnPropertyChanged();
            }
        }

        public AccountManagerViewModel()
        {
            //dummies

            //test
            var client = new RestClient("https://localhost:44391");
            var request = new RestRequest("api/services/app/Genre/GetAll");
            var _genre = client.Post<List<Genre>>(request).Data;
            //test

            var _users = new ObservableCollection<Selectable<User>>();
            for (int i=0; i<=10; i++)
            {

                var user = new Selectable<User>();
                user.Item = new User
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
}

