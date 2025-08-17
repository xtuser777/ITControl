using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Systems.Requests;
using ITControl.Communication.Systems.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<FindOneSystemsResponse?> Show(Guid id)
        {
            var system = await systemsService.FindOneAsync(id);
            var data = systemsView.FindOne(system);
            
            return data;
        }

        [HttpPost]
        public async Task<CreateSystemsResponse?> Create(CreateSystemsRequest request)
        {
            var system = await systemsService.CreateAsync(request);
            var data = systemsView.Create(system);
            
            return data;
        }

        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, UpdateSystemsRequest request)
        {
            await systemsService.UpdateAsync(id, request);
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await systemsService.DeleteAsync(id);
        }
    }
}
