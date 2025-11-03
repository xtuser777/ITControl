using ITControl.Application.Systems.Interfaces;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Shared.Responses;
using ITControl.Presentation.Systems.Interfaces;
using ITControl.Presentation.Systems.Params;
using ITControl.Presentation.Systems.Responses;
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
        [ProducesResponseType(
            typeof(FindManyResponse<FindManySystemsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> IndexAsync(
            [AsParameters] IndexSystemsParams parameters)
        {
            var systems = 
                await systemsService.FindManyAsync(parameters);
            var pagination = 
                await systemsService.FindManyPaginationAsync(parameters);
            var data = systemsView.FindMany(systems);
            return Ok(new
            {
                Data = data,
                Pagination = pagination
            });
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(
            typeof(FindOneResponse<FindOneSystemsResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ShowAsync(
            [AsParameters] ShowSystemsParams parameters)
        {
            var system = await systemsService.FindOneAsync(parameters);
            var data = systemsView.FindOne(system);
            return Ok(new { Data = data });
        }

        [HttpPost]
        [ProducesResponseType(
            typeof(FindOneResponse<CreateSystemsResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAsync(
            [AsParameters] CreateSystemsParams parameters)
        {
            var system = await systemsService.CreateAsync(parameters);
            var data = systemsView.Create(system);
            var uri = $"/Systems/{system?.Id}";
            return Created(uri, new { Data = data });
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateAsync(
            [AsParameters] UpdateSystemsParams parameters)
        {
            await systemsService.UpdateAsync(parameters);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAsync(
            [AsParameters] DeleteSystemsParams parameters)
        {
            await systemsService.DeleteAsync(parameters);
            return NoContent();
        }
    }
}
