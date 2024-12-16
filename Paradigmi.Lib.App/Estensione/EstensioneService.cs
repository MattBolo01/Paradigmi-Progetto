using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paradigmi.Lib.App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Estensione
{
    public static class EstensioneService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == "Paradigmi.Lib.App"));// Indico dove trovare i validatori tramite l'assembly
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            return services;
        }
    }
}
