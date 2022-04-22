using Instituto.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto
{
    public class Application
    {
        public IServiceProvider Services { get; set; }
        public ILogger Logger { get; set; }


        public Application(IServiceCollection serviceCollection)
        {
            ConfigureServices(serviceCollection);

            Services = serviceCollection.BuildServiceProvider();

            Logger = Services.GetRequiredService<ILoggerFactory>()
                    .CreateLogger<Application>();
   

            Logger.LogInformation("Application created successfully.");
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IPaymentService, PaymentService>();
        }

        public void MakePayment(string paymentDetails)
        {
            Logger.LogInformation(
              $"Begin making a payment { paymentDetails }");
            IPaymentService paymentService =
              Services.GetRequiredService<IPaymentService>();

            Logger.LogInformation(paymentService.Hola());
            // ...
        }
    }
}
