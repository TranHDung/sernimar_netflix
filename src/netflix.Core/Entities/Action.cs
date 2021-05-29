using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Entities
{
    public class Action : Entity
    {
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int ActionTypeId { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int MediaId { get; set; }
        public Media Media { get; set; }
    }
}
