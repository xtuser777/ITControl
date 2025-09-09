using ITControl.Application.Supplements.Interfaces;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplements;

[Route("supplements-types")]
[ApiController]
public class SupplementsTypesController(
    ISupplementsTypesView supplementsTypesView) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var types = supplementsTypesView.FindMany();
        var response = new FindManyResponse<TranslatableField>()
        {
            Data = types
        };
        return Ok(response);
    }
}
