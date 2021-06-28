using netflix.ApiMedia.Dto;
using netflix.Entities;
using netflix.wpf.Command;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace netflix.wpf.ViewModels.Admin
{
    public class AddOrEditMediaViewModel: BaseViewModel
    {
        private Media media;
        private List<Genre> genres;
        public bool IsAdd { get; set; }
        public string PageTitle { get; set; }
        private ICommand saveChange;
        private ICommand getFromIMDB;
        private ICommand selectFile;
        private Genre selectedGenre;
        public string fileName;
        public Genre SelectedGenre
        {
            get => selectedGenre;
            set
            {
                selectedGenre = value;
                OnPropertyChanged();
            }
        }
        public Media Media
        {
            get => media;
            set
            {
                media = value;
                OnPropertyChanged();
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
        public string FileName
        {
            get => fileName;
            set
            {
                fileName = value;
                OnPropertyChanged();
            }
        }
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

        public ICommand GetFromIMDB
        {
            get
            {
                if (getFromIMDB == null)
                {
                    getFromIMDB = new RelayCommand(
                       p => true, p => getIMDB());
                }
                return getFromIMDB;
            }
        }
        public ICommand SelectFile
        {
            get
            {
                if (selectFile == null)
                {
                    selectFile = new RelayCommand(
                       p => true, p => getFile());
                }
                return selectFile;
            }
        }
        private void getIMDB()
        {
            if (Media.IBDMLink is null) return;

            var x = UrlEncoder.Default.Encode(Media.IBDMLink);
            var _temp = Media;
            var info = getData<IMDBInfo>("/api/services/app/Media/GetInfoFromIMDB?IMDBLink=" + x);
            if(info is null)
            {
                MessageBox.Show("Phim chưa có thông tin đánh giá trên IMDB, vui lòng kiểm tra lại");
                return;

            }
            if (info.Description is not null)
            {
                _temp.Description = info.Description.Trim();
            }
            if (info.Rating != 0)
            {
                //Media.ImdbRating = int.Parse(info.Rating);
                _temp.ImdbRating = 8;
            }
            Media = _temp;
        }
        private void getFile()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".mp4";
            dlg.Filter = "Files|*.mp4";
            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                FileName = filename;
            }
        }

        private void saveToDb()
        {
            //https://stackoverflow.com/questions/35478663/upload-file-without-multipart-form-data-using-restsharp
            Media.GenreId = SelectedGenre.Id;
            bool isSuccess = false;
            if (IsAdd)
            {
                var justAddedMovieId = postData<int>("/api/services/app/Media/Add", Media);

                // sau khi them thanh cong thi upload video len
                if (justAddedMovieId != 0)
                {
                    // get just added media id to start upload
                    isSuccess = uploadFile("https://localhost:44391/api/services/app/Media/UploadMedia?mediaId="+justAddedMovieId, "file", FileName);
                    MessageBox.Show("Tạo Media thành công!");

                }
                // call add api
                var x = 1;
            }
            else
            {
                //call edit api
                var x = 1;
            }
        }

        private void getInitData()
        {
            var _genres = getData<List<Genre>>("/api/services/app/Genre/GetAll");
            Genres = _genres;

            if (IsAdd)
            {
                SelectedGenre = _genres[0]; // mac dinh la the loai dau tien
            }
            else
            {
                SelectedGenre = _genres.First(i => i.Id == media.GenreId); // neu la chinh sua thi the loai mac dinh chinh la the laoi da duoc chon
            }
        }

        public AddOrEditMediaViewModel(Media _media)
        {
            Media = _media;
            FileName = "Chưa file nào được chọn";
            if (_media is null)
            {
                Media = new Media();
                Genres = new List<Genre>();
                IsAdd = true;
                PageTitle = "Thêm mới Media";
            }
            else
            {
                PageTitle = "Chỉnh sửa Media";
                IsAdd = false;
                if (Media.FilePath is not null) FileName = Media.FilePath;
            }
            getInitData();
        }
    }
}
