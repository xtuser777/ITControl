using ITControl.Application.Interfaces;
using ITControl.Communication.Equipments.Requests;
using ITControl.Communication.Equipments.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("equipments")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EquipmentsController(
        IEquipmentsService equipmentsService,
        IEquipmentsView equipmentsView) : ControllerBase
    {
        [HttpGet]
        public async Task<FindManyResponse<FindManyEquipmentsResponse>> Index(
            [FromQuery] FindManyEquipmentsRequest request)
        {
            var equipments = await equipmentsService.FindManyAsync(request);
            var pagination = await equipmentsService.FindManyPaginationAsync(request);
            var data = equipmentsView.FindMany(equipments);

            return new FindManyResponse<FindManyEquipmentsResponse>()
            {
                Data = data,
                Pagination = pagination
            };
        }

        [HttpGet("{id:guid}")]
        public async Task<FindOneResponse<FindOneEquipmentsResponse?>> Show(Guid id)
        {
            var equipment = await equipmentsService.FindOneAsync(id, true);
            var data = equipmentsView.FindOne(equipment);
            
            return new FindOneResponse<FindOneEquipmentsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        public async Task<FindOneResponse<CreateEquipmentsResponse?>> Create(CreateEquipmentsRequest request)
        {
            var equipment = await equipmentsService.CreateAsync(request);
            var data = equipmentsView.Create(equipment);
            Response.StatusCode = 201;
            return new FindOneResponse<CreateEquipmentsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, UpdateEquipmentsRequest request)
        {
            await equipmentsService.UpdateAsync(id, request);
            Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await equipmentsService.DeleteAsync(id);
            Response.StatusCode = 204;
        }
    }
}
