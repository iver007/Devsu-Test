using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enumerator
{
    public enum Movimientos
    {
        Ingreso = 1,
        Egreso,
        Inicial,
    }

    public static class MovimientosExtension
    {
        public static string GetDisplayText(this Movimientos movimientos)
        {
            switch (movimientos)
            {
                case Movimientos.Ingreso:
                    return "Ingreso";

                case Movimientos.Egreso:
                    return "Egreso";

                case Movimientos.Inicial:
                    return "Inicial";
            }

            return movimientos.ToString();
        }
    }
}
