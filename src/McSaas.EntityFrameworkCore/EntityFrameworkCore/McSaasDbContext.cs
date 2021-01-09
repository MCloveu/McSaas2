using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using McSaas.Authorization.Roles;
using McSaas.Authorization.Users;
using McSaas.MultiTenancy;
using McSaas.Communitys;
using McSaas.Houses;
using McSaas.Owners;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System;
using Abp.Domain.Entities;
using System.Reflection;
using McSaas.Core.Buildings;

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
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Building> Building { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////自动创建数据库表Person
            //modelBuilder.Entity<Community>().ToTable("Community", "dbo");
            //modelBuilder.Entity<House>().ToTable("House", "dbo");
            //modelBuilder.Entity<Owner>().ToTable("Owner", "dbo");
            //base.OnModelCreating(modelBuilder);
            // DbContext 模型创建的时候
            base.OnModelCreating(modelBuilder);

            // 遍历所有 DbContext 定义的实体
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                ConfigureGlobalFiltersMethodInfo
                    .MakeGenericMethod(entityType.ClrType)
                    .Invoke(this, new object[] { modelBuilder, entityType
            });
            }
        }
        private static MethodInfo ConfigureGlobalFiltersMethodInfo = typeof(McSaasDbContext).GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);

        protected void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType)
                where TEntity : class
        {
            // 判断实体是否实现了租户或者软删除接口，实现了则添加一个过滤器
            if (entityType.BaseType == null && ShouldFilterEntity<TEntity>(entityType))
            {
                var filterExpression = CreateFilterExpression<TEntity>();
                if (filterExpression != null)
                {
                    modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
                }
            }
        }

        // 数据过滤用的查询表达式构建
        protected virtual Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
            where TEntity : class
        {
            Expression<Func<TEntity, bool>> expression = null;

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                /* This condition should normally be defined as below:
                    * !IsSoftDeleteFilterEnabled || !((ISoftDelete) e).IsDeleted
                    * But this causes a problem with EF Core (see https://github.com/aspnet/EntityFrameworkCore/issues/9502)
                    * So, we made a workaround to make it working. It works same as above.
                    */
                Expression<Func<TEntity, bool>> softDeleteFilter = e => !((ISoftDelete)e).IsDeleted || ((ISoftDelete)e).IsDeleted != IsSoftDeleteFilterEnabled;
                expression = expression == null ? softDeleteFilter : CombineExpressions(expression, softDeleteFilter);
            }

            if (typeof(IMayHaveTenant).IsAssignableFrom(typeof(TEntity)))
            {
                /* This condition should normally be defined as below:
                    * !IsMayHaveTenantFilterEnabled || ((IMayHaveTenant)e).TenantId == CurrentTenantId
                    * But this causes a problem with EF Core (see https://github.com/aspnet/EntityFrameworkCore/issues/9502)
                    * So, we made a workaround to make it working. It works same as above.
                    */
                Expression<Func<TEntity, bool>> mayHaveTenantFilter = e => ((IMayHaveTenant)e).TenantId == CurrentTenantId || (((IMayHaveTenant)e).TenantId == CurrentTenantId) == IsMayHaveTenantFilterEnabled;
                expression = expression == null ? mayHaveTenantFilter : CombineExpressions(expression, mayHaveTenantFilter);
            }

            if (typeof(IMustHaveTenant).IsAssignableFrom(typeof(TEntity)))
            {
                /* This condition should normally be defined as below:
                    * !IsMustHaveTenantFilterEnabled || ((IMustHaveTenant)e).TenantId == CurrentTenantId
                    * But this causes a problem with EF Core (see https://github.com/aspnet/EntityFrameworkCore/issues/9502)
                    * So, we made a workaround to make it working. It works same as above.
                    */
                Expression<Func<TEntity, bool>> mustHaveTenantFilter = e => ((IMustHaveTenant)e).TenantId == CurrentTenantId || (((IMustHaveTenant)e).TenantId == CurrentTenantId) == IsMustHaveTenantFilterEnabled;
                expression = expression == null ? mustHaveTenantFilter : CombineExpressions(expression, mustHaveTenantFilter);
            }

            return expression;
        }
    }
}
