using netflix.wpf.View.Admin.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.wpf.VỉewModel.Admin
{
    public class DashboardViewModel: BaseViewModel
    {
        private List<Action> actionLinks;
        public Media MediaTemplate{ get; set; }
        public List<Action> ActionLinks
        {
            get
            {
                return actionLinks;
            }
            set
            {
                actionLinks = value;
                OnPropertyChanged();
            }
        }
    }
    // model
    public class Action
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Uri { get; set; }
    }
}
