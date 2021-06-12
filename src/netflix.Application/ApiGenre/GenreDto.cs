using Abp.AutoMapper;
using netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.ApiGenre
{
    [AutoMapTo(typeof(Genre))]
    public class GenreDto
    {
        public string Name { get; set; }
    }
}
