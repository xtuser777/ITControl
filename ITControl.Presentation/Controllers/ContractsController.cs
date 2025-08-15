using ITControl.Application.Interfaces;
using ITControl.Communication.Contracts.Requests;
using ITControl.Communication.Contracts.Responses;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<FindOneContractsResponse?> Show(Guid id)
        {
            var contract = await contractsService.FindOneAsync(id);
            var data = contractsView.FindOne(contract);
            
            return data;
        }

        [HttpPost]
        public async Task<CreateContractsResponse?> CreateAsync(CreateContractsRequest request)
        {
            var contract = await contractsService.CreateAsync(request);
            var data = contractsView.Create(contract);
            
            return data;
        }

        [HttpPut("{id:guid}")]
        public async Task UpdateAsync(Guid id, UpdateContractsRequest request)
        {
            await contractsService.UpdateAsync(id, request);
        }

        [HttpDelete("{id:guid}")]
        public async Task DeleteAsync(Guid id)
        {
            await contractsService.DeleteAsync(id);
        }
    }
}
