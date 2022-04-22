﻿using Instituto.Services;
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
            serviceCollection.AddScoped<IAlumnoService, AlumnoService>();
            // serviceCollection.AddSingleton<IPaymentService, PaymentService>();

            return serviceCollection;
        }
    }
}