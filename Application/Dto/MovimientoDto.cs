using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class MovimientoDto
    {
        public string? NumeroCuenta { get; set; }
        public double Valor { get; set; }
    }

    public class MovimientoDtoValidator : AbstractValidator<MovimientoDto>
    {
        public MovimientoDtoValidator()
        {
            RuleFor(x => x.NumeroCuenta).NotNull().NotEmpty().WithMessage("NumeroCuenta is required");
            RuleFor(x => x.Valor).NotNull().WithMessage("Valor is required")
                .Must(p => p != 0).WithMessage("Valor must be non-zero")
                .Must(BeValidDouble).WithMessage("Valor must have a maximum of 2 decimal places");
        }
        private bool BeValidDouble(double price)
        {
            return price.ToString("F2").Split('.')[1].Length <= 2;
        }
    }
}
