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

namespace netflix.wpf.ViewModels.Admin
{
    public class MediaManagerViewModel : BaseViewModel
    {
        private List<Selectable<Media>> medias;
        private ICommand deleteMediaCommand;

        public ICommand DeleteMediaCommand
        {
            get
            {
                if (deleteMediaCommand == null)
                {
                    deleteMediaCommand = new RelayCommand(
                       p => true, p => deleteMedia());
                }
                return deleteMediaCommand;
            }
        }
        void deleteMedia()
        {
            var x = Medias.ToList();
            var selectedCount = x.Where(i => i.Selected == true).ToList().Count;

            if (selectedCount > 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Xóa " + selectedCount + " media?", "Xóa Media", MessageBoxButton.YesNoCancel);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    x.RemoveAll(i => i.Selected == true);
                    Medias = x;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Media cần xóa");
            }
        }
        public List<Selectable<Media>> Medias
        {
            get => medias;
            set
            {
                medias = value;
                OnPropertyChanged();
            }
        }

        public MediaManagerViewModel()
        {
            //dummies
            var _medias = new List<Selectable<Media>>();
            for (int i = 0; i <= 10; i++)
            {

                var media = new Selectable<Media>();
                media.Item = new Media
                {
                    Id = i,
                    CreatedDate = DateTime.Today.AddDays(-i),
                    Name = "300 bo phim thieu nhi " + i,
                    RawName = "300-bo-phim-thieu-nhi-"+i,
                    Description = "300 bộ phim thiếu nhi huyển thoại đây, mại dô mại dô!!!",
                    IBDMLink = "https://www.imdb.com/title/tt8721424/",
                    Type = "Movie",
                };
                media.Selected = false;
                _medias.Add(media);
            }
            Medias = _medias;
        }
    }
}
