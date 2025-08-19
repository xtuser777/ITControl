using ITControl.Application.Interfaces;
using ITControl.Communication.Roles.Requests;
using ITControl.Communication.Roles.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("roles")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RolesController(IRolesService rolesService, IRolesView rolesView) : ControllerBase
    {
        [HttpGet]
        public async Task<FindManyResponse<FindManyRolesResponse>> Index([FromQuery] FindManyRolesRequest request)
        {
            var roles = await rolesService.FindManyAsync(request);
            var data = rolesView.FindMany(roles);
            var pagination = await rolesService.FindManyPaginatedAsync(request);

            return new FindManyResponse<FindManyRolesResponse>()
            {
                Data = data,
                Pagination = pagination
            };
        }

        [HttpGet("{id:guid}")]
        public async Task<FindOneResponse<FindOneRolesResponse?>> Show(Guid id)
        {
            var role = await rolesService.FindOneAsync(id, true);
            var data = rolesView.FindOne(role);
            
            return new FindOneResponse<FindOneRolesResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        public async Task<FindOneResponse<CreateRolesResponse?>> Create(
            [FromBody] CreateRolesRequest request)
        {
            var role = await rolesService.CreateAsync(request);
            var data = rolesView.Create(role);
            Response.StatusCode = 201;
            return new FindOneResponse<CreateRolesResponse?>()
            {
                Data = data,
            };
        }

        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, [FromBody] UpdateRolesRequest request)
        {
            await rolesService.UpdateAsync(id, request);
            Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await rolesService.DeleteAsync(id);
            Response.StatusCode = 204;
        }
    }
}
