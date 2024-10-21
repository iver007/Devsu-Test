using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ApiResponse
    {
        public bool IsFailed { get; set; }

        public object? Data { get; set; }

        public string Message { get; set; }
    }
}
