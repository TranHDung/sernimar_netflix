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
    public class AddOrEditGenreViewModel: BaseViewModel
    {
        private Genre genre;
        private bool isAdd;
        private ICommand submitCommand;
        public string Title { get; set; }
        public bool IsAdd
        {
            get => isAdd;
            set
            {
                isAdd = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                if(submitCommand == null)
                {
                    submitCommand = new RelayCommand(p => true, p => submit());
                }
                return submitCommand;
            }
        }

        private void submit()
        {
            if (IsAdd)
            {
                var createdId = postData<int>("/api/services/app/Genre/Add", Genre);
                if (createdId == 0)
                {
                    System.Windows.MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                }
                else
                {
                    //clear
                    Genre = new Genre();
                    System.Windows.MessageBox.Show("Thêm thành công!");
                }
            }
            else
            {
                ////call edit api
                var _gen = Genre;
                var updated = putData<Genre>("/api/services/app/Genre/Update", _gen);

                if (updated is null)
                {
                    System.Windows.MessageBox.Show("Thao tác không thành công, vui lòng kiểm tra lại!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Sửa thành công!");
                }
            }
        }

        public Genre Genre
        {
            get => genre;
            set
            {
                genre = value;
                OnPropertyChanged();
            }
        }


        public AddOrEditGenreViewModel(Genre _genre)
        {
            if(_genre is null)
            {
                // add new genre
                Genre = new Genre();
                IsAdd = true;
                Title = "Thêm thể loại";
            }
            else
            {
                // edit genre
                Genre = _genre;
                IsAdd = false;
                Title = "Cập nhật thể loại";
            }
        }
    }
}
