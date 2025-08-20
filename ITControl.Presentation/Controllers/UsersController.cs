using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Communication.Users.Responses;
using ITControl.Presentation.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("users")]
    [ApiController]
    [PermissionsFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController(
        IUsersService usersService, 
        IUsersView usersView) : ControllerBase
    {
        [HttpGet]
        public async Task<FindManyResponse<FindManyUsersResponse>> Index([FromQuery] FindManyUsersRequest request)
        {
            var users = await usersService.FindManyAsync(request);
            var data = usersView.FindMany(users);
            var pagination = await usersService.FindManyPaginationAsync(request);

            return new FindManyResponse<FindManyUsersResponse>()
            {
                Data = data,
                Pagination = pagination
            };
        }

        [HttpGet("{id:guid}")]
        public async Task<FindOneResponse<FindOneUsersResponse?>> Show(Guid id)
        {
            var user = await usersService.FindOneAsync(id, true, true, true, true);
            var data = usersView.FindOne(user);
            
            return new FindOneResponse<FindOneUsersResponse?>()
            {
                Data = data,
            };
        }

        [HttpPost]
        public async Task<FindOneResponse<CreateUsersResponse?>> Create([FromBody] CreateUsersRequest request)
        {
            var user = await usersService.CreateAsync(request);
            var data = usersView.Create(user);
            this.Response.StatusCode = 201;
            return new FindOneResponse<CreateUsersResponse?>()
            {
                Data = data,
            };
        }

        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, [FromBody] UpdateUsersRequest request)
        {
            await usersService.UpdateAsync(id, request);
            this.Response.StatusCode = 204;
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await usersService.DeleteAsync(id); 
            this.Response.StatusCode = 204;
        }
    }
}
