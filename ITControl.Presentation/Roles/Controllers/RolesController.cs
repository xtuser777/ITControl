using ITControl.Application.Roles.Interfaces;
using ITControl.Presentation.Roles.Interfaces;
using ITControl.Presentation.Roles.Responses;
using ITControl.Presentation.Roles.Params;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ITControl.Presentation.Shared.Responses;

namespace ITControl.Presentation.Roles.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RolesController(
        IRolesService rolesService, 
        IRolesView rolesView) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(
            typeof(Shared.Responses.FindManyResponse<FindManyRolesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> IndexAsync(
            [AsParameters] IndexRolesParams parameters)
        {
            var roles = await rolesService.FindManyAsync(parameters);
            var pagination = await rolesService.FindManyPaginatedAsync(parameters);
            var data = rolesView.FindMany(roles);

            return Ok(new 
            {
                Data = data, Pagination = pagination
            });
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(
            typeof(Shared.Responses.FindOneResponse<FindOneRolesResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ShowAsync(
            [AsParameters] ShowRolesParams parameters)
        {
            var role = await rolesService.FindOneAsync(parameters);
            var data = rolesView.FindOne(role);
            
            return Ok(new 
            {
                Data = data,
            });
        }

        [HttpPost]
        [ProducesResponseType(
            typeof(Shared.Responses.FindOneResponse<CreateRolesResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAsync(
            [AsParameters] CreateRolesParams parameters)
        {
            var role = await rolesService.CreateAsync(parameters);
            var data = rolesView.Create(role);
            var uri = $"/roles/{role?.Id}";
            return Created(uri, new 
            {
                Data = data,
            });
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateAsync(
            [AsParameters] UpdateRolesParams parameters)
        {
            await rolesService.UpdateAsync(parameters);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAsync(
            DeleteRolesParams parameters)
        {
            await rolesService.DeleteAsync(parameters);
            return NoContent();
        }
    }
}
