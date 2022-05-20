using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationInstituto.Dto
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }

        public ProblemDetail problemDetail { get; set; }

        public OperationResult()
        {
            IsSuccess = true;
        }

    }
}
