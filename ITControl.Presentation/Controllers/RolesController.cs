using ITControl.Application.Interfaces;
using ITControl.Communication.Roles.Requests;
using ITControl.Communication.Roles.Responses;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<FindOneRolesResponse?> Show(Guid id)
        {
            var role = await rolesService.FindOneAsync(id, true);
            var data = rolesView.FindOne(role);
            
            return data;
        }

        [HttpPost]
        public async Task<CreateRolesResponse?> Create([FromBody] CreateRolesRequest request)
        {
            var role = await rolesService.CreateAsync(request);
            var data = rolesView.Create(role);
            
            return data;
        }

        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, [FromBody] UpdateRolesRequest request)
        {
            await rolesService.UpdateAsync(id, request);
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await rolesService.DeleteAsync(id);
        }
    }
}
