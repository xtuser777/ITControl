using ITControl.Application.Interfaces;
using ITControl.Communication.Locations.Requests;
using ITControl.Communication.Locations.Responses;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController(
        ILocationsService locationsService,
        ILocationsView locationsView) : ControllerBase
    {
        [HttpGet]
        public async Task<FindManyResponse<FindManyLocationsResponse>> Index(
           [FromQuery] FindManyLocationsRequest request)
        {
            var locations = await locationsService.FindManyAsync(request);
            var pagination = await locationsService.FindManyPaginationAsync(request);
            var data = locationsView.FindMany(locations);

            return new FindManyResponse<FindManyLocationsResponse>()
            {
                Data = data,
                Pagination = pagination
            };
        }

        [HttpGet("{id:guid}")]
        public async Task<FindOneLocationsResponse?> Show(Guid id)
        {
            var location = await locationsService.FindOneAsync(id);
            var data = locationsView.FindOne(location);
            
            return data;
        }

        [HttpPost]
        public async Task<CreateLocationsResponse?> Create(CreateLocationsRequest request)
        {
            var location = await locationsService.CreateAsync(request);
            var data = locationsView.Create(location);
            
            return data;
        }

        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, UpdateLocationsRequest request)
        {
            await locationsService.UpdateAsync(id, request);
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await locationsService.DeleteAsync(id);
        }
    }
}
