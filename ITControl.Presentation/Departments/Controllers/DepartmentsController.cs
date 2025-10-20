using ITControl.Application.Departments.Interfaces;
using ITControl.Communication.Departments.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Departments.Params;
using ITControl.Presentation.Shared.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Departments.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DepartmentsController(
        IDepartmentsService departmentsService, 
        IDepartmentsView departmentsView) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(
            typeof(FindManyResponse<FindManyDepartmentsResponse>), 
            StatusCodes.Status200OK)]
        [ProducesResponseType(
            typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> IndexAsync(
            [AsParameters] IndexDepartmentsParams @params)
        {
            var departments = await departmentsService.FindManyAsync(@params);
            var pagination = await departmentsService.FindManyPagination(@params);
            var data = departmentsView.FindMany(departments);

            return Ok(new 
            {
                Data = data,
                Pagination = pagination
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FindOneResponse<FindOneDepartmentsResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> ShowAsync(
            [AsParameters] ShowDepartmentsParams @params)
        {
            var department = await departmentsService.FindOneAsync(@params);
            var data = departmentsView.FindOne(department);
            
            return Ok(new { Data = data });
        }

        [HttpPost]
        [ProducesResponseType(typeof(FindOneResponse<CreateDepartmentsResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAsync(
            [AsParameters] CreateDepartmentsParams @params)
        {
            var department = await departmentsService.CreateAsync(@params);
            var data = departmentsView.Create(department);
            var uri = Url.Action(
                nameof(ShowAsync), 
                values: new { id = department?.Id })!;
            return Created(uri, new { Data = data });
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateAsync(
            [AsParameters] UpdateDepartmentsParams @params)
        {
            await departmentsService.UpdateAsync(@params);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(
            [AsParameters] DeleteDepartmentsParams @params)
        {
            await departmentsService.DeleteAsync(@params);
            return NoContent();
        }
    }
}
