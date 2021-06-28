using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netflix.Entities;
using Microsoft.EntityFrameworkCore;

namespace netflix.ApiGenre
{
    public class GenreAppService : ApplicationService, IGenreAppService
    {
        private readonly IRepository<Genre> _genreRepository;
        public GenreAppService(IRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<int> Add(GenreDto genre)
        {
            var entity = new Genre();
            entity.Name = genre.Name;
            entity.CreatedDate = DateTime.Now;
            int id = 0;
            try
            {
                id = await _genreRepository.InsertAndGetIdAsync(entity);
            }
            catch(Exception ex)
            {

            }
            return id;
        }

        public async Task Delete(int genreId)
        {
            var gen = _genreRepository.FirstOrDefault(m => m.Id == genreId);
            await _genreRepository.DeleteAsync(gen);
        }

        public async Task<List<Genre>> GetAll()
        {
            var entities = await _genreRepository.GetAllIncluding(i => i.Medias).ToListAsync();
            // cut loop
            var cloned = new List<Genre>();
            entities.ForEach(g =>
            {
                var gen = new Genre()
                {
                    Id = g.Id,
                    CreatedDate = g.CreatedDate,
                    Name = g.Name,
                    Medias = new List<Media>(),
                };
                g.Medias.ForEach(i =>
                {
                    var me = new Media()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Description = i.Description,
                    };
                    gen.Medias.Add(me);
                });
                cloned.Add(gen);
            });

            return cloned;
        }

        public async Task<Genre> Update(Genre genre)
        {

            var gen = _genreRepository.FirstOrDefault(m => m.Id == genre.Id);
            gen.Name = genre.Name;
            try
            {

                await _genreRepository.InsertOrUpdateAndGetIdAsync(gen);
            }
            catch(Exception ex)
            {

            }
            return await _genreRepository.FirstOrDefaultAsync(i => i.Id == genre.Id);
        }
    }
}
