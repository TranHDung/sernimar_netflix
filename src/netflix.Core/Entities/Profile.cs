using Abp.Domain.Entities;
using netflix.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Entities
{
    public class Profile : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public IEnumerable<Action> Actions { get; set; }
    }
}
