using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization.Users;
using Abp.Domain.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.UI;
using netflix.Authorization.Roles;
using netflix.MultiTenancy;

namespace netflix.Authorization.Users
{
    public class UserRegistrationManager : DomainService
    {
        public IAbpSession AbpSession { get; set; }

        private readonly TenantManager _tenantManager;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserRegistrationManager(
            TenantManager tenantManager,
            UserManager userManager,
            RoleManager roleManager,
            IPasswordHasher<User> passwordHasher)
        {
            _tenantManager = tenantManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;

            AbpSession = NullAbpSession.Instance;
        }

        public async Task<User> RegisterAsync(string name, string surname, string emailAddress, string userName, string plainPassword, bool isEmailConfirmed)
        {
            //CheckForTenant();

            //var tenant = await GetActiveTenantAsync();

            var user = new User
            {
                TenantId = 7,
                Name = name,
                Surname = surname,
                EmailAddress = emailAddress,
                IsActive = true,
                UserName = userName,
                IsEmailConfirmed = isEmailConfirmed,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            var rs = await _roleManager.Roles.Where(r => r.NormalizedName=="NORMALUSER").FirstOrDefaultAsync();
            user.Roles.Add(new UserRole(7, user.Id, rs.Id));



            try
            {
                await _userManager.InitializeOptionsAsync(1);
                CheckErrors(await _userManager.CreateAsync(user, plainPassword));
                await CurrentUnitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
            return user;
        }

        //private void CheckForTenant()
        //{
        //    if (!AbpSession.TenantId.HasValue)
        //    {
        //        throw new InvalidOperationException("Can not register host users!");
        //    }
        //}

        private async Task<Tenant> GetActiveTenantAsync()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return await GetActiveTenantAsync(AbpSession.TenantId.Value);
        }

        private async Task<Tenant> GetActiveTenantAsync(int tenantId)
        {
            var tenant = await _tenantManager.FindByIdAsync(tenantId);
            if (tenant == null)
            {
                throw new UserFriendlyException(L("UnknownTenantId{0}", tenantId));
            }

            if (!tenant.IsActive)
            {
                throw new UserFriendlyException(L("TenantIdIsNotActive{0}", tenantId));
            }

            return tenant;
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
