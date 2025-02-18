using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Configuration
{
    internal class CarrerasConfiguration : IEntityTypeConfiguration<carreras>
    {
        public void Configure(EntityTypeBuilder<carreras> builder)
        {
            builder.HasKey(x => x.id_carrera);
        }
    }
}
