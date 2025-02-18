namespace Domain.Interfaces;
using Domain.Entities;
using System.Collections.Generic;

public interface IAsignaturasRepository
{
    Task<asignaturas> Get(int id);

    Task<List<asignaturas>> GetAll();

    Task<asignaturas> Save(asignaturas asignatura);

    Task Update(int id, asignaturas asignatura);
    Task<bool> ExistsName(int id, string nombre);
    Task Delete(int id);
    Task<bool> Exists(int id);
}