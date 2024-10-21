using Domain.Interface.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class SProcExtension
    {
        public static DbConnection LoadConnection(this IDomainDbContext context)
        {
            var conn = context.Database.GetDbConnection();
            return conn;
        }
    }
}
