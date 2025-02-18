using Application.Data;
using Domain.Entities;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<asignaturas> asignaturas { get; set; }
        public DbSet<carreras> carreras { get; set; }
        public DbSet<asignaturas_carrera> asignaturas_carrera { get; set; }
        public DbSet<estudiantes> estudiantes { get; set; }
    }
}
