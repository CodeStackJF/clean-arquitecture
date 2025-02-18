using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configuration
{
    public class EstudiantesConfiguration : IEntityTypeConfiguration<estudiantes>
    {
        public void Configure(EntityTypeBuilder<estudiantes> builder)
        {
            builder.HasKey(x=>x.id_estudiante);
        }

    }
}