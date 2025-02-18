using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class AsignaturasCarrerasRepository : IAsignaturasCarrerasRepository
    {
        private readonly ApplicationDbContext ctx;

        public AsignaturasCarrerasRepository(ApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task Delete(int carrera_id, int asignatura_id)
        {
            var result = ctx.asignaturas_carrera.Where(x=>x.carrera_id == carrera_id && x.asignatura_id == asignatura_id).FirstOrDefault();
            ctx.Remove(result!);
            await ctx.SaveChangesAsync();
        }

        public async Task<bool> Exists(int carrera_id, int asignatura_id)
        {
            return await ctx.asignaturas_carrera.AnyAsync(x=>x.asignatura_id == asignatura_id && x.carrera_id == carrera_id);
        }

        public async Task<asignaturas_carrera> Get(int carrera_id, int asignatura_id)
        {
            return (await ctx.asignaturas_carrera.Include(x=>x.carrera).Include(x=>x.asignatura).Where(x=>x.asignatura_id == asignatura_id && x.carrera_id == carrera_id).FirstOrDefaultAsync())!;
        }

        public async Task<List<asignaturas_carrera>> GetAll()
        {
            return await ctx.asignaturas_carrera.Include(x=>x.carrera).Include(x=>x.asignatura).ToListAsync()!;
        }

        public async Task<asignaturas_carrera> Save(asignaturas_carrera data)
        {
            ctx.asignaturas_carrera.Add(data);
            await ctx.SaveChangesAsync();
            return data;
        }

    }
}