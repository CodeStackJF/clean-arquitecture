using Application.Exceptions;
using Application.Validations;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsignaturasController : Controller
    {
        private readonly IAsignaturasRepository _asignaturasRepository;

        public AsignaturasController(IAsignaturasRepository asignaturasRepository)
        {
            _asignaturasRepository = asignaturasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _asignaturasRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _asignaturasRepository.Get(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] asignaturas asignatura)
        {
            if (id != asignatura.id_asignatura)
            {
                throw new HttpRequestException("Existe un error en la petición.");
            }

            var validator = new AsignaturasValidation().Validate(asignatura);
            if (!validator.IsValid)
            {
                throw new CustomValidationException(validator.Errors);
            }

            if (await _asignaturasRepository.ExistsName(asignatura.id_asignatura, asignatura.nombre))
            {
                throw new CustomValidationException("nombre", "Ya existe una materia con este nombre.");
            }

            await _asignaturasRepository.Update(id, asignatura);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] asignaturas asignatura)
        {
            var validator = new AsignaturasValidation().Validate(asignatura);
            if (!validator.IsValid)
            {
                throw new CustomValidationException(validator.Errors);
            }
            if (await _asignaturasRepository.ExistsName(asignatura.id_asignatura, asignatura.nombre))
            {
                throw new CustomValidationException("nombre", "Ya existe una materia con este nombre.");
            }
            asignatura = await _asignaturasRepository.Save(asignatura);
            return Created("", asignatura);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _asignaturasRepository.Exists(id))
            {
                return NotFound();
            }
            await _asignaturasRepository.Delete(id);
            return NoContent();
        }
    }
}
