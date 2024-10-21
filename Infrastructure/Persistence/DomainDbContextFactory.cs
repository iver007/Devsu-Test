using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain.Interface.Persistence;

namespace Infrastructure.Persistence
{
    public class DomainDbContextFactory : IDomainDbContextFactory, IDesignTimeDbContextFactory<DomainDbContext>
    {
       
        private readonly IDbContextFactory<DomainDbContext> poolFactory;
     //   private readonly string plantDbConnectionString;

        /// <summary>
        /// DO NOT USE
        /// </summary>
        public DomainDbContextFactory()
        {

            var builder = new DbContextOptionsBuilder<DomainDbContext>();
            builder.EnableSensitiveDataLogging(true);
            builder.UseSqlServer("Server=LAPTOP-7VP6P023\\MSSQLSERVER2019;Database=Db11;Integrated Security=True;Encrypt=False",
                optionBuilder =>
                {
                    optionBuilder.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                })
                .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.RelationalBaseId + 500));

            this.poolFactory = new PooledDbContextFactory<DomainDbContext>(builder.Options);
        }


        public async Task<IDomainDbContext> Create(string? databaseName)
        {
            try
            {
                var context = this.poolFactory.CreateDbContext();
                context.Database.CloseConnection();
                context.Database.SetConnectionString("Server=LAPTOP-7VP6P023\\MSSQLSERVER2019;Database=Db11;Integrated Security=True;Encrypt=False");
                return context;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// DO NOT USE
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [Obsolete]
        public DomainDbContext CreateDbContext(string[] args)
        {
            var connectionString = default(string);
            connectionString = "Server=LAPTOP-7VP6P023\\MSSQLSERVER2019;Database=Db11;Integrated Security=True;Encrypt=False";
            var builder = new DbContextOptionsBuilder<DomainDbContext>();
            builder.UseSqlServer(connectionString).ConfigureWarnings(warnings => warnings.Throw(CoreEventId.RelationalBaseId + 500));

            var context = new DomainDbContext(builder.Options);
            return context;
        }
    }
}
