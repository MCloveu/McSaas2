using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using McSaas.Authorization.Roles;
using McSaas.Authorization.Users;
using McSaas.MultiTenancy;
using McSaas.Communitys;
using McSaas.Houses;
using McSaas.Sesidents;

namespace McSaas.EntityFrameworkCore
{
    public class McSaasDbContext : AbpZeroDbContext<Tenant, Role, User, McSaasDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public McSaasDbContext(DbContextOptions<McSaasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Community> Community { get; set; }
        public DbSet<House> House { get; set; }
        public DbSet<Resident> Resident { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //自动创建数据库表Person
            modelBuilder.Entity<Community>().ToTable("Community", "dbo");
            modelBuilder.Entity<House>().ToTable("House", "dbo");
            modelBuilder.Entity<Resident>().ToTable("Resident", "dbo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
