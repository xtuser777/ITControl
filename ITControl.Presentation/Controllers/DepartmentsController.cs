using ITControl.Application.Interfaces;
using ITControl.Communication.Departments.Requests;
using ITControl.Communication.Departments.Responses;
using ITControl.Communication.Shared.Responses;
using ITControl.Domain.Entities;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task Update(Guid id, UpdateDepartmentsRequest request)
        {
            await departmentsService.UpdateAsync(id, request);
            Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await departmentsService.DeleteAsync(id);
            Response.StatusCode = 204;
        }
    }
}
