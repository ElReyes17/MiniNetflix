using FluentValidation;
using MediatR;
using MiniNetflix.Core.Application.Common;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result<TResponse>
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            await next();
        }

        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validatorResult.IsValid)
        {
            return await next();
        }

       
        var errors = validatorResult.Errors
                .ConvertAll(validationFailure => Result<TResponse>
                .Failure(validationFailure.ErrorMessage));

        return (TResponse)(dynamic)errors;
    }
}
