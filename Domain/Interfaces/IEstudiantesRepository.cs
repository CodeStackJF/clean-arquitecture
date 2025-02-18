using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEstudiantesRepository
    {
        Task<estudiantes> Get(int id);
        Task<List<estudiantes>> GetAll();
        Task<estudiantes> Save(estudiantes estudiante);
        Task Update(int id, estudiantes estudiante);
        Task<bool> Exists(int id);
    }
}