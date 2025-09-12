using Microsoft.AspNetCore.Http;

namespace ITControl.Communication.Shared.Helpers;

public static class ContextHelper
{
    private static HttpContext _httpContext => new HttpContextAccessor().HttpContext;

    public static HttpContext GetContext() => _httpContext;
}
