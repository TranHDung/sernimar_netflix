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
    public class GenreManagerViewModel: BaseViewModel
    {

        private List<SelectableNAcountable<Genre>> genres;
        private ICommand deleteCommand;
        private ICommand refreshCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if(deleteCommand is null)
                {
                    deleteCommand = new RelayCommand(p => true, p => delete());
                }
                return deleteCommand;
            }
        }
        public ICommand RefreshCommand
        {
            get
            {
                if(refreshCommand is null)
                {
                    refreshCommand = new RelayCommand(p => true, p => getInitData());
                }
                return refreshCommand;
            }
        }
        private void delete()
        {
            var x = Genres.ToList();
            var selectedGenres = x.Where(i => i.Selected == true).ToList();

            if (selectedGenres.Count > 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Xóa " + selectedGenres.Count + " thể loại?", "Xóa", MessageBoxButton.YesNoCancel);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    selectedGenres.ForEach(u =>
                    {
                        if (u.Count > 0)
                        {
                            MessageBox.Show("Không thể xóa những thể loại đang có phim, vui lòng kiểm tra lại!");
                            return;
                        }
                        DeleteData("/api/services/app/Genre/Delete?genreId=" + u.Item.Id);
                    });
                }
                getInitData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa");
            }
        }
        public List<SelectableNAcountable<Genre>> Genres
        {
            get => genres;
            set
            {
                genres = value;
                OnPropertyChanged();
            }
        }
        private void getInitData()
        {
            var _genres = getData<List<Genre>>("/api/services/app/Genre/GetAll");
            Genres = _genres.Select(i => new SelectableNAcountable<Genre>()
            {
                Item = i,
                Selected = false,
                Count = i.Medias.Count
            }).ToList();
        }
        public GenreManagerViewModel()
        {
            getInitData();
        }
    }
}
