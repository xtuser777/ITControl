using System.ComponentModel.DataAnnotations;
using ITControl.Domain.Shared;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Shared.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ITControl.Communication.Shared.Attributes;

public class UniqueFieldAttribute : ValidationAttribute
{
    private readonly Type _repositoryType;
    private readonly Type _paramsType;

    public UniqueFieldAttribute(Type repositoryType, Type paramsType)
    {
        _repositoryType = repositoryType;
        _paramsType = paramsType;
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.UniqueField);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }
        var repository = (IRepository<Entity>)context.GetService(_repositoryType)!;
        var httpContextAccessor = 
            (IHttpContextAccessor)context.GetService(typeof(IHttpContextAccessor))!;
        var httpContext = httpContextAccessor.HttpContext!;
        var method = httpContext.Request.Method;
        var propertyName = context.MemberName!;
        if (method == HttpMethods.Post)
        {
            var existsParams = 
                (FindManyRepositoryParams)_paramsType.GetConstructor(Type.EmptyTypes)!
                .Invoke(Array.Empty<object?>())!;
            existsParams.GetType().GetProperty(propertyName)!
                .SetValue(existsParams, value.ToString()!);
            var existsTask = repository.ExistsAsync(existsParams);
            existsTask.Wait();
            if (existsTask.Result)
            {
                return new ValidationResult(
                    FormatErrorMessage(context.DisplayName));
            }
        }
        else if (method == HttpMethods.Put || method == HttpMethods.Patch)
        {
            var idString = httpContext.GetRouteData().Values["id"]?.ToString() ?? "";
            if (Guid.TryParse(idString, out var id))
            {
                var exclusiveParams =
                    (FindManyRepositoryParams)_paramsType.GetConstructor(Type.EmptyTypes)!
                    .Invoke(Array.Empty<object?>())!;
                exclusiveParams.GetType().GetProperty("ExcludeId")!
                    .SetValue(exclusiveParams, id);
                exclusiveParams.GetType().GetProperty(propertyName)!
                    .SetValue(exclusiveParams, value.ToString()!);
                var exclusive = repository.ExclusiveAsync(exclusiveParams)
                    .GetAwaiter().GetResult();
                if (exclusive)
                {
                    return new ValidationResult(
                        FormatErrorMessage(context.DisplayName));
                }
            }
        }
        return ValidationResult.Success;
    }
}
