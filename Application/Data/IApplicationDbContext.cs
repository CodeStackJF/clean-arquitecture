using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<asignaturas> asignaturas { get; set; }
        DbSet<carreras> carreras { get; set; }
        DbSet<asignaturas_carrera> asignaturas_carrera { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
