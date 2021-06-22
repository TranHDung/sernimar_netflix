using netflix.Authorization.Users;
using netflix.Entities;
using netflix.Users.Dto;
using netflix.wpf.Command;
using netflix.wpf.Helpers;
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
        private List<Selectable<UserDto>> users;
        private List<UserType> types;
        private List<Profile> profiles;
        private List<Genre> genres;
        private ICommand deleteUserCommand;
        private ICommand reloadCommand;
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
        public ICommand ReloadCommand
        {
            get
            {
                if (reloadCommand == null)
                {
                    reloadCommand = new RelayCommand(
                       p => true, p => getAllUser());
                }
                return reloadCommand;
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
            var selectedUsers = x.Where(i => i.Selected == true).ToList();

            if(selectedUsers.Count > 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Xóa " + selectedUsers.Count + " tài khoản?", "Xóa tài khoản", MessageBoxButton.YesNoCancel);
                if(messageBoxResult == MessageBoxResult.Yes)
                {
                    selectedUsers.ForEach(u =>
                    {
                        DeleteData("/api/services/app/User/Delete?Id=" + u.Item.Id);
                    });
                    getAllUser();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa");
            }

        }

        public List<Selectable<UserDto>> Users
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

        private void getAllUser()
        {
            var _users = getData<PagedResultDto<UserDto>>("/api/services/app/User/GetAll");
            var selectableUser = _users.Items.Select(i => new Selectable<UserDto>()
            {
                Item = i,
                Selected = false,
            }).ToList();
            Users = selectableUser;
        }

        public AccountManagerViewModel()
        {
            getAllUser();
        }
    }
}

