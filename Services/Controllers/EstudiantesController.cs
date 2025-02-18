using Application.Exceptions;
using Application.Validations;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudiantesController : Controller
    {
        private readonly IEstudiantesRepository estudiantesRepository;

        public EstudiantesController(IEstudiantesRepository _estudiantesRepository)
        {
            estudiantesRepository = _estudiantesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] estudiantes estudiante)
        {
            var validator = await new EstudiantesValidation().ValidateAsync(estudiante);
            if(!validator.IsValid)
            {
                throw new CustomValidationException(validator.Errors);
            }

            estudiante = await estudiantesRepository.Save(estudiante);
            return Ok(estudiante);
        }
    }
}