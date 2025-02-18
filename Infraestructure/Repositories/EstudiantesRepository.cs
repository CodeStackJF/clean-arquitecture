using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class EstudiantesRepository : IEstudiantesRepository
    {
        private readonly ApplicationDbContext ctx;

        public EstudiantesRepository(ApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<bool> Exists(int id)
        {
            return await ctx.estudiantes.AnyAsync(x=>x.id_estudiante == id);
        }

        public async Task<estudiantes> Get(int id)
        {
            return (await ctx.estudiantes.FindAsync(id))!;
        }

        public async Task<List<estudiantes>> GetAll()
        {
            return await ctx.estudiantes.ToListAsync();
        }

        public async Task<estudiantes> Save(estudiantes estudiante)
        {
            ctx.estudiantes.Add(estudiante);
            await ctx.SaveChangesAsync();
            return estudiante;
        }

        public async Task Update(int id, estudiantes estudiante)
        {
            ctx.estudiantes.Update(estudiante);
            await ctx.SaveChangesAsync();
        }

    }
}