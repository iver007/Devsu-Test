using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ReporteDto
    {
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public Guid CodigoCliente { get; set; }
    }

    public class ReporteDtoValidator : AbstractValidator<ReporteDto>
    {
        public ReporteDtoValidator()
        {
            RuleFor(x => x.FechaInicio).NotEmpty().WithMessage("FechaInicio is required")
            .Must(BeValidDate).WithMessage("FechaInicio must be in yyyy-MM-dd format and be a valid date");
            RuleFor(x => x.FechaFin).NotEmpty().WithMessage("FechaInicio is required")
            .Must(BeValidDate).WithMessage("FechaInicio must be in yyyy-MM-dd format and be a valid date");
        }
        private bool BeValidDate(string date)
        {
            return DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}
