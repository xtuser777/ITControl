using ITControl.Application.Interfaces;
using ITControl.Communication.Appointments.Responses;
using ITControl.Communication.Departments.Requests;
using ITControl.Communication.Departments.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("departments")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DepartmentsController(
        IDepartmentsService departmentsService, 
        IDepartmentsView departmentsView) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(FindManyResponse<FindManyDepartmentsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindManyResponse<FindManyDepartmentsResponse>> Index([FromQuery] FindManyDepartmentsRequest request)
        {
            var departments = await departmentsService.FindManyAsync(request);
            var pagination = await departmentsService.FindManyPagination(request);
            var data = departmentsView.FindMany(departments);

            return new FindManyResponse<FindManyDepartmentsResponse>()
            {
                Data = data,
                Pagination = pagination
            };
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(FindOneResponse<FindOneDepartmentsResponse?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindOneResponse<FindOneDepartmentsResponse?>> Show(Guid id)
        {
            var department = await departmentsService.FindOneAsync(id);
            var data = departmentsView.FindOne(department);
            
            return new FindOneResponse<FindOneDepartmentsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        [ProducesResponseType(typeof(FindOneResponse<CreateDepartmentsResponse?>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task<FindOneResponse<CreateDepartmentsResponse?>> Create(CreateDepartmentsRequest request)
        {
            var department = await departmentsService.CreateAsync(request);
            var data = departmentsView.Create(department);
            Response.StatusCode = 201;
            return new FindOneResponse<CreateDepartmentsResponse?>()
            {
                Data = data,
            };
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task Update(Guid id, UpdateDepartmentsRequest request)
        {
            await departmentsService.UpdateAsync(id, request);
            Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorJsonResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        public async Task Delete(Guid id)
        {
            await departmentsService.DeleteAsync(id);
            Response.StatusCode = 204;
        }
    }
}
