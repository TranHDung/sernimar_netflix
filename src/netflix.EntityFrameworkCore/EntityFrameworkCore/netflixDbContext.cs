using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using netflix.Authorization.Roles;
using netflix.Authorization.Users;
using netflix.MultiTenancy;
using netflix.Entities;

namespace netflix.EntityFrameworkCore
{
    public class netflixDbContext : AbpZeroDbContext<Tenant, Role, User, netflixDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionType> ActionTypes { get; set; }
        public virtual DbSet<Media> Medias { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public netflixDbContext(DbContextOptions<netflixDbContext> options)
            : base(options)
        {
        }
    }
}
