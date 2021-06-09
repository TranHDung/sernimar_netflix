using netflix.Authorization.Users;
using netflix.Entities;
using netflix.wpf.VỉewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.wpf.ViewModels.Admin
{
    public class OrderHistoryViewModel: BaseViewModel
    {
        private List<Order> orders;
        private User user;

        public List<Order> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged();
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

        public OrderHistoryViewModel(User user)
        {
            User = user;
            // get user's order history by userId
            // dummies
            var l = new List<Order>();
            for(int i = 0; i<=5; i++)
            {
                var history = new Order()
                {
                    Id = i,
                    CreatedDate = DateTime.Today.AddDays(-i),
                    ExpireDate = DateTime.Today.AddDays(-i),
                    Price = 1 * 10000,
                };
                l.Add(history);
            }
            orders = l;
        }

    }
}
