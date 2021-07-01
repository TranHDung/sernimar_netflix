using netflix.Entities;
using netflix.wpf.Command;
using netflix.wpf.Models;
using netflix.wpf.VỉewModel;
using System.Windows;
using System.Windows.Input;
using Action = netflix.Entities.Action;

namespace netflix.wpf.ViewModels.Client
{
    public class MediaDetailViewModel: BaseViewModel
    {
        public Media Video { get; set; }
        private ICommand addToListCommand;
        public ICommand AddToListCommand
        {
            get
            {
                if(addToListCommand is null)
                {
                    addToListCommand = new RelayCommand(p => true, p => addToList());
                }
                return addToListCommand;
            }
        }
        private void addToList()
        {
            //
            var act = new Action()
            {
                ProfileId = int.Parse(AuthToken.getProfileId()),
                ActionTypeId = 2, //2 la add to playlist
                MediaId = Video.Id,
            };
            var id = this.postData<int>("/api/services/app/Action/Add", act);
            if(id > 0)
            {
                MessageBox.Show("Đã thêm vào playlist");
            }
            else
            {
                MessageBox.Show("Không thể thêm, vui lòng thử lại");
            }
        }
        private ICommand watchCommand;
        public ICommand WatchCommand
        {
            get
            {
                if(watchCommand is null)
                {
                    watchCommand = new RelayCommand(p => true, p => watch());
                }
                return watchCommand;
            }
        }
        private void watch()
        {
            //
            var act = new Action()
            {
                ProfileId = int.Parse(AuthToken.getProfileId()),
                ActionTypeId = 1, //1 la watch
                MediaId = Video.Id,
            };
            var id = this.postData<int>("/api/services/app/Action/Add", act);
        }

        public MediaDetailViewModel(Media m)
        {
            Video = m;
        }
    }
}
