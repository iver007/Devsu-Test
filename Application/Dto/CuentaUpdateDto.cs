using Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CuentaUpdateDto
    {
        public string? TipoCuenta { get; set; }
        public bool Estado { get; set; }
    }

    public class CuentaUpdateDtoValidator : AbstractValidator<CuentaUpdateDto>
    {
        public CuentaUpdateDtoValidator()
        {
            RuleFor(x => x.TipoCuenta)
                .Must(TipoCuenta => new[] { "Ahorro", "Corriente" }.Contains(TipoCuenta))
                .WithMessage("The TipoCuenta must be 'Ahorro' o 'Corriente'");
            RuleFor(x => x.Estado)
                .Must(Estado => new[] { true, false }.Contains(Estado))
                .WithMessage("The Estado must be 'true' o 'false'");
        }
    }
}
