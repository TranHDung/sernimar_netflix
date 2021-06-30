using netflix.Entities;
using netflix.Sessions.Dto;
using netflix.wpf.Command;
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
            // get current user info
            var curInfo = getData<GetCurrentLoginInformationsOutput>("/api/services/app/Session/GetCurrentLoginInformations");
            if(curInfo is not null)
            {
                NewProfile.UserId = (int)curInfo.User.Id;
                var profile = postData<Profile>("/api/services/app/Profile/Add", NewProfile);
                if (profile != null)
                {
                    Profiles.Add(profile);

                    Profiles = Profiles;
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
            Profiles = new ObservableCollection<Profile>();
        }

        public SelectProfileViewModel()
        {
            var _ = new List<Profile>();
            getInitData();
        }
    }
}
