using netflix.Authorization.Users;
using netflix.Models.TokenAuth;
using netflix.Users.Dto;
using netflix.wpf.Command;
using netflix.wpf.Models;
using netflix.wpf.VỉewModel;
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
        public LoginViewModel()
        {
            AuthData = new AuthenticateModel();
            User = new UserDto();
            IsLoggedIn = false;
            IsAdminUser = false;
            RegisterTabIndex = 1;
        }
    }
}
