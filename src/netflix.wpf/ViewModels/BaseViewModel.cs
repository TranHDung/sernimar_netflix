using netflix.wpf.Interface;
using RestSharp;
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
            var request = new RestRequest(url);
            var data = client.Get<T>(request).Data;
            return data;
        }
        protected T postData<T>(string url, object payload)
        {
            var client = new RestClient("https://localhost:44391");
            var request = new RestRequest(url);
            request.AddJsonBody(payload);
            var data = client.Post<T>(request).Data;
            var x = client.Post<T>(request);
            return data;
        }
    }
}
