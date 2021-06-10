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
        public async Task Add(GenreDto genre)
        {
            var entity = new Genre();
            entity.Name = genre.Name;
            entity.CreatedDate = DateTime.Now;
            await _genreRepository.InsertAsync(entity);
        }

        public async Task<List<GenreDto>> GetAll()
        {
            var entities = await _genreRepository.GetAllListAsync();
            var dtos = ObjectMapper.Map<List<GenreDto>>(entities);
            return dtos;
        }
    }
}
