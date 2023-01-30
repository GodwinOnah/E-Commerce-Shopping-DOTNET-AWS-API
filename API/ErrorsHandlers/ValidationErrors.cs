using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ErrorsHandlers
{
    public class ValidationErrors : Responses
    {

        public IEnumerable<string> Errors { get;set; }
        public ValidationErrors() : base(400)
        {
        }
    }
}