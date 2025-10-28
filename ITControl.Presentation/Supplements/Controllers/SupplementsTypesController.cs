﻿using ITControl.Presentation.Supplements.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Supplements.Controllers;

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
