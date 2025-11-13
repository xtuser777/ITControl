using ITControl.Application.Appointments.Interfaces;
using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Params;
using ITControl.Domain.Appointments.Params;
using ITControl.Domain.Notifications.Entities;
using ITControl.Domain.Shared.Params;
using Microsoft.Extensions.Hosting;

namespace ITControl.Application.Appointments.Services;

public class AppointmentsBackgroundTaskService(
    IUnitOfWork unitOfWork) : BackgroundService
{
    protected override async  Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var findManyAppointmentsParams = new FindManyRepositoryParams
            {
                FindManyProps = new FindManyAppointmentsParams 
                {
                    ScheduledAt = DateOnly.FromDateTime(DateTime.Now)
                }
            };
            var appointments = 
                await unitOfWork.AppointmentsRepository.FindManyAsync(
                    findManyAppointmentsParams);
            foreach (var appointment in appointments)
            {
                var differenceInMinutes = 
                    appointment.ScheduledIn!.Value -
                        TimeOnly.FromDateTime(DateTime.Now);
                if (differenceInMinutes.TotalMinutes == 60)
                {
                    await unitOfWork.NotificationsRepository.CreateAsync( 
                        new Notification
                        {
                            UserId = appointment.UserId,
                            Title = "Agendamento próximo",
                            Message =
                            $"Você tem um agendamento de atendimeento para " +
                            $"{appointment.ScheduledIn:HH:mm}.",
                            Type = Domain.Notifications.Enums.NotificationType.Warning,
                            Reference = Domain.Notifications.Enums.NotificationReference.Appointment,
                            AppointmentId = appointment.Id,
                        }
                    );
                }
            }
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
