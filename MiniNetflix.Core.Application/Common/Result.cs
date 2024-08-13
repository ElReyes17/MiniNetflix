

namespace MiniNetflix.Core.Application.Common
{
    //Implementación de Result Pattern
    public class Result<T>
    {
        private Result(T value, bool isSuccess, string errorMessage)
        {
            Value = value;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;

        }

        public T Value { get;  }

        public bool IsSuccess { get; }

        public string? ErrorMessage { get; }

        public static Result<T> Success(T value) =>  new (value, true, "");

        public static Result<T> Failure(string errorMessage) => new(default!, false, errorMessage);
    }
}
