using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Configuration
{
    public class AsignaturasCarreraConfiguration : IEntityTypeConfiguration<asignaturas_carrera>
    {
        public void Configure(EntityTypeBuilder<asignaturas_carrera> builder)
        {
            builder.HasKey(x => new
            {
                x.carrera_id,
                x.asignatura_id
            });
            builder.HasOne(x=>x.carrera).WithMany().HasForeignKey(x=>x.carrera_id);
            builder.HasOne(x=>x.asignatura).WithMany().HasForeignKey(x=>x.asignatura_id);
        }
    }
}
