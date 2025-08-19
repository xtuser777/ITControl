using ITControl.Application.Interfaces;
using ITControl.Communication.Contracts.Requests;
using ITControl.Communication.Contracts.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ContractsController(
        IContractsService contractsService, 
        IContractsView contractsView) : ControllerBase
    {
        [HttpGet]
        public async Task<FindManyResponse<FindManyContractsResponse>> Index(
            [FromQuery] FindManyContractsRequest request)
        {
            var contracts = await contractsService.FindManyAsync(request);
            var pagination = await contractsService.FindManyPaginationAsync(request);
            var data = contractsView.FindMany(contracts);

            return new FindManyResponse<FindManyContractsResponse>()
            {
                Data = data,
                Pagination = pagination,
            };
        }

        [HttpGet("{id:guid}")]
        public async Task<FindOneResponse<FindOneContractsResponse?>> Show(Guid id)
        {
            var contract = await contractsService.FindOneAsync(id);
            var data = contractsView.FindOne(contract);
            
            return new FindOneResponse<FindOneContractsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        public async Task<FindOneResponse<CreateContractsResponse?>> CreateAsync(CreateContractsRequest request)
        {
            var contract = await contractsService.CreateAsync(request);
            var data = contractsView.Create(contract);
            Response.StatusCode = 201;
            return new FindOneResponse<CreateContractsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPut("{id:guid}")]
        public async Task UpdateAsync(Guid id, UpdateContractsRequest request)
        {
            await contractsService.UpdateAsync(id, request);
            Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        public async Task DeleteAsync(Guid id)
        {
            await contractsService.DeleteAsync(id);
            Response.StatusCode = 204;
        }
    }
}
