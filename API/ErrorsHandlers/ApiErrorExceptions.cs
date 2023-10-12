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