using netflix.Authorization.Users;
using netflix.Models.TokenAuth;
using netflix.wpf.Command;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace netflix.wpf.ViewModels.Auth
{
    public class LoginViewModel: BaseViewModel
    {
        private AuthenticateModel user;
        private ICommand login;
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
            var authData = this.postData<AuthenticateResultModel>("/api/TokenAuth/Authenticate", User);
            var x = 1;
        }
        public AuthenticateModel User
        {
            get => user;
            set
            {
                user = value;
            }
        }
        public LoginViewModel()
        {

        }
    }
}
