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
    }
}
