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
    public class AsignaturasConfiguration : IEntityTypeConfiguration<asignaturas>
    {
        public void Configure(EntityTypeBuilder<asignaturas> builder)
        {
            builder.HasKey(x => x.id_asignatura);
        }
    }
}
