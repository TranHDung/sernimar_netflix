using Abp.Application.Services;
using netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.ApiGenre
{
    public interface IGenreAppService : IApplicationService
    {
        public Task Add(Genre genre);
    }
}
