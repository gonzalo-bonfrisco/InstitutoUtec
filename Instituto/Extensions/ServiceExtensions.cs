using Instituto.Providers;
using Instituto.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureAppServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IXMLProvider, XMLProvider>();
            serviceCollection.AddScoped<INpgSqlProvider, NpgSqlProvider>();

            serviceCollection.AddScoped<IAlumnoService, AlumnoServiceXML>();
            serviceCollection.AddScoped<IMateriaService, MateriaServiceXML>();

            serviceCollection.AddScoped<IGetMateriaService, GetMateriaService>();
            serviceCollection.AddScoped<IGetAlumnoService, GetAlumnoNpgService /*GetAlumnosService*/>();

            return serviceCollection;
        }
    }
}
