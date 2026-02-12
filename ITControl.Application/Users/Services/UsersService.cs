using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Messages;
using ITControl.Application.Shared.Params;
using ITControl.Application.Shared.Tools;
using ITControl.Application.Users.Interfaces;
using ITControl.Domain.Appointments.Params;
using ITControl.Domain.Calls.Params;
using ITControl.Domain.KnowledgeBases.Props;
using ITControl.Domain.Notifications.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Exceptions;
using ITControl.Domain.SuppliesMovements.Params;
using ITControl.Domain.Treatments.Params;
using ITControl.Domain.Users.Entities;
using ITControl.Domain.Users.Props;

namespace ITControl.Application.Users.Services;

public class UsersService(
    IUnitOfWork unitOfWork, 
    ICryptService cryptService) : IUsersService
{
    public async Task<User> FindOneAsync(
            FindOneServiceParams parameters)
    {
        return await unitOfWork.UsersRepository
                   .FindOneAsync(parameters) 
               ?? throw new NotFoundException(Errors.USER_NOT_FOUND);
    }

    public async Task<IEnumerable<User>> FindManyAsync(
            FindManyServiceParams parameters)
    {
        return await unitOfWork.UsersRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
            FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.UsersRepository
            .CountAsync(parameters.CountProps);
        var pagination = Pagination.Build(parameters.PaginationParams, count);
        return pagination;
    }

    public async Task<User?> CreateAsync(
        CreateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var props = (UserProps)parameters.Props;
        var user = new User(props)
        {
            Password = cryptService.HashPassword(props.Password!)
        };
        var usersEquipments = props.UsersEquipments!.ToList();
        usersEquipments.ForEach(ue => ue.UserId = user.Id);
        var usersSystems = props.UsersSystems!.ToList();
        usersSystems.ForEach(ue => ue.UserId = user.Id);
        await unitOfWork.UsersRepository.CreateAsync(user);
        await unitOfWork.UsersEquipmentsRepository
            .CreateManyAsync(usersEquipments);
        await unitOfWork.UsersSystemsRepository
            .CreateManyAsync(usersSystems);
        await unitOfWork.Commit(transaction);

        return user;
    }

    public async Task UpdateAsync(
        UpdateServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var user = await FindOneAsync(parameters);
        var props = (UserProps)parameters.Props;
        user.Update(props);
        if (props.Password is not null)
            user.Password = cryptService
                .HashPassword(props.Password!);
        var usersEquipments =  props.UsersEquipments!.ToList();
        usersEquipments.ForEach(ue => ue.UserId = user.Id);
        var usersSystems = props.UsersSystems!.ToList();
        usersSystems.ForEach(ue => ue.UserId = user.Id);
        await unitOfWork.UsersEquipmentsRepository
            .DeleteManyByUserAsync(user);
        await unitOfWork.UsersSystemsRepository
            .DeleteManyByUserAsync(user);
        await unitOfWork.UsersEquipmentsRepository
            .CreateManyAsync(usersEquipments);
        await unitOfWork.UsersSystemsRepository
            .CreateManyAsync(usersSystems);
        unitOfWork.UsersRepository.Update(user);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        await using var transaction = unitOfWork.BeginTransaction;
        var user = await FindOneAsync(parameters);
        await CheckDependenciesAsync(user.Id ?? Guid.Empty);
        await unitOfWork.UsersEquipmentsRepository.DeleteManyByUserAsync(user);
        await unitOfWork.UsersSystemsRepository.DeleteManyByUserAsync(user);
        unitOfWork.UsersRepository.Delete(user);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(
        Guid userId)
    {
        await CheckAppointmentDependenciesAsync(userId);
        await CheckCallDependenciesAsync(userId);
        await CheckKnowledgeBaseDependenciesAsync(userId);
        await CheckNotificationDependenciesAsync(userId);
        await CheckSupplyMovementDependenciesAsync(userId);
        await CheckTreatmentDependenciesAsync(userId);
    }

    private async Task CheckAppointmentDependenciesAsync(
        Guid userId)
    {
        var appointmentCount = await unitOfWork.AppointmentsRepository
            .CountAsync(new FindManyAppointmentsParams
                {
                    UserId = userId
                });
        if (appointmentCount > 0)
        {
            throw new BadRequestException(
                $"O usuário tem {appointmentCount} agendamentos");
        }
    }

    private async Task CheckCallDependenciesAsync(Guid userId)
    {
        var callCount = await unitOfWork.CallsRepository
            .CountAsync(new FindManyCallsParams
                {
                    UserId = userId
                });
        if (callCount > 0)
        {
            throw new BadRequestException(
                $"O usuário tem {callCount} chamados");
        }
    }

    private async Task CheckKnowledgeBaseDependenciesAsync(
        Guid userId)
    {
        var kbArticleCount = await unitOfWork.KnowledgeBasesRepository
            .CountAsync(new KnowledgeBaseProps
                {
                    UserId = userId
                });
        if (kbArticleCount > 0)
        {
            throw new BadRequestException(
                $"O usuário possui {kbArticleCount} artigos da base de conhecimento");
        }
    }

    private async Task CheckNotificationDependenciesAsync(
        Guid userId)
    {
        var notificationCount = await unitOfWork.NotificationsRepository
            .CountAsync(new FindManyNotificationsParams
                {
                    UserId = userId
                });
        if (notificationCount > 0)
        {
            throw new BadRequestException(
                $"O usuário possui {notificationCount} notificações");
        }
    }

    private async Task CheckSupplyMovementDependenciesAsync(
        Guid userId)
    {
        var supplyMovementCount = await unitOfWork.SuppliesMovementsRepository
            .CountAsync(new FindManySuppliesMovementsParams
                {
                    UserId = userId
                });
        if (supplyMovementCount > 0)
        {
            throw new BadRequestException(
                $"O usuário possui {supplyMovementCount} movimentações de suplemento");
        }
    }

    private async Task CheckTreatmentDependenciesAsync(
        Guid userId)
    {
        var treatmentCount = await unitOfWork.TreatmentsRepository
            .CountAsync(new FindManyTreatmentsParams
                {
                    UserId = userId
                });
        if (treatmentCount > 0)
        {
            throw new BadRequestException(
                $"O usuário possui {treatmentCount} atendimentos");
        }
    }
}