using Abp.Application.Services;
using Microsoft.AspNetCore.Http;
using netflix.ApiMedia.Dto;
using netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.ApiGenre
{
    public interface IMediaAppService : IApplicationService
    {
        public Task<int> Add(Media media);
        public Task Update(Media media);
        public Task<List<Media>> GetAll();
        public Task<bool> UploadMedia(IFormFile file, int mediaId);
        public Task Delete(int mediaId);
        public Task<List<Media>> Search(MediaSearchDto search);
        public Task<SuggestVideoModel> GetSuggestMediaByProfileId(int profileId);
    }
}