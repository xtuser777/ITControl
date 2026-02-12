using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Supplies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Supplies.Controllers;

[Route("supplies-types")]
[ApiController]
public class SuppliesTypesController(
    ISuppliesTypesView suppliesTypesView) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var types = suppliesTypesView.FindMany();
        var response = new FindManyResponse<TranslatableField>()
        {
            Data = types
        };
        return Ok(response);
    }
}
