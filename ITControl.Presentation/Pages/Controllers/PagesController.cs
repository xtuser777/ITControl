using ITControl.Application.Pages.Interfaces;
using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Pages.Response;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Pages.Headers;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Pages.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PagesController(
        IPagesService service, 
        IPagesView view) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(FindManyResponse<FindManyPagesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> IndexAsync(
            [FromQuery] FindManyPagesRequest request,
            [FromHeader] OrderByPagesHeaders headers)
        {
            var pages = await service.FindManyAsync(request, headers);
            var pagination = await service.FindManyPaginationAsync(request);
            var data = view.FindMany(pages);

            return Ok(new FindManyResponse<FindManyPagesResponse>
            {
                Data = data,
                Pagination = pagination
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FindOneResponse<FindOnePagesResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ShowAsync([AsParameters] FindOnePagesRequest request)
        {
            var page = await service.FindOneAsync(request);
            var data = view.FindOne(page);
            
            return Ok(new FindOneResponse<FindOnePagesResponse?>
            {
                Data = data,
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(FindOneResponse<CreatePagesResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreatePagesRequest request)
        {
            var page = await service.CreateAsync(request);
            var data = view.Create(page);
            var uri = Url.Action("ShowAsync", new { id = data?.Id });
            return Created(uri, new { Data = data });
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateAsync(
            Guid id, 
            [FromBody] UpdatePagesRequest request)
        {
            await service.UpdateAsync(id, request);
            
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await service.DeleteAsync(id);
            
            return NoContent();
        }
    }
}
