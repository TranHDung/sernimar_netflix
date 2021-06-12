using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix
{
    public class ApiResponse<T>
    {
        public ICollection<T> result { get; set; }
        public string targetUrl { get; set; }
        public bool success { get; set; }
        public ICollection<string> error { get; set; }
        public bool unAuthorizedRequest { get; set; }
        public bool __abp { get; set; }
    }
}
