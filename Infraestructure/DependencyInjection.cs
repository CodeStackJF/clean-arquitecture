using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using Domain.Primitives;
using Domain.Interfaces;
using Infraestructure.Repositories;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistance(configuration);
            return services;
        }

        private static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("UniversidadCTX")));
            services.AddScoped<IApplicationDbContext>(x=>x.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IAsignaturasRepository, AsignaturasRepository>();
            services.AddScoped<ICarrerasRepository, CarrerasRepository>();
            services.AddScoped<IAsignaturasCarrerasRepository, AsignaturasCarrerasRepository>();
            services.AddScoped<IEstudiantesRepository, EstudiantesRepository>();
            return services;
        }
    }
}
