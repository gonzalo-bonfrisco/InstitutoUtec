using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Services.Seguridad
{
    public interface IAuthService
    {
        public bool ValidateLogin(string username, string password);
        string GenerateToken(DateTime fechaActual, string username, TimeSpan tiempoValidez);
    }
}
