using ITControl.Application.Contracts.Interfaces;
using ITControl.Communication.Contracts.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Contracts.Params;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Contracts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ContractsController(
        IContractsService contractsService, 
        IContractsView contractsView) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(
            typeof(FindManyResponse<FindManyContractsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> IndexAsync(
            [AsParameters] IndexContractsParams index)
        {
            var contracts = await contractsService.FindManyAsync(index);
            var pagination = await contractsService.FindManyPaginationAsync(index);
            var data = contractsView.FindMany(contracts);
            return Ok(new
            {
                Data = data,
                Pagination = pagination,
            });
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(
            typeof(FindOneResponse<FindOneContractsResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ShowAsync(
            [AsParameters] ShowContractsParams show)
        {
            var contract = await contractsService.FindOneAsync(show);
            var data = contractsView.FindOne(contract);
            
            return Ok(new
            {
                Data = data,
            });
        }

        [HttpPost]
        [ProducesResponseType(
            typeof(FindOneResponse<CreateContractsResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAsync(
            [AsParameters] CreateContractsParams create)
        {
            var contract = await contractsService.CreateAsync(create);
            var data = contractsView.Create(contract);
            var uri = $"/contracts/{data?.Id}";
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
            [AsParameters] UpdateContractsParams update)
        {
            await contractsService.UpdateAsync(update);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAsync(
            [AsParameters] DeleteContractsParams delete)
        {
            await contractsService.DeleteAsync(delete);
            return NoContent();
        }
    }
}
