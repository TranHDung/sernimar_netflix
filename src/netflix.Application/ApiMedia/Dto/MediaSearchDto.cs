using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.ApiMedia.Dto
{
    public class MediaSearchDto
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public DateTime? FromCreatedDate { get; set; }
        public DateTime? ToCreatedDate { get; set; }
    }
}
