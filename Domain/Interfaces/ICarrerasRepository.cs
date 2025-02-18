using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICarrerasRepository
    {
        Task<carreras> Get(int id);

        Task<List<carreras>> GetAll();

        Task<carreras> Save(carreras carrera);

        Task Update(int id, carreras carrera);
        Task<bool> ExistsName(int id, string nombre);
        Task<bool> Exists(int id);
    }
}
