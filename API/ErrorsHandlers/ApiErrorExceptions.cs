using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ErrorsHandlers
{
    public class ApiErrorExceptions : Responses

    {
         public string ErrorDetails { get;set; }
        public ApiErrorExceptions(int statusCode, string message = null, string  errorDetails=null) : base(statusCode, message)
        {
            ErrorDetails=errorDetails;
        }

       
    }
}