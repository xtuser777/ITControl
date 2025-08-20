using ITControl.Domain.Entities;

namespace ITControl.Domain.Interfaces;

public interface IUsersEquipmentsRepository
{
    Task<IEnumerable<UserEquipment>> FindManyAsync(Guid? userId = null, Guid? equipmentId = null);
    Task CreateManyAsync(IEnumerable<UserEquipment> userEquipments);
    Task DeleteManyByUserAsync(User user);
}