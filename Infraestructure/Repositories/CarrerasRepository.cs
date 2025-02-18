using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class CarrerasRepository : ICarrerasRepository
    {
        private readonly ApplicationDbContext ctx;

        public CarrerasRepository(ApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<bool> ExistsName(int id, string nombre)
        {
            return await ctx.carreras.AnyAsync(x=>x.id_carrera != id && x.nombre == nombre);
        }

        public async Task<carreras> Get(int id)
        {
            return (await ctx.carreras.Where(x=>x.id_carrera == id).FirstOrDefaultAsync())!;
        }

        public async Task<List<carreras>> GetAll()
        {
             return await ctx.carreras.ToListAsync();
        }

        public async Task<carreras> Save(carreras carrera)
        {
            await ctx.carreras.AddAsync(carrera);
            await ctx.SaveChangesAsync();
            return carrera;
        }

        public async Task Update(int id, carreras carrera)
        {
            ctx.carreras.Update(carrera);
            await ctx.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await ctx.carreras.AnyAsync(x=>x.id_carrera == id);
        }
    }
}