using ITControl.Application.Systems.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Systems.Requests;
using ITControl.Communication.Systems.Responses;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Systems.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Systems.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SystemsController(
        ISystemsService systemsService,
        ISystemsView systemsView) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(FindManyResponse<FindManySystemsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindManyResponse<FindManySystemsResponse>> IndexAsync(
            [FromQuery] FindManySystemsRequest request,
            [FromHeader] OrderBySystemsHeaders orderBySystemsHeaders)
        {
            var systems = await systemsService.FindManyAsync(request, orderBySystemsHeaders);
            var pagination = await systemsService.FindManyPaginationAsync(request);
            var data = systemsView.FindMany(systems);

            return new FindManyResponse<FindManySystemsResponse>()
            {
                Data = data,
                Pagination = pagination
            };
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(FindOneResponse<FindOneSystemsResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindOneResponse<FindOneSystemsResponse?>> ShowAsync(
            [FromRoute] Guid id, [FromQuery] FindOneSystemsRequest request)
        {
            request.Id = id;
            var system = await systemsService.FindOneAsync(request);
            var data = systemsView.FindOne(system);
            
            return new FindOneResponse<FindOneSystemsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        [ProducesResponseType(typeof(FindOneResponse<CreateSystemsResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindOneResponse<CreateSystemsResponse?>> CreateAsync(
            [FromBody]CreateSystemsRequest request)
        {
            var system = await systemsService.CreateAsync(request);
            var data = systemsView.Create(system);
            Response.StatusCode = 201;
            return new FindOneResponse<CreateSystemsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task UpdateAsync(
            Guid id, 
            [FromBody] UpdateSystemsRequest request)
        {
            await systemsService.UpdateAsync(id, request);
            Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task DeleteAsync(Guid id)
        {
            await systemsService.DeleteAsync(id);
            Response.StatusCode = 204;
        }
    }
}
