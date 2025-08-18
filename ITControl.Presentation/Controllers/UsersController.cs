using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Communication.Users.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<FindOneUsersResponse?> Show(Guid id)
        {
            var user = await usersService.FindOneAsync(id, true, true);
            var data = usersView.FindOne(user);
            
            return data;
        }

        [HttpPost]
        public async Task<CreateUsersResponse?> Create([FromBody] CreateUsersRequest request)
        {
            var user = await usersService.CreateAsync(request);
            var data = usersView.Create(user);
            
            return data;
        }

        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, [FromBody] UpdateUsersRequest request)
        {
            await usersService.UpdateAsync(id, request);
        }

        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await usersService.DeleteAsync(id); 
        }
    }
}
