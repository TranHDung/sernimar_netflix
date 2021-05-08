using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using netflix.Authorization.Roles;
using netflix.Authorization.Users;
using netflix.MultiTenancy;

namespace netflix.EntityFrameworkCore
{
    public class netflixDbContext : AbpZeroDbContext<Tenant, Role, User, netflixDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public netflixDbContext(DbContextOptions<netflixDbContext> options)
            : base(options)
        {
        }
    }
}
