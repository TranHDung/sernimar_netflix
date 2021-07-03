using netflix.Entities;
using netflix.wpf.Command;
using netflix.wpf.Models;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace netflix.wpf.ViewModels.Client
{
    public class PlaylistViewModel: BaseViewModel
    {
        private List<Media> medias;
        private List<Media> watchedMedias;
        private ICommand refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if(refreshCommand is null)
                {
                    refreshCommand = new RelayCommand(p => true, p =>getInitData());
                }
                return refreshCommand;
            }
        }
        public List<Media> Medias
        {
            get => medias;
            set
            {
                medias = value;
                OnPropertyChanged();
            }
        }
        public List<Media> WatchedMedias
        {
            get => watchedMedias;
            set
            {
                watchedMedias = value;
                OnPropertyChanged();
            }
        }
        private void getInitData()
        {
            var curProfileId = int.Parse(AuthToken.getProfileId());
            Medias = this.getData<List<Media>>("/api/services/app/Action/GetPlaylistByProfileId?profileId="+ curProfileId);
            WatchedMedias = this.getData<List<Media>>("/api/services/app/Action/GetWatchedListByProfileId?profileId=" + curProfileId);
        }
        public PlaylistViewModel()
        {
            getInitData();
        }
    }
}
