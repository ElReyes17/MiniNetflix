
namespace MiniNetflix.Core.Application.Exceptions
{
    public class ApiException: Exception 
    {
        public ApiException(string message, int errorCode) : base(message) 
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; }
    }
    
    
}
