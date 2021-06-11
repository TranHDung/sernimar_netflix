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
        public Media Media
        {
            get => media;
            set
            {
                media = value;
                OnPropertyChanged();
            }
        }
        private ICommand saveChange;

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

        private void saveToDb()
        {
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
