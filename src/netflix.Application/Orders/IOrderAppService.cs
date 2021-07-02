using Abp.Application.Services;
using netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        public List<Order> GetByUserId(long userId);
        public Task<int> UserCreateOrder(Order order);
        public Task<OrderStat> GetOrderStat();
    }
}
