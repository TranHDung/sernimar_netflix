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
    public class ProfileAppService : ApplicationService, IProfileAppService
    {
        private readonly IRepository<Profile> _profileRepository;
        public ProfileAppService(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task Add(Profile profile)
        {
            profile.CreatedDate = DateTime.Now;
            await _profileRepository.InsertAsync(profile);
        }

        public List<Profile> GetAll()
        {
            return _profileRepository.GetAll().ToList();
        }

        public async Task Remove(int profileId)
        {
            var entity = await _profileRepository.FirstOrDefaultAsync(p => p.Id == profileId);
            await _profileRepository.UpdateAsync(entity);
        }

        public async Task Update(Profile profile)
        {
            await _profileRepository.UpdateAsync(profile);
        }
    }
}
