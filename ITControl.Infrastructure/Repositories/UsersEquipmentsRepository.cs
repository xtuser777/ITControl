using ITControl.Domain.Entities;
using ITControl.Domain.Interfaces;
using ITControl.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ITControl.Infrastructure.Repositories;

public class UsersEquipmentsRepository(
    ApplicationDbContext context) : IUsersEquipmentsRepository
{
    public async Task<IEnumerable<UserEquipment>> FindManyAsync(Guid? userId = null, Guid? equipmentId = null)
    {
        var query = context.UsersEquipments.AsNoTracking();
        if (userId != null) query = query.Where(x => x.UserId == userId.Value);
        if (equipmentId != null) query = query.Where(x => x.EquipmentId == equipmentId.Value);
        
        return await query.ToListAsync();
    }

    public async Task CreateManyAsync(IEnumerable<UserEquipment> userEquipments)
    {
        await context.UsersEquipments.AddRangeAsync(userEquipments);
    }

    public async Task DeleteManyByUserAsync(User user)
    {
        await context.UsersEquipments
            .Where(x => x.UserId == user.Id)
            .ExecuteDeleteAsync();
    }
}