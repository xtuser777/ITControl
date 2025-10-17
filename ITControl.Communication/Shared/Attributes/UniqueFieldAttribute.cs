using ITControl.Domain.Shared;
using ITControl.Domain.Shared.Messages;
using ITControl.Domain.Shared.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.DataAnnotations;

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
        var repository = (IRepository)context.GetService(_repositoryType)!;
        var httpContextAccessor = (IHttpContextAccessor)context.GetService(typeof(IHttpContextAccessor))!;
        var httpContext = httpContextAccessor.HttpContext!;
        var method = httpContext.Request.Method;
        if (method == HttpMethods.Post)
        {
            var existsParams = _paramsType.GetConstructor(Type.EmptyTypes)!.Invoke(Array.Empty<object?>())!;
            existsParams.GetType().GetProperty("Name")!.SetValue(existsParams, value.ToString()!);
            var existsTask = repository.ExistsAsync((IExistsRepositoryParams)existsParams);
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
                var exclusiveParams = _paramsType.GetConstructor(Type.EmptyTypes)!.Invoke(Array.Empty<object?>())!;
                exclusiveParams.GetType().GetProperty("ExcludeId")!.SetValue(exclusiveParams, id);
                exclusiveParams.GetType().GetProperty("Name")!.SetValue(exclusiveParams, value.ToString()!);
                var exclusiveTask = repository.ExclusiveAsync((IExclusiveRepositoryParams)exclusiveParams);
                exclusiveTask.Wait();
                if (exclusiveTask.Result)
                {
                    return new ValidationResult(
                        FormatErrorMessage(context.DisplayName));
                }
            }
        }
        return ValidationResult.Success;
    }
}
