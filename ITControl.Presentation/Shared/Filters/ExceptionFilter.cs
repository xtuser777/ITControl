using System.Net;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITControl.Presentation.Shared.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var result = context.Exception is ITControlException;
        if ( result )
        {
            HandleProjectException(context);
        }
        else
        {
            if (context.Exception is UnauthorizedAccessException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new UnauthorizedObjectResult(new ErrorJsonResponse([context.Exception.Message]));
            }
            else
                ThrowUnknowError(context);
        }
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case DomainException:
            case BadRequestException:
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ErrorJsonResponse([context.Exception.Message]));
                break;
            case NotFoundException:
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new NotFoundObjectResult(new ErrorJsonResponse([context.Exception.Message]));
                break;
            case ConflictException:
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                context.Result = new ConflictObjectResult(new ErrorJsonResponse([context.Exception.Message]));
                break;
            case ExistenceException:
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new NotFoundObjectResult(new ErrorJsonResponse([context.Exception.Message]));
                break;
            case ConverterException:
                context.ModelState.AddModelError((context.Exception as ConverterException)!.PropertyName, context.Exception.Message);
                break;
        }
    }

    private static void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ErrorJsonResponse(["Unknown Error"]));
    }
}