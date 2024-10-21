using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Persistence
{
    public interface IDomainDbContextFactory
    {
        Task<IDomainDbContext> Create(string? databaseName);
    }
}
