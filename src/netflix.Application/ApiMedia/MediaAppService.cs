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
            return await _mediaRepository.InsertAndGetIdAsync(entity);
        }

        public async Task DeleteMedia(int mediaId)
        {
            var media = _mediaRepository.FirstOrDefault(m => m.Id == mediaId);
            await _mediaRepository.DeleteAsync(media);
        }

        public async Task<List<Media>> GetAll()
        {
            var entities = await _mediaRepository.GetAllListAsync();
            return entities;
        }

        public async Task<bool> UploadMedia(IFormFile file, int mediaId)
        {
            if (file != null && file.Length > 0)
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
            return false;
        }
    }
}
