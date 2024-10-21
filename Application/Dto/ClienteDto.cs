using Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ClienteDto
    {
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public int Edad { get; set; }
        public string? Identificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Contrasenia { get; set; }
        public bool Estado { get; set; }
    }

    public class ClienteDtoValidator : AbstractValidator<ClienteDto>
    {
        public ClienteDtoValidator()
        {
            RuleFor(x => x.Nombre).NotNull().NotEmpty().WithMessage("Nombre is required")
                .MaximumLength(30).WithMessage("The Nombre length must not be more than 30 characters");
            RuleFor(x => x.Genero)
                .Must(Genero => new[] { "Masculino", "Femenino" }.Contains(Genero))
                .WithMessage("The genero must be 'Masculino' o 'Femenino'");
            RuleFor(x => x.Edad).NotNull().WithMessage("Edad is required")
                .GreaterThan(0).WithMessage("The Edad must be greater than 0");
            RuleFor(x => x.Identificacion).NotNull().NotEmpty().WithMessage("Identificacion is required")
                .MaximumLength(10).WithMessage("The Identificacion length must not be more than 10 characters");
            RuleFor(x => x.Estado)
                .Must(Estado => new[] { true, false }.Contains(Estado))
                .WithMessage("The Estado must be 'true' o 'false'");
            RuleFor(user => user.Contrasenia)
                .NotEmpty().WithMessage("contrasenia is required")
                .MinimumLength(4).WithMessage("contrasenia must be at least 4 characters long");
        }
    }
}
