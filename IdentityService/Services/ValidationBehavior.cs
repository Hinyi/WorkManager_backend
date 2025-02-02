using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IdentityService.Services;

public class ValidationBehavior<TRequest, TRespone> : IPipelineBehavior<TRequest, TRespone>
    where TRequest : IRequest<TRespone>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger<ValidationBehavior<TRequest, TRespone>> _logger;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TRespone>> logger)
    {
        _validators = validators;
        _logger = logger;
    }
    
    public async Task<TRespone> Handle(TRequest request, RequestHandlerDelegate<TRespone> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting validation for request {RequestType}", typeof(TRequest).Name);
        
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );

            var failures = validationResults
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}