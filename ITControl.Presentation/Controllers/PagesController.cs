using ITControl.Application.Interfaces;
using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Pages.Response;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("pages")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<FindOneResponse<FindOnePagesResponse?>> Show(Guid id)
        {
            var page = await pagesService.FindOne(id);
            var data = pagesView.FindOne(page);
            
            return new FindOneResponse<FindOnePagesResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        public async Task<FindOneResponse<CreatePagesResponse?>> Create([FromBody] CreatePagesRequest request)
        {
            var page = await pagesService.Create(request);
            var data = pagesView.Create(page);
            this.Response.StatusCode = 201;
            return new FindOneResponse<CreatePagesResponse?>()
            {
                Data = data,
            };
        }

        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, [FromBody] UpdatePagesRequest request)
        {
            await pagesService.Update(id, request);
            this.Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await pagesService.Delete(id);
            this.Response.StatusCode = 204;
        }
    }
}
