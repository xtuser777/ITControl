using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Systems.Requests;
using ITControl.Communication.Systems.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("systems")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SystemsController(
        ISystemsService systemsService,
        ISystemsView systemsView) : ControllerBase
    {
        [HttpGet]
        public async Task<FindManyResponse<FindManySystemsResponse>> Index(FindManySystemsRequest request)
        {
            var systems = await systemsService.FindManyAsync(request);
            var pagination = await systemsService.FindManyPaginationAsync(request);
            var data = systemsView.FindMany(systems);

            return new FindManyResponse<FindManySystemsResponse>()
            {
                Data = data,
                Pagination = pagination
            };
        }

        [HttpGet("{id:guid}")]
        public async Task<FindOneResponse<FindOneSystemsResponse?>> Show(Guid id)
        {
            var system = await systemsService.FindOneAsync(id);
            var data = systemsView.FindOne(system);
            
            return new FindOneResponse<FindOneSystemsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        public async Task<FindOneResponse<CreateSystemsResponse?>> Create(CreateSystemsRequest request)
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
        public async Task Update(Guid id, UpdateSystemsRequest request)
        {
            await systemsService.UpdateAsync(id, request);
            Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await systemsService.DeleteAsync(id);
            Response.StatusCode = 204;
        }
    }
}
