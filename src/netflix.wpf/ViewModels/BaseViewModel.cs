using netflix.wpf.Interface;
using netflix.wpf.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace netflix.wpf.VỉewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected T getData<T>(string url)
        {
            var client = new RestClient("https://localhost:44391");
            // if not null, mean user logged in
            if (AuthToken.getAccessToken() != "")
            {
                client.Authenticator = new JwtAuthenticator(AuthToken.getAccessToken());
            }
            var request = new RestRequest(url);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Get<T>(request);
            var obj = JsonConvert.DeserializeObject<Root<T>>(response.Content);
            
            return obj.result;
        }
        protected T postData<T>(string url, object payload)
        {
            var client = new RestClient("https://localhost:44391");
            // if not null, mean user logged in
            if (AuthToken.getAccessToken() != "")
            {
                client.Authenticator = new JwtAuthenticator(AuthToken.getAccessToken());
            }
            var request = new RestRequest(url);
            request.AddJsonBody(payload);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Post<T>(request);
            var obj = JsonConvert.DeserializeObject<Root<T>>(response.Content);
            return obj.result;
        }
        protected bool DeleteData(string url)
        {
            var client = new RestClient("https://localhost:44391");
            // if not null, mean user logged in
            if (AuthToken.getAccessToken() != "")
            {
                client.Authenticator = new JwtAuthenticator(AuthToken.getAccessToken());
            }
            var request = new RestRequest(url);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Delete(request);

            return response.IsSuccessful;
        }
        protected T putData<T>(string url, object payload)
        {
            var client = new RestClient("https://localhost:44391");
            // if not null, mean user logged in
            if (AuthToken.getAccessToken() != "")
            {
                client.Authenticator = new JwtAuthenticator(AuthToken.getAccessToken());
            }
            var request = new RestRequest(url);
            request.AddJsonBody(payload);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Put<T>(request);
            var obj = JsonConvert.DeserializeObject<Root<T>>(response.Content);
            return obj.result;
        }
    }
    public class Root<T>
    {
        public T result { get; set; }
        public object targetUrl { get; set; }
        public bool success { get; set; }
        public object error { get; set; }
        public bool unAuthorizedRequest { get; set; }
        public bool __abp { get; set; }
    }
}
