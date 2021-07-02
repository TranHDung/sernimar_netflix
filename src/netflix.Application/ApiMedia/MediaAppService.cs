using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netflix.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using netflix.ApiMedia.Dto;
using System.Net.Http;
using HtmlAgilityPack;

namespace netflix.ApiGenre
{
    public class MediaAppService : ApplicationService, IMediaAppService
    {
        private readonly IRepository<Media> _mediaRepository;
        public MediaAppService(IRepository<Media> mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }
        public async Task<int> Add(Media entity)
        {
            entity.CreatedDate = DateTime.Now;
            int result = 0;
            try
            {
                result = await _mediaRepository.InsertAndGetIdAsync(entity);
            }
            catch(Exception ex)
            {
                var x = ex;
            }
            return result;
        }

        public async Task Delete(int mediaId)
        {
            var media = _mediaRepository.FirstOrDefault(m => m.Id == mediaId);
            await _mediaRepository.DeleteAsync(media);
        }

        public async Task<List<Media>> GetAll()
        {
            var entities = await _mediaRepository.GetAllListAsync();
            return entities;
        }

        public async Task<List<Media>> Search(MediaSearchDto search)
        {
            var query = _mediaRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(q => q.Name.Contains(search.Name));
            }
            if (search.GenreId > 0)
            {
                query = query.Where(q => q.GenreId == search.GenreId);
            }
            if (search.FromCreatedDate != null)
            {
                query = query.Where(q => q.CreatedDate > search.FromCreatedDate);
            }
            if (search.ToCreatedDate != null)
            {
                query = query.Where(q => q.CreatedDate > search.ToCreatedDate);
            }

            return query.ToList();
        }

        public async Task<bool> UploadMedia(IFormFile file, int mediaId)
        {
            if (file != null && file.Length > 0)
            {
                try
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\video", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    var media = _mediaRepository.FirstOrDefault(m => m.Id == mediaId);
                    if (media == null)
                    {
                        return false;
                    }
                    media.FilePath = filePath;
                    _mediaRepository.Update(media);
                    return true;
                }
                catch(Exception ex)
                {
                    var z = 1;
                }
            }
            return false;
        }

        public async Task<IMDBInfo> GetInfoFromIMDB(string IMDBLink)
        {
            var httpClient = new HttpClient();

            var html = await httpClient.GetStringAsync(IMDBLink);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var rating = doc.QuerySelector(".AggregateRatingButton__RatingScore-sc-1il8omz-1")?.InnerText;
            var description = doc.QuerySelector(".GenresAndPlot__TextContainerBreakpointXS_TO_M-cum89p-0")?.InnerText;
            var name = doc.QuerySelector(".TitleHeader__TitleText-sc-1wu6n3d-0")?.InnerText;
            return new IMDBInfo 
            {
                Rating = double.Parse(rating),
                Description = description,
                Name = name
            };
        }

        public async Task Update(Media media)
        {
            var entity = await _mediaRepository.FirstOrDefaultAsync(f => f.Id == media.Id);
            entity.GenreId = media.GenreId;
            entity.IBDMLink = media.IBDMLink;
            entity.ImdbRating = media.ImdbRating;
            entity.Name = media.Name;
            entity.RawName = media.RawName;
            entity.FilePath = media.FilePath;
            entity.Type = media.Type;
            entity.Description = media.Description;
            await _mediaRepository.UpdateAsync(entity);
        }
    }
}
