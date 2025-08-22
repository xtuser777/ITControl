using ITControl.Application.Interfaces;
using ITControl.Communication.Appointments.Responses;
using ITControl.Communication.Locations.Requests;
using ITControl.Communication.Locations.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("locations")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LocationsController(
        ILocationsService locationsService,
        ILocationsView locationsView) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(FindManyResponse<FindManyLocationsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
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
        [ProducesResponseType(typeof(FindOneResponse<FindOneLocationsResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindOneResponse<FindOneLocationsResponse?>> Show(Guid id)
        {
            var location = await locationsService.FindOneAsync(id);
            var data = locationsView.FindOne(location);
            
            return new FindOneResponse<FindOneLocationsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        [ProducesResponseType(typeof(FindOneResponse<CreateLocationsResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindOneResponse<CreateLocationsResponse?>> Create(CreateLocationsRequest request)
        {
            var location = await locationsService.CreateAsync(request);
            var data = locationsView.Create(location);
            Response.StatusCode = 201;
            return new FindOneResponse<CreateLocationsResponse?>()
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
        public async Task Update(Guid id, UpdateLocationsRequest request)
        {
            await locationsService.UpdateAsync(id, request);
            Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task Delete(Guid id)
        {
            await locationsService.DeleteAsync(id);
            Response.StatusCode = 204;
        }
    }
}
