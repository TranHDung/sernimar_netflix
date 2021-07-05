using Abp.Application.Services;
using Abp.Domain.Repositories;
using netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Orders
{
    public class OrderAppService : ApplicationService, IOrderAppService
    {
        private readonly IRepository<Order> _orderRepository;
        public OrderAppService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetByUserId(long userId)
        {
            return _orderRepository.GetAll().Where(o => o.UserId == userId).ToList();
        }

        public async Task<OrderStat> GetOrderStat()
        {
            var stat = new OrderStat();
            stat.OrderAndProfs = new List<OrderAndProf>();

            var allOrder = await _orderRepository.GetAllListAsync();
            for(int i = 7; i >= 0; i --)
            {
                var item = new OrderAndProf();
                item.Date = DateTime.Today.AddDays(-i);

                var x = allOrder.Where(i => i.CreatedDate == item.Date).Sum(i => i.Price);
                item.Prof = (int)x;
                stat.OrderAndProfs.Add(item);
            }
            return stat;
        }

        public async Task<int> UserCreateOrder(Order order)
        {
            order.CreatedDate = DateTime.Today;
            order.ExpireDate = DateTime.Today.AddDays(30);
            order.User = null;
            try
            {
             await _orderRepository.InsertAndGetIdAsync(order);

            }
            catch(Exception e)
            { 

            }
            return 1;
        }
    }
}
