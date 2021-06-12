using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Entities
{
    public class Media : Entity
    {
        public string Name { get; set; }
        public string RawName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string IBDMLink { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<Action> Actions { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int ImdbRating { get; set; }
    }
}
