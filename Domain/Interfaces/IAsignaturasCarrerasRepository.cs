using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAsignaturasCarrerasRepository
    {
         Task<asignaturas_carrera> Get(int carrera_id, int asignatura_id);

        Task<List<asignaturas_carrera>> GetAll();

        Task<asignaturas_carrera> Save(asignaturas_carrera data);
        Task Delete(int carrera_id, int asignatura_id);
        Task<bool> Exists(int carrera_id, int asignatura_id);
    }
}