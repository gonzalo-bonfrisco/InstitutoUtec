using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WebApplicationInstituto.Dto
{
    public class ProblemDetail
    {
        public string Type { get; set; }

        public string Title { get; set; }

        public int? Status { get; set; }

        public string Detail { get; set; }

        public string Instance { get; set; }

        //[JsonExtensionData]
        //public IDictionary<string, object> Extensions { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }


    }
}
