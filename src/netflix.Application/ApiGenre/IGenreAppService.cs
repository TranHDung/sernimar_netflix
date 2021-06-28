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
        public Task<int> Add(GenreDto genre);
        public Task<Genre> Update(Genre genre);
        public Task Delete(int genreId);
        public Task<List<Genre>> GetAll();
    }
}
