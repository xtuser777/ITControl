using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ITControl.Communication.Shared.Helpers;

public static class ModelStateHelper
{
    public static ModelStateDictionary ModelState { get; set; } = null!;
}
