using netflix.Authorization.Users;
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
    public class AddOrEditAccountViewModel : BaseViewModel
    {
        private User user;
        public bool IsAdd { get; set; }
        public string PageTitle { get; set; }
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
            var xx = User;
            if (IsAdd)
            {
                var createdtUser = postData<User>("/api/services/app/User/Create", User);
                // call add api
                var x = 1;
            }
            else
            {
                //call edit api
                var x = 1;
            }
        }

        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }
        public AddOrEditAccountViewModel(User user)
        {
            User = user;
            if (user is null)
            {
                User = new User();
                IsAdd = true;
                PageTitle = "Thêm mới tài khoản";
            }
            else
            {
                PageTitle = "Chỉnh sửa tài khoản";
                IsAdd = false;
            }
        }
    }
}
