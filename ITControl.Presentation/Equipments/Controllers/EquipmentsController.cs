using ITControl.Application.Equipments.Interfaces;
using ITControl.Presentation.Equipments.Interfaces;
using ITControl.Presentation.Equipments.Params;
using ITControl.Presentation.Equipments.Responses;
using ITControl.Presentation.Shared.Filters;
using ITControl.Presentation.Shared.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Equipments.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EquipmentsController(
        IEquipmentsService equipmentsService,
        IEquipmentsView equipmentsView) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(
            typeof(Shared.Responses.FindManyResponse<FindManyEquipmentsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> IndexAsync(
            [AsParameters] IndexEquipmentsParams @params)
        {
            var equipments = await equipmentsService
                .FindManyAsync(@params);
            var pagination = await equipmentsService
                .FindManyPaginationAsync(@params);
            var data = equipmentsView.FindMany(equipments);
            return Ok(new
            {
                Data = data,
                Pagination = pagination
            });
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(
            typeof(Shared.Responses.FindOneResponse<FindOneEquipmentsResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ShowAsync(
            [AsParameters] ShowEquipmentsParams @params)
        {
            var equipment = await equipmentsService.FindOneAsync(@params);
            var data = equipmentsView.FindOne(equipment);
            return Ok(new { Data = data });
        }

        [HttpPost]
        [ProducesResponseType(
            typeof(Shared.Responses.FindOneResponse<CreateEquipmentsResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAsync(
            [AsParameters] CreateEquipmentsParams @params)
        {
            var equipment = await equipmentsService.CreateAsync(@params);
            var data = equipmentsView.Create(equipment);
            var uri = $"/Equipments/{data?.Id}";
            return Created(uri, new { Data = data });
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateAsync(
            [AsParameters] UpdateEquipmentsParams @params)
        {
            await equipmentsService.UpdateAsync(@params);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAsync(
            [AsParameters] DeleteEquipmentsParams @params)
        {
            await equipmentsService.DeleteAsync(@params);
            return NoContent();
        }
    }
}
