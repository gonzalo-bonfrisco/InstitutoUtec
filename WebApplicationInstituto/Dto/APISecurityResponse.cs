using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationInstituto.Dto
{
    public class APISecurityResponse
    {
        public string token { get; set; }
        public DateTime expireAt { get; set; }
    }
}
