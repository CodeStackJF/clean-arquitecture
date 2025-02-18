using Domain.Entities;
using Domain.Interfaces;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    internal class AsignaturasRepository : IAsignaturasRepository
    {
        private readonly ApplicationDbContext ctx;

        public AsignaturasRepository(ApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<asignaturas> Get(int id)
        {
            return (await ctx.asignaturas.Where(x=>x.id_asignatura == id).FirstOrDefaultAsync())!;
        }

        public async Task<List<asignaturas>> GetAll()
        {
            return await ctx.asignaturas.ToListAsync();
        }

        public async Task<asignaturas> Save(asignaturas asignatura)
        {
            await ctx.asignaturas.AddAsync(asignatura);
            await ctx.SaveChangesAsync();
            return asignatura;
        }

        public async Task Update(int id, asignaturas asignatura)
        {
            ctx.asignaturas.Update(asignatura);
            await ctx.SaveChangesAsync();
        }

        public async Task<bool> ExistsName(int id, string nombre)
        {
            return await ctx.asignaturas.AnyAsync(x => x.nombre == nombre && x.id_asignatura != id);
        }

        public async Task Delete(int id)
        {
            var result = await ctx.asignaturas.FindAsync(id);
            ctx.asignaturas.Remove(result!);
            await ctx.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await ctx.asignaturas.AnyAsync(x => x.id_asignatura == id);
        }
    }
}
