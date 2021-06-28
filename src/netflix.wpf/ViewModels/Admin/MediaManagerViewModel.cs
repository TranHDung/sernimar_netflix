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

namespace netflix.wpf.ViewModels.Admin
{
    public class MediaManagerViewModel : BaseViewModel
    {
        private Genre selectedGenre;
        private List<Selectable<Media>> medias;
        private ICommand submitSearchCommand;
        private ICommand deleteMediaCommand;
        private DateTime fromCreatedDate;
        private DateTime toCreatedDate;
        private string searchString;
        private List<Genre> genres;
        private MediaSearchDto searchModel;
        public MediaSearchDto SearchModel
        {
            get => searchModel;
            set
            {
                searchModel = value;
            }
        }
        public List<Genre> Genres
        {
            get => genres;
            set
            {
                genres = value;
                OnPropertyChanged();
            }
        }
        public string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;
            }
        }
        public Genre SelectedGenre
        {
            get => selectedGenre;
            set
            {
                selectedGenre = value;
                OnPropertyChanged();
            }
        }
        public DateTime FromCreatedDate
        {
            get => toCreatedDate;
            set
            {
                toCreatedDate = value;
            }
        }
        public DateTime ToCreatedDate
        {
            get => fromCreatedDate;
            set
            {
                fromCreatedDate = value;
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
        private void submitSearch()
        {
            // call api here
            SearchModel = new MediaSearchDto()
            {
                Name = SearchString,
                GenreId = SelectedGenre.Id,
                FromCreatedDate = FromCreatedDate,
                ToCreatedDate = ToCreatedDate,
            };
            var _medias = postData<List<Media>>("/api/services/app/Media/Search", SearchModel);
            if (_medias is not null)
            {
                _medias.ForEach(m =>
                {
                    m.Genre = Genres.Where(i => i.Id == m.GenreId).First();
                });
                Medias = _medias.Select(i => new Selectable<Media> { Item = i, Selected = false }).ToList(); ;
            };
        }
        void deleteMedia()
        {
            var x = Medias.ToList();
            var selecteds = x.Where(i => i.Selected == true).ToList();

            if (selecteds.Count > 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Xóa " + selecteds.Count + " media?", "Xóa Media", MessageBoxButton.YesNoCancel);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    selecteds.ForEach(u =>
                    {
                        DeleteData("/api/services/app/Media/Delete?mediaId=" + u.Item.Id);
                    });
                    getInitData(null);
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

        private void getInitData(Genre defaultGen)
        {

            if(defaultGen is not null)
            {
                var _media = getData<List<Media>>("/api/services/app/Media/GetAll");
                var _genres = getData<List<Genre>>("/api/services/app/Genre/GetAll");
                _genres.Insert(0, new Genre() { Name = "-----Không lựa chọn-----", Id = 0 });
                SelectedGenre = _genres.Where(i => i.Id == defaultGen.Id).FirstOrDefault();
                Genres = _genres;

                _media.ForEach(m =>
                {
                    m.Genre = Genres.Where(i => i.Id == m.GenreId).First();
                });

                Medias = _media.Select(i => new Selectable<Media> { Item = i, Selected = false }).ToList();
                submitSearch();
            }
            else
            {
                var _media = getData<List<Media>>("/api/services/app/Media/GetAll");
                var _genres = getData<List<Genre>>("/api/services/app/Genre/GetAll");
                _genres.Insert(0, new Genre() { Name = "-----Không lựa chọn-----", Id = 0 });
                SelectedGenre = _genres[0];
                Genres = _genres;

                _media.ForEach(m =>
                {
                    m.Genre = Genres.Where(i => i.Id == m.GenreId).First();
                });
                Medias = _media.Select(i => new Selectable<Media> { Item = i, Selected = false }).ToList();
            }
            
        }
        public MediaManagerViewModel(Genre gen)
        {
            getInitData(gen);
            FromCreatedDate = DateTime.Today.AddYears(-3);
            ToCreatedDate = DateTime.Today;
        }
    }
}
