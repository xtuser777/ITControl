using ITControl.Domain.Users.Entities;
using ITControl.Domain.Users.Interfaces;
using ITControl.Infrastructure.Shared.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Users.Repositories;

public class UsersEquipmentsRepository(
    ApplicationDbContext context) : IUsersEquipmentsRepository
{
    public async Task<IEnumerable<UserEquipment>> FindManyAsync(
        Guid? userId = null, Guid? equipmentId = null)
    {
        var query = context.UsersEquipments.AsNoTracking();
        if (userId != null) 
            query = query.Where(x => x.UserId == userId.Value);
        if (equipmentId != null) 
            query = query.Where(x => x.EquipmentId == equipmentId.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateManyAsync(IEnumerable<UserEquipment> userEquipments)
    {
        await context.UsersEquipments.AddRangeAsync(userEquipments);
    }

    public async Task DeleteManyByUserAsync(User user)
    {
        var ues = await context.UsersEquipments
            .AsQueryable()
            .Where(x => x.UserId == user.Id)
            .ExecuteDeleteAsync();
    }
}