using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Users.Interfaces;

public interface IUsersEquipmentsRepository
{
    Task<IEnumerable<UserEquipment>> FindManyAsync(Guid? userId = null, Guid? equipmentId = null);
    Task CreateManyAsync(IEnumerable<UserEquipment> userEquipments);
    Task DeleteManyByUserAsync(User user);
}