using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enumerator
{
    public enum Cuentas
    {
        Ahorro = 1,
        Corriente,
    }

    public static class CuentasExtension
    {
        public static string GetDisplayText(this Cuentas cuentas)
        {
            switch (cuentas)
            {
                case Cuentas.Ahorro:
                    return "Ahorro";

                case Cuentas.Corriente:
                    return "Corriente";
            }

            return cuentas.ToString();
        }
    }
}
