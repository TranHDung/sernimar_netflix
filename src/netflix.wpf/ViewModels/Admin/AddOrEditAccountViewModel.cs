using netflix.Authorization.Users;
using netflix.Roles.Dto;
using netflix.Users.Dto;
using netflix.wpf.Command;
using netflix.wpf.Helpers;
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
        private CreateUserDto createUserDto;
        private long userId { get; set; }
        public bool IsAdd { get; set; }
        public string PageTitle { get; set; }
        private bool isSuccessed;
        private List<RoleDto> roles;
        private RoleDto selectedRole;
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
        public List<RoleDto> Roles
        {
            get => roles;
            set
            {
                roles = value;
                OnPropertyChanged();
            }
        }
        public bool IsSuccessed
        {
            get => isSuccessed;
            set
            {
                isSuccessed = value;
                OnPropertyChanged();
            }
        }
        public RoleDto SelectedRole
        {
            get => selectedRole;
            set
            {
                selectedRole = value;
                OnPropertyChanged();
            }
        }
        private void saveToDb()
        {
            if (IsAdd)
            {
                User.RoleNames = new List<string>() { SelectedRole.Name }.ToArray();
                User.IsActive = true;
                var createdtUser = postData<UserDto>("/api/services/app/User/Create", User);
                if(createdtUser == null)
                {
                    System.Windows.MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Thêm thành công!");
                    //clear
                    User = new CreateUserDto();
                    IsSuccessed = true;
                }
            }
            else
            {
                //call edit api
                var userDto = cast2UserDto(User);
                userDto.Id = this.userId;
                var updatedUser = putData<UserDto>("/api/services/app/User/Update", userDto);
                
                if (updatedUser == null)
                {
                    System.Windows.MessageBox.Show("Thao tác không thành công, vui lòng kiểm tra lại!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Sửa thành công!");
                    //clear
                    User = new CreateUserDto()
                    {
                        UserName = updatedUser.UserName,
                        EmailAddress = updatedUser.EmailAddress,
                        Name = updatedUser.Name,
                        Surname = updatedUser.Surname,
                        RoleNames = updatedUser.RoleNames,
                    }; ;
                    IsSuccessed = true;
                }
            }
        }


        private UserDto cast2UserDto(CreateUserDto createDto)
        {
            var user = new UserDto()
            {
                UserName = createDto.UserName,
                EmailAddress = createDto.EmailAddress,
                Name = createDto.Name,
                Surname = createDto.Surname,
                RoleNames = createDto.RoleNames,
            };
            return user;
        }
        private CreateUserDto cast2CreateUserDto(UserDto userDto)
        {
            var createDto = new CreateUserDto()
            {
                UserName = userDto.UserName,
                EmailAddress = userDto.EmailAddress,
                Name = userDto.Name,
                Surname = userDto.Surname,
                RoleNames = userDto.RoleNames,
                IsActive = true,
            };
            userId = userDto.Id;
            return createDto;
        }

        private void getInitData()
        {
            var roles = getData<PagedResultDto<RoleDto>>("/api/services/app/Role/GetAll");
            Roles = roles.Items;
            if(IsAdd)
            {
                SelectedRole = Roles.First(i => i.Id == 3); // 3 la role nguoi dung thuong
            }
            else
            {
                SelectedRole = Roles.First(i => i.NormalizedName == User.RoleNames[0]); // mac dinh la role dau tien
            }
        }
        public CreateUserDto User
        {
            get => createUserDto;
            set
            {
                createUserDto = value;
                OnPropertyChanged();
            }
        }
        public AddOrEditAccountViewModel(UserDto user)
        {

            IsSuccessed = false;
            if (user is null)
            {
                User = new CreateUserDto();
                IsAdd = true;
                PageTitle = "Thêm mới tài khoản";
            }
            else
            {
                User = cast2CreateUserDto(user);
                PageTitle = "Chỉnh sửa tài khoản";
                IsAdd = false;
            }
            getInitData();

        }
    }
}
