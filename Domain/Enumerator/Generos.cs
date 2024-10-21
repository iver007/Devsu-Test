using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enumerator
{
    public enum Generos
    {
        Masculino = 1,
        Femenino,
    }

    public static class GenerosExtension
    {
        public static string GetDisplayText(this Generos generos)
        {
            switch (generos)
            {
                case Generos.Masculino:
                    return "Masculino";

                case Generos.Femenino:
                    return "Femenino";
            }

            return generos.ToString();
        }
    }
}
