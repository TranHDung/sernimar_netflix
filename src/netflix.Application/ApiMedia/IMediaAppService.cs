using Abp.Application.Services;
using Microsoft.AspNetCore.Http;
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
        public Task<int> Add(Media genre);
        public Task<List<Media>> GetAll();
        public Task<bool> UploadMedia(IFormFile file, int mediaId);
        public Task DeleteMedia(int mediaId);
    }
}
