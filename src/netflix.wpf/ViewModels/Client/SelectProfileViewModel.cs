using netflix.Entities;
using netflix.Sessions.Dto;
using netflix.wpf.Command;
using netflix.wpf.Models;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace netflix.wpf.ViewModels.Client
{
    public class SelectProfileViewModel: BaseViewModel
    {
        private ObservableCollection<Profile> profiles;
        public ObservableCollection<Profile> Profiles
        {
            get => profiles;
            set
            {
                profiles = value;
                OnPropertyChanged();
            }
        }
        private int userId { get; set; }
        private ICommand createProfileCommand;
        public ICommand CreateProfileCommand
        {
            get
            {
                if(createProfileCommand is null)
                {
                    createProfileCommand = new RelayCommand(p => true, p => createProfile());
                }
                return createProfileCommand;
            }
        }
        private void createProfile()
        {
            if(userId != 0 && NewProfile.Name is not null)
            {
                NewProfile.UserId = userId;
                var profile = postData<Profile>("/api/services/app/Profile/Add", NewProfile);
                if (profile != null)
                {
                    Profiles.Add(profile);
                    NewProfile = new Profile();
                }
            }
            else
            {
                
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
        
        private void getInitData()
        {
            NewProfile = new Profile();
            var userId = int.Parse(AuthToken.getUserId());
            Profiles = new ObservableCollection<Profile>(getData<List<Profile>>("/api/services/app/Profile/GetProfilesByUserId?userId=" + userId));
        }

        public SelectProfileViewModel()
        {
            getInitData();
        }
    }
}
