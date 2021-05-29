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
        public int UserId { get; set; }
        public User User { get; set; }
        public int Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
