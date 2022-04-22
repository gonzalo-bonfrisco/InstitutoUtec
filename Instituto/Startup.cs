using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto
{
    public class Startup
    {
        private readonly ILogger<Startup> logger;

        public Startup(
            ILogger<Startup> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task RunAsync()
        {
            this.logger.LogInformation($"Startup running...");
            // Do Stuff...
        }
    }
}
