using Abp.Domain.Entities;
using netflix.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Entities
{
    public class Order : Entity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
