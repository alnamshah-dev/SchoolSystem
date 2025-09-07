using FluentValidation;
using MediatR;

namespace SchoolSystem.Application.Abstracts.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var ValidationResult =
                await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));
            var Failures =
                ValidationResult
                .Where(x => x.Errors.Any())
                .SelectMany(x => x.Errors)
                .ToList();
            if (Failures.Any())
                throw new ValidationException(Failures);
            return await next();
        }
    }
}
