using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Clientes")]
    public class Cliente : Persona
    {
        public Guid Codigo { get; set; }
        public string? Contrasenia { get; set; }
        public bool Estado { get; set; }
    }
}
