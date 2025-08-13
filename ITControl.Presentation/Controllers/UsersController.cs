using ITControl.Application.Interfaces;
using ITControl.Communication.Shared.Responses;
using ITControl.Communication.Users.Requests;
using ITControl.Communication.Users.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ITControl.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersService usersService, IUsersView usersView) : ControllerBase
    {
        // GET: api/<UsersController>
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

        // GET api/<UsersController>/5
        [HttpGet("{id:guid}")]
        public async Task<FindOneUsersResponse?> Show(Guid id)
        {
            var user = await usersService.FindOneAsync(id);
            var data = usersView.FindOne(user);
            
            return data;
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<CreateUsersResponse?> Create([FromBody] CreateUsersRequest request)
        {
            var user = await usersService.CreateAsync(request);
            var data = usersView.Create(user);
            
            return data;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id:guid}")]
        public async Task Update(Guid id, [FromBody] UpdateUsersRequest request)
        {
            await usersService.UpdateAsync(id, request);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await usersService.DeleteAsync(id); 
        }
    }
}
