using Domain.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Cuentas")]
    public class Cuenta
    {
        [Key]
        public string NumeroCuenta { get; set; }
        public Cuentas TipoCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public double SaldoActual { get; set; }
        public bool Estado { get; set; }
        public int ClientesId { get; set; }
        public Cliente Clientes { get; set; }
    }
}
