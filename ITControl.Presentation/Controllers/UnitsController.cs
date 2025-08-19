using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Units.Requests;
using ITControl.Communication.Units.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("units")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UnitsController(
        IUnitsService unitsService,
        IUnitsView unitsView) : ControllerBase
    {
        [HttpGet]
        public async Task<FindManyResponse<FindManyUnitsResponse>> Index([FromQuery] FindManyUnitsRequest request)
        {
            var units = await unitsService.FindManyAsync(request);
            var pagination = await unitsService.FindManyPaginationAsync(request);
            var data = unitsView.FindMany(units);

            return new FindManyResponse<FindManyUnitsResponse>()
            {
                Data = data,
                Pagination = pagination,
            };
        }

        [HttpGet("{id:guid}")]
        public async Task<FindOneResponse<FindOneUnitsResponse?>> FindOne([FromRoute] Guid id)
        {
            var unit = await unitsService.FindOneAsync(id);
            var data = unitsView.FindOne(unit);
            
            return new FindOneResponse<FindOneUnitsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        public async Task<FindOneResponse<CreateUnitsResponse?>> Create(CreateUnitsRequest request)
        {
            var unit = await unitsService.CreateAsync(request);
            var data = unitsView.Create(unit);
            Response.StatusCode = 201;
            return new FindOneResponse<CreateUnitsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPut("{id:guid}")]
        public async Task Update([FromRoute] Guid id, UpdateUnitsRequest request)
        {
            await unitsService.UpdateAsync(id, request);
            Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete([FromRoute] Guid id)
        {
            await unitsService.DeleteAsync(id);
            Response.StatusCode = 204;
        }
    }
}
