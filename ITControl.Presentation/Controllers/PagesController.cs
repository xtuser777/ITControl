using ITControl.Application.Interfaces;
using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Pages.Response;
using ITControl.Communication.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController(IPagesService pagesService, IPagesView pagesView) : ControllerBase
    {
        [HttpGet]
        public async Task<FindManyResponse<FindManyPagesResponse>> Index([FromQuery] FindManyPagesRequest request)
        {
            var pages = await pagesService.FindMany(request);
            var pagination = await pagesService.FindManyPagination(request);
            var data = pagesView.FindMany(pages);

            return new FindManyResponse<FindManyPagesResponse>()
            {
                Data = data,
                Pagination = pagination
            };
        }

        [HttpGet("{id:guid}")]
        public async Task<FindOnePagesResponse?> Show(Guid id)
        {
            var page = await pagesService.FindOne(id);
            var data = pagesView.FindOne(page);
            
            return data;
        }

        [HttpPost]
        public async Task<CreatePagesResponse?> Create([FromBody] CreatePagesRequest request)
        {
            var page = await pagesService.Create(request);
            var data = pagesView.Create(page);
            
            return data;
        }

        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, [FromBody] UpdatePagesRequest request)
        {
            await pagesService.Update(id, request);
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await pagesService.Delete(id);
        }
    }
}
