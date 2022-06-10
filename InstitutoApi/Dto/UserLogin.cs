using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Dto
{
    public class UserLogin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <example>usuario</example>
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>123456</example>
        public string Password { get; set; }
    }
}
