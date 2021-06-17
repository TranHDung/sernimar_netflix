using netflix.Authorization.Users;
using netflix.Models.TokenAuth;
using netflix.Users.Dto;
using netflix.wpf.Command;
using netflix.wpf.Models;
using netflix.wpf.VỉewModel;
using System.Windows.Input;

namespace netflix.wpf.ViewModels.Auth
{
    public class LoginViewModel: BaseViewModel
    {
        private AuthenticateModel authData;
        public UserDto User { get; set; }
        private bool isLoggedIn;
        private bool isAdminUser;
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
        public bool IsAdminUser
        {
            get => isAdminUser;
            set
            {
                isAdminUser = value;
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
                       p => true, p => submitLogin());
                }
                return login;
            }
        }
        private void submitLogin()
        {
            var result = postData<AuthenticateResultModel>("/api/TokenAuth/Authenticate", AuthData);
            if (result is null)
            {
                System.Windows.MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }
            else
            {
                AuthToken.setAccessToken(result.AccessToken);
                User = getData<UserDto>("/api/services/app/User/Get?Id=" + result.UserId);
                IsLoggedIn = true;
                if (User.RoleNames[0] == "ADMIN")
                {
                    IsAdminUser = true;
                }
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
        }
    }
}
