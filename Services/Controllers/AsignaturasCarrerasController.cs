using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsignaturasCarrerasController : Controller
    {
        private readonly IAsignaturasCarrerasRepository asignaturasCarrerasRepository;
        private readonly ICarrerasRepository carrerasRepository;
        private readonly IAsignaturasRepository asignaturasRepository;

        public AsignaturasCarrerasController(IAsignaturasCarrerasRepository _asignaturasCarrerasRepository, IAsignaturasRepository _asignaturasRepository, ICarrerasRepository _carrerasRepository)
        {
            asignaturasCarrerasRepository = _asignaturasCarrerasRepository;
            asignaturasRepository = _asignaturasRepository;
            carrerasRepository = _carrerasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await asignaturasCarrerasRepository.GetAll());
        }

        [HttpGet("{carrera_id}/{asignatura_id}")]
        public async Task<IActionResult> Get(int carrera_id, int asignatura_id)
        {
            return Ok(await asignaturasCarrerasRepository.Get(carrera_id, asignatura_id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] asignaturas_carrera asignatura_carrera)
        {
            if(await asignaturasCarrerasRepository.Exists(asignatura_carrera.carrera_id, asignatura_carrera.asignatura_id))
            {
                throw new HttpRequestException("Ya existe la asignatura en la carrera.");
            }
            
            if(!await carrerasRepository.Exists(asignatura_carrera.carrera_id))
            {
                throw new HttpRequestException("La carrera no existe.");
            }

             if(!await asignaturasRepository.Exists(asignatura_carrera.asignatura_id))
            {
                throw new HttpRequestException("La asignatura no existe.");
            }

            await asignaturasCarrerasRepository.Save(asignatura_carrera);
            return Ok(await asignaturasCarrerasRepository.Get(asignatura_carrera.carrera_id, asignatura_carrera.asignatura_id));
        }
    }
}