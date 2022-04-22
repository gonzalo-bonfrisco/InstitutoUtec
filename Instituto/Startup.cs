using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto
{
    class Startup
    {
        private IApplication application;

        public Startup(IApplication application)
        {
            this.application = application;

        }

        public void IniciarApp()
        {
            this.application.Inicio();
        }

    }
}
