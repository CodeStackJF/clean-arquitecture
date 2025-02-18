using Application.Exceptions;
using Application.Validations;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrerasController : Controller
    {
        private readonly ICarrerasRepository carrerasRepository;
        public CarrerasController(ICarrerasRepository _carrerasRepository)
        {
            carrerasRepository = _carrerasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await carrerasRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await carrerasRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] carreras carrera)
        {
            var validator = new CarrerasValidation().Validate(carrera);
            if(!validator.IsValid)
            {
                throw new CustomValidationException(validator.Errors);
            }

            if(await carrerasRepository.ExistsName(carrera.id_carrera, carrera.nombre))
            {
                throw new CustomValidationException("nombre", "Ya existe una carrera con este nombre.");
            }

            carrera = await carrerasRepository.Save(carrera);
            return Ok(carrera);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] carreras carrera)
        {
            if(id != carrera.id_carrera)
            {
                throw new HttpRequestException("Hay un error en la petición.");
            }

            var validator = new CarrerasValidation().Validate(carrera);
            if(!validator.IsValid)
            {
                throw new CustomValidationException(validator.Errors);
            }

            if(await carrerasRepository.ExistsName(carrera.id_carrera, carrera.nombre))
            {
                throw new CustomValidationException("nombre", "Ya existe una carrera con este nombre.");
            }
            await carrerasRepository.Update(id, carrera);
            return NoContent();
        }
    }
}