using ITControl.Application.Interfaces;
using ITControl.Communication.Divisions.Requests;
using ITControl.Communication.Divisions.Responses;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
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
    public async Task<FindOneDivisionsResponse?> Show([FromRoute] Guid id)
    {
        var division = await divisionsService.FindOneAsync(id); 
        var data = divisionsView.FindOne(division);
        
        return data;
    }

    [HttpPost]
    public async Task<CreateDivisionsResponse?> Create([FromBody] CreateDivisionsRequest request)
    {
        var division = await divisionsService.CreateAsync(request);
        var data = divisionsView.Create(division);
        
        return data;
    }

    [HttpPut("{id:guid}")]
    public async Task Update([FromRoute] Guid id, [FromBody] UpdateDivisionsRequest request)
    {
        await divisionsService.UpdateAsync(id, request);
    }

    [HttpDelete("{id:guid}")]
    public async Task Delete([FromRoute] Guid id)
    {
        await divisionsService.DeleteAsync(id);
    }
}
