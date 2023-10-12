namespace API.ErrorsHandlers
{
    public class Responses
    {
        public int StatusCode { get;set; }
         public string Message { get;set; }
        public Responses(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message=message??GeatMessages(statusCode);
            
        }

        private string GeatMessages(int statusCode)
        {
            return statusCode switch{

                400=>"Sorry Dear..You have mad a bad request.",
                 401=>"Sorry Dear..You are not authorized.",
                  404=>"Sorry Dear..No resource found.",
                   500=>"Sorry ear..Lots of Errors made.",
                   _=>null
            };
        }
    }
}