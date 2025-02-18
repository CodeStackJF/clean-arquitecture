using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class AsignaturasValidation : AbstractValidator<asignaturas>
    {
        public AsignaturasValidation()
        {
            RuleFor(x => x.nombre).NotEmpty().NotNull().WithMessage("El nombre no puede estar vacío.");
            RuleFor(x => x.nombre).MaximumLength(50).WithMessage("El nombre debe ser menor a 50 caracteres.");
        }
    }
}
