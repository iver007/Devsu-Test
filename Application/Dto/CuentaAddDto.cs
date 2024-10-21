using Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CuentaAddDto
    {
        public string? TipoCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public Guid CodigoCliente { get; set; }
        public bool Estado { get; set; }
    }

    public class CuentaDtoValidator : AbstractValidator<CuentaAddDto>
    {
        public CuentaDtoValidator()
        {
            RuleFor(x => x.TipoCuenta)
                .Must(TipoCuenta => new[] { "Ahorro", "Corriente" }.Contains(TipoCuenta))
                .WithMessage("The TipoCuenta must be 'Ahorro' o 'Corriente'");
            RuleFor(x => x.SaldoInicial).NotNull().WithMessage("SaldoInicial is required")
                .GreaterThanOrEqualTo(0).WithMessage("The SaldoInicial must be greater or equal 0");
            RuleFor(x => x.CodigoCliente).NotNull().NotEmpty().WithMessage("CodigoCliente is required");
            RuleFor(x => x.Estado)
                .Must(Estado => new[] { true, false }.Contains(Estado))
                .WithMessage("The Estado must be 'true' o 'false'");
        }
    }
}
