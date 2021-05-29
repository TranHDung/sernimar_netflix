using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Entities
{
    public class ActionType : Entity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<Action> Actions { get; set; }
    }
}
