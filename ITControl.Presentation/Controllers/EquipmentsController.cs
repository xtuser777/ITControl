using ITControl.Application.Interfaces;
using ITControl.Communication.Equipments.Requests;
using ITControl.Communication.Equipments.Responses;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<FindOneEquipmentsResponse?> Show(Guid id)
        {
            var equipment = await equipmentsService.FindOneAsync(id, true);
            var data = equipmentsView.FindOne(equipment);
            
            return data;
        }

        [HttpPost]
        public async Task<CreateEquipmentsResponse?> Create(CreateEquipmentsRequest request)
        {
            var equipment = await equipmentsService.CreateAsync(request);
            var data = equipmentsView.Create(equipment);
            
            return data;
        }

        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, UpdateEquipmentsRequest request)
        {
            await equipmentsService.UpdateAsync(id, request);
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await equipmentsService.DeleteAsync(id);
        }
    }
}
