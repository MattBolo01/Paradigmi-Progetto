using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paradigmi.Lib.Repository.Abstraction;
using Paradigmi.Lib.Repository;
using Paradigmi.Lib.Contesto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.Models.Estensioni
{
    /// <summary>
    /// Classe per la registrazione di servizi e dipendenze
    /// </summary>
    public static class EstensioneService
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            services.AddScoped<IUtente, UtenteRepository>();
            services.AddScoped<ILibro, LibroRepository>();
            services.AddScoped<ICategoria, CategoriaRepository>();

            return services;
        }
    }
}
