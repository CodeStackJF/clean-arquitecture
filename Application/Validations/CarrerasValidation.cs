using Domain.Entities;
using FluentValidation;

namespace Application.Validations
{
    public class CarrerasValidation : AbstractValidator<carreras>
    {
        public CarrerasValidation()
        {
            RuleFor(x=>x.nombre).NotEmpty().WithMessage("El nombre no debe estar vacío.");
            RuleFor(x => x.nombre).MaximumLength(50).WithMessage("El nombre debe ser menor a 50 caracteres.");
        }
    }
}