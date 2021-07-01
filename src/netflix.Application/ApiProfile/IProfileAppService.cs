using Abp.Application.Services;
using netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.ApiGenre
{
    public interface IProfileAppService : IApplicationService
    {
        public Task<Profile> Add(Profile profile);
        public Task<List<Profile>> GetProfilesByUserId(int userId);
        public Task Remove(int profileId);
        public Task Update(Profile profile);
        public List<Profile> GetAll();
    }
}
