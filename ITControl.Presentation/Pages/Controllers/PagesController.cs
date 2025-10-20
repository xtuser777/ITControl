using ITControl.Application.Pages.Interfaces;
using ITControl.Communication.Pages.Requests;
using ITControl.Communication.Pages.Response;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Pages.Params;
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
        [ProducesResponseType(
            typeof(FindManyResponse<FindManyPagesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> IndexAsync(
            [AsParameters] IndexPagesParams @params)
        {
            var pages = await service.FindManyAsync(@params);
            var pagination = await service.FindManyPaginationAsync(@params);
            var data = view.FindMany(pages);
            return Ok(new { Data = data, Pagination = pagination });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(
            typeof(FindOneResponse<FindOnePagesResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ShowAsync(
            [AsParameters] ShowPagesParams @params)
        {
            var page = await service.FindOneAsync(@params);
            var data = view.FindOne(page);
            return Ok(new { Data = data });
        }

        [HttpPost]
        [ProducesResponseType(
            typeof(FindOneResponse<CreatePagesResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAsync(
            [AsParameters] CreatePagesParams @params)
        {
            var page = await service.CreateAsync(@params);
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
            [AsParameters] UpdatePagesParams @params)
        {
            await service.UpdateAsync(@params);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteAsync(
            [AsParameters] DeletePagesParams @params)
        {
            await service.DeleteAsync(@params);
            return NoContent();
        }
    }
}
