using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Entities
{
    [AutoMapper]
    public class Genre : Entity
    {
        public int Name { get; set; }
        public List<Media> Medias { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
