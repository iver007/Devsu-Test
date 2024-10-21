using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enumerator
{
    public enum StoreProcedures
    {
        sp_GetEstadoCuenta = 1,
    }

    public static class StoreProceduresExtension
    {
        public static string GetDisplayText(this StoreProcedures storeProcedures)
        {
            switch (storeProcedures)
            {
                case StoreProcedures.sp_GetEstadoCuenta:
                    return "sp_GetEstadoCuenta";
            }

            return storeProcedures.ToString();
        }
    }
}
