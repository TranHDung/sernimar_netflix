using netflix.Authorization.Users;
using netflix.Entities;
using netflix.Users.Dto;
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
        private bool isEmty;
        private UserDto user;

        public List<Order> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }
        public bool IsEmpty
        {
            get => isEmty;
            set
            {
                isEmty = value;
                OnPropertyChanged();
            }
        }

        public UserDto User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }

        private void getInitData()
        {
            var Orders = getData<List<Order>>("/api/services/app/Order/GetByUserId?userId="+User.Id);
            if(Orders is null || Orders.Count == 0)
            {
                IsEmpty = true;
            }
        }

        public OrderHistoryViewModel(UserDto user)
        {
            User = user;
            getInitData();
            // get user's order history by userId
            // dummies
        }

    }
}
