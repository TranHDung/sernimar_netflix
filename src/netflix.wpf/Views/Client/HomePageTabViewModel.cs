using netflix.Entities;
using netflix.wpf.Models;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.wpf.Views.Client
{
    public class HomePageTabViewModel: BaseViewModel
    {
        private Profile profile;
        private List<Media> suggestVideos;
        private Media themeVideo;
        public Media ThemeVideo
        {
            get => themeVideo;
            set
            {
                themeVideo = value;
                OnPropertyChanged();
            }
        }
        public List<Media> SuggestVideos
        {
            get => suggestVideos;
            set
            {
                suggestVideos = value;
                OnPropertyChanged();
            }
        }
        private Profile Profile
        {
            get => profile;
            set
            {
                profile = value;
                OnPropertyChanged();
            }
        }

        private void getInitData()
        {
            //
            SuggestVideos = getData<List<Media>>("/api/services/app/Media/GetAll");
            ThemeVideo = SuggestVideos[0];
        }

        public HomePageTabViewModel()
        {
            Profile = new Profile();
            Profile.Id = int.Parse(AuthToken.getProfileId());
            getInitData();
        }
    }
}
