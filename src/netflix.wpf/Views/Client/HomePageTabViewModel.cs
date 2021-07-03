using netflix.ApiMedia.Dto;
using netflix.Entities;
using netflix.wpf.Command;
using netflix.wpf.Models;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace netflix.wpf.Views.Client
{
    public class HomePageTabViewModel: BaseViewModel
    {
        private Profile profile;
        private List<Media> suggestVideos;
        private SuggestVideoModel mainModel;
        public SuggestVideoModel MainModel
        {
            get => mainModel;
            set
            {
                mainModel = value;
                OnPropertyChanged();
            }
        }
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
        private ICommand addToListCommand;
        public ICommand AddToListCommand
        {
            get
            {
                if (addToListCommand is null)
                {
                    addToListCommand = new RelayCommand(p => true, p => addToList());
                }
                return addToListCommand;
            }
        }
        private void addToList()
        {
            //
            var act = new Entities.Action()
            {
                ProfileId = int.Parse(AuthToken.getProfileId()),
                ActionTypeId = 2, //2 la add to playlist
                MediaId = themeVideo.Id,
            };
            var id = this.postData<int>("/api/services/app/Action/Add", act);
            if (id > 0)
            {
                MessageBox.Show("Đã thêm vào playlist");
            }
            else
            {
                MessageBox.Show("Không thể thêm, vui lòng thử lại");
            }
        }
        private void getInitData()
        {
            var pid = int.Parse(AuthToken.getProfileId());
            MainModel = getData<SuggestVideoModel>("/api/services/app/Media/GetSuggestMediaByProfileId?profileId=" + pid);
            ThemeVideo = MainModel.NewVideos[0];
            SuggestVideos = MainModel.NewVideos;
        }

        public HomePageTabViewModel()
        {
            Profile = new Profile();
            Profile.Id = int.Parse(AuthToken.getProfileId());
            getInitData();
        }
    }
}
