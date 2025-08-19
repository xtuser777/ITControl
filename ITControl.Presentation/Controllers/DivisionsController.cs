using ITControl.Application.Interfaces;
using ITControl.Communication.Divisions.Requests;
using ITControl.Communication.Divisions.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers;

[Route("divisions")]
[ApiController]
[PermissionsFilter]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DivisionsController(
    IDivisionsService divisionsService, 
    IDivisionsView divisionsView) : ControllerBase
{
    [HttpGet]
    public async Task<FindManyResponse<FindManyDivisionsResponse>> Index([FromQuery] FindManyDivisionsRequest request)
    {
        var divisions = await divisionsService.FindManyAsync(request);
        var pagination = await divisionsService.FindManyPaginatedAsync(request);
        var data = divisionsView.FindMany(divisions);

        return new FindManyResponse<FindManyDivisionsResponse>()
        {
            Data = data,
            Pagination = pagination
        };
    }

    [HttpGet("{id:guid}")]
    public async Task<FindOneResponse<FindOneDivisionsResponse?>> Show([FromRoute] Guid id)
    {
        var division = await divisionsService.FindOneAsync(id); 
        var data = divisionsView.FindOne(division);
        
        return new FindOneResponse<FindOneDivisionsResponse?>()
        {
            Data = data,
        };
    }

    [HttpPost]
    public async Task<FindOneResponse<CreateDivisionsResponse?>> Create([FromBody] CreateDivisionsRequest request)
    {
        var division = await divisionsService.CreateAsync(request);
        var data = divisionsView.Create(division);
        Response.StatusCode = 201;
        return new FindOneResponse<CreateDivisionsResponse?>()
        {
            Data = data,
        };
    }

    [HttpPut("{id:guid}")]
    public async Task Update([FromRoute] Guid id, [FromBody] UpdateDivisionsRequest request)
    {
        await divisionsService.UpdateAsync(id, request);
        Response.StatusCode = 204;
    }

    [HttpDelete("{id:guid}")]
    public async Task Delete([FromRoute] Guid id)
    {
        await divisionsService.DeleteAsync(id);
        Response.StatusCode = 204;
    }
}
