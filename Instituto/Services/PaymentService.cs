using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto.Services
{
    public class PaymentService : IPaymentService
    {
        public ILogger Logger { get; }

        public PaymentService(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory?.CreateLogger<PaymentService>();

            if (Logger == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            Logger.LogInformation("PaymentService created");
        }

        public string Hola()
        {
            return "Hello kitty";
        }
    }
}
