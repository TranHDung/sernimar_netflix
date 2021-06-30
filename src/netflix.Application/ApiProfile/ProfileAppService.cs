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

        public async Task<Profile> Add(Profile profile)
        {
            profile.CreatedDate = DateTime.Now;
            var id = await _profileRepository.InsertAndGetIdAsync(profile);
            return await _profileRepository.GetAsync(id);
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
