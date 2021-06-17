using netflix.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.wpf.Helpers
{
    public class PagedResultDto<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
        public PagedResultDto()
        {
            TotalCount = 0;
            Items = new List<T>();
        }
    }
}
