using Genix.Core;
using Genix.Data.Infrastructure;
using Genix.Data.Mapping.Catalog;
using Genix.Data.Mapping.Common;
using Genix.Data.Mapping.Customers;
using Genix.Data.Mapping.Directory;
using Genix.Data.Mapping.Media;
using Genix.Data.Mapping.Orders;
using Genix.Data.Mapping.Shipping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Genix.Services
{
    public class ObjectContext : DbContext, IDbContext
    {
        public ObjectContext(DbContextOptions<ObjectContext> options) : base(options)
        {
            Database.SetCommandTimeout(60);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CustomerCustomerRoleMap());
            modelBuilder.ApplyConfiguration(new CustomerAddressMap());
            modelBuilder.ApplyConfiguration(new CustomerPasswordMap());
            modelBuilder.ApplyConfiguration(new CustomerRoleMap());

            modelBuilder.ApplyConfiguration(new AddressMap());

            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductCategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductPictureMap());

            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new StateProvinceMap());

            modelBuilder.ApplyConfiguration(new PictureMap());
            modelBuilder.ApplyConfiguration(new PictureBinaryMap());

            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new ShoppingCartItemMap());

            modelBuilder.ApplyConfiguration(new DeliveryDateMap());
            modelBuilder.ApplyConfiguration(new ShipmentMap());
            modelBuilder.ApplyConfiguration(new ShipmentItemMap());
            modelBuilder.ApplyConfiguration(new ShippingMethodMap());


            base.OnModelCreating(modelBuilder);
        }

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }


        public void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity
        {
            return Set<TEntity>().FromSqlRaw(CreateSqlWithParameters(sql, parameters), parameters);
        }

        protected virtual string CreateSqlWithParameters(string sql, params object[] parameters)
        {
            for (int i = 0; i <= (parameters?.Length ?? 0) - 1; i++)
            {
                if (!(parameters[i] is DbParameter parameter))
                    continue;

                sql = $"{sql}{(i > 0 ? "," : string.Empty)} @{parameter.ParameterName}";

                if (parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Output)
                    sql = $"{sql} output";
            }
            return sql;
        }

        [Obsolete]
        public int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            using var transaction = Database.BeginTransaction();
            return Database.ExecuteSqlCommand(sql, parameters);
        }

        [Obsolete]
        public IQueryable<TQuery> QueryFromSql<TQuery>(string sql, params object[] parameters) where TQuery : class
        {
            return Query<TQuery>().FromSqlRaw(CreateSqlWithParameters(sql, parameters), parameters);
        }
    }
}
