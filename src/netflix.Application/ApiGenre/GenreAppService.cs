using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netflix.Entities;

namespace netflix.ApiGenre
{
    public class GenreAppService : ApplicationService, IGenreAppService
    {
        private readonly IRepository<Genre> _genreRepository;
        public GenreAppService(IRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task Add(Genre genre)
        {
            await _genreRepository.InsertAsync(genre)
        }
    }
}
