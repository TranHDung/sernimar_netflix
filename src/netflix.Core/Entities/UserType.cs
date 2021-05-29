using Abp.Domain.Entities;
using netflix.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Entities
{
    public class UserType : Entity
    {
        public int MyProperty { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
