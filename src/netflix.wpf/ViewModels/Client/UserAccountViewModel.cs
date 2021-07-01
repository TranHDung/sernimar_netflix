using netflix.Entities;
using netflix.Sessions.Dto;
using netflix.Users.Dto;
using netflix.wpf.Command;
using netflix.wpf.Models;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace netflix.wpf.ViewModels.Client
{
    public class UserAccountViewModel: BaseViewModel
    {
        private long userId { get; set; }
        public bool IsAdd { get; set; }
        public string PageTitle { get; set; }
        public UserDto User { get; set; }
        public ObservableCollection<Profile> Profiles { get; set; }
        private bool isSuccessed;
        private ICommand saveChange;

        public ICommand SaveChange
        {
            get
            {
                if (saveChange == null)
                {
                    saveChange = new RelayCommand(
                       p => true, p => saveToDb());
                }
                return saveChange;
            }
        }
        public bool IsSuccessed
        {
            get => isSuccessed;
            set
            {
                isSuccessed = value;
                OnPropertyChanged();
            }
        }
        private ICommand createProfileCommand;
        public ICommand CreateProfileCommand
        {
            get
            {
                if (createProfileCommand is null)
                {
                    createProfileCommand = new RelayCommand(p => true, p => createProfile());
                }
                return createProfileCommand;
            }
        }
        private void createProfile()
        {
            if (User.Id != 0 && NewProfile.Name is not null)
            {
                NewProfile.UserId = (int)User.Id;
                var profile = postData<Profile>("/api/services/app/Profile/Add", NewProfile);
                if (profile != null)
                {
                    Profiles.Add(profile);
                    NewProfile = new Profile();
                }
            }
        }
        private ICommand deleteProfileCommand;
        public ICommand DeleteProfileCommand
        {
            get
            {
                if (deleteProfileCommand is null)
                {
                    deleteProfileCommand = new RelayCommand(p => true, p => deleteProfile(p));
                }
                return deleteProfileCommand;
            }
        }
        private void deleteProfile(object pr)
        {
            var p = pr as Profile;
            if (p is not null)
            {
                DeleteData("/api/services/app/Profile/Remove?profileId="+p.Id);
                Profiles.Remove(p);
            }
        }
        private Profile newProfile;
        public Profile NewProfile
        {
            get => newProfile;
            set
            {
                newProfile = value;
                OnPropertyChanged();
            }
        }

        private void saveToDb()
        {
            //call edit api
            var updatedUser = putData<UserDto>("/api/services/app/User/Update", User);
            if (updatedUser == null)
            {
                System.Windows.MessageBox.Show("Thao tác không thành công, vui lòng kiểm tra lại!");
            }
            else
            {
                System.Windows.MessageBox.Show("Sửa thành công!");
            }
        }
        private void getInitData()
        {
            var id = int.Parse(AuthToken.getUserId());
            NewProfile = new Profile();
           User = getData<UserDto>("/api/services/app/User/Get?Id=" + id);
           Profiles = new ObservableCollection<Profile>(getData<List<Profile>>("/api/services/app/Profile/GetProfilesByUserId?userId=" + id));

        }

        public UserAccountViewModel()
        {
            getInitData();
        }
    }
}
