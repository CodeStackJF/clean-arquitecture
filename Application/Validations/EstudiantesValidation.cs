using System.IO.Compression;
using Domain.Entities;
using FluentValidation;

namespace Application.Validations
{
    public class EstudiantesValidation : AbstractValidator<estudiantes>
    {
        public EstudiantesValidation()
        {
            RuleFor(x=>x.nombre).NotNull().NotEmpty().WithMessage("Ingrese el nombre.");
            RuleFor(x=>x.apellido).NotNull().NotEmpty().WithMessage("Ingrese el apellido.");
            //RuleFor(x=>x.nombre).MinimumLength(3).WithMessage("Ingrese al menos 3 caracteres.");
            RuleFor(x=>x.direccion).MinimumLength(3).WithMessage("Ingrese al menos 3 caracteres.");
            RuleFor(x=>x.direccion).NotEmpty().WithMessage("Ingrese la dirección.");
        }
    }
}