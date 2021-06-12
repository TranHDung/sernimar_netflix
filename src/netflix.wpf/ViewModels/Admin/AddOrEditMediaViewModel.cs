using netflix.Entities;
using netflix.wpf.Command;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace netflix.wpf.ViewModels.Admin
{
    public class AddOrEditMediaViewModel: BaseViewModel
    {
        private Media media;
        public bool IsAdd { get; set; }
        public string PageTitle { get; set; }
        private ICommand saveChange;
        private ICommand selectFile;
        public string fileName;
        public Media Media
        {
            get => media;
            set
            {
                media = value;
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
            if (IsAdd)
            {
                // call add api
                var x = 1;
            }
            else
            {
                //call edit api
                var x = 1;
            }
        }

        public AddOrEditMediaViewModel(Media _media)
        {
            Media = _media;
            FileName = "Chưa file nào được chọn";
            if (_media is null)
            {
                IsAdd = true;
                PageTitle = "Thêm mới Media";
            }
            else
            {
                PageTitle = "Chỉnh sửa Media";
                IsAdd = false;
            }
        }
    }
}
