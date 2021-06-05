using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.wpf.Interface
{
    public interface INavigationPage
    {
        Type PageType { get; set; }
    }

    public interface INavigationService
    {
        void Navigate(INavigationPage page);
    }
}