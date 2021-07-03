using netflix.Authorization.Accounts.Dto;
using netflix.Authorization.Users;
using netflix.Models.TokenAuth;
using netflix.Users.Dto;
using netflix.wpf.Command;
using netflix.wpf.Models;
using netflix.wpf.VỉewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace netflix.wpf.ViewModels.Auth
{
    public class LoginViewModel: BaseViewModel
    {
        private AuthenticateModel authData;
        public UserDto User { get; set; }
        private bool isLoggedIn;
        private bool isAdminUser;
        private int registerTabIndex;
        private ICommand login;
        private string rePassword;
        private ICommand selectPlanCommand;
        private bool isPlan1Select;
        public bool IsPlan1Select
        {
            get => isPlan1Select;
            set
            {
                isPlan1Select = value;
                OnPropertyChanged();
            }
        }
        public ICommand SelectPlanCommand
        {
            get
            {
                if (selectPlanCommand is null)
                {
                    selectPlanCommand = new RelayCommand(p => true, p => selectPlan(p));
                }

                return selectPlanCommand;
            }
        }
        private void selectPlan(object p)
        {
            var selected = int.Parse(p.ToString());
            if(selected == 1)
            {
                IsPlan1Select = true;
            }
            else
            {
                IsPlan1Select = false;
            }
        }
        public string RePassword
        {
            get => rePassword;
            set
            {
                rePassword = value;
            }
        }
        private RegisterInput registerModel;
        public RegisterInput RegisterModel
        {
            get
            {
                if(registerModel is null)
                {
                    registerModel = new RegisterInput();
                }
                return registerModel;
            }
            set
            {
                registerModel = value;
            }
        }
        public bool IsLoggedIn
        {
            get => isLoggedIn;
            set
            {
                isLoggedIn = value;
                OnPropertyChanged();
            }
        }
        private ICommand registerTabPrev;
        public ICommand RegisterTabPrev
        {
            get
            {
                if (registerTabPrev == null)
                {
                    registerTabPrev = new RelayCommand(
                       p => true, p => prevTab(p));
                }
                return registerTabPrev;
            }
        }
        private void prevTab(object state)
        {
            if (RegisterTabIndex < 1) return;
            RegisterTabIndex = RegisterTabIndex - 1;
        }
        private ICommand registerTabNext;
        public ICommand RegisterTabNext
        {
            get
            {
                if (registerTabNext == null)
                {
                    registerTabNext = new RelayCommand(
                       p => true, p => nextTab(p));
                }
                return registerTabNext;
            }
        }
        private void nextTab(object state)
        {
            if (RegisterTabIndex == 0)
            {
                if (!register())
                {
                    return;
                }
            }
            if (RegisterTabIndex > 3)
            {
                submitRegister();
                return;
            }
            RegisterTabIndex = RegisterTabIndex + 1;
        }
        private void submitRegister()
        {
            // do smt
        }
        public bool IsAdminUser
        {
            get => isAdminUser;
            set
            {
                isAdminUser = value;
                OnPropertyChanged();
            }
        }
        public int RegisterTabIndex
        {
            get => registerTabIndex;
            set
            {
                registerTabIndex = value;
                OnPropertyChanged();
            }
        }
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(
                       p => true, p => submitLogin(p));
                }
                return login;
            }
        }
        private void submitLogin(object state)
        {
            var pwb = (PasswordBox)state;
            AuthData.Password = pwb.Password;
            var result = postData<AuthenticateResultModel>("/api/TokenAuth/Authenticate", AuthData);
            if (result is null)
            {
                System.Windows.MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }
            else
            {
                AuthToken.setAccessToken(result.AccessToken);
                AuthToken.setUserId(result.UserId.ToString());
                User = getData<UserDto>("/api/services/app/User/Get?Id=" + result.UserId);
                if (User.RoleNames[0] == "ADMIN")
                {
                    IsAdminUser = true;
                }
                IsLoggedIn = true;

            }
        }
        public AuthenticateModel AuthData
        {
            get => authData;
            set
            {
                authData = value;
                OnPropertyChanged();
            }
        }
        private bool register()
        {
            return true;
            var r = this.postData<RegisterOutput>("/api/services/app/Account/Register", RegisterModel);
            if(r is null)
            {
                MessageBox.Show("Đăng kí không thành công, vui lòng kiểm tra lại!");
                return false;
            }
            return true;
        }
        public LoginViewModel()
        {
            AuthData = new AuthenticateModel();
            User = new UserDto();
            IsLoggedIn = false;
            IsAdminUser = false;
            RegisterTabIndex = 1;
            IsPlan1Select = true;
        }
    }
}
