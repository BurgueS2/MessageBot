using Quartz;
using Quartz.Impl;

namespace MessageBot;

public abstract class DailyJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        var events = CalendarServer.GetEvents();
        
        foreach (var calendarEvent in events.Items)
        {
            var title = calendarEvent.Summary;
            var description = calendarEvent.Description;
            
            var message = $"Olá, este é um alerta de evento! \n\nTítulo: {title} \nDescrição: {description}";
            
            // Lista de números para enviar a mensagem
            var numbers = new List<string>
            {
                "+5511998765432", // exemplos
                "+1234567890"
            };
            
            // Envia a mensagem para todos os números na list
            MessengerService.SendMessage(message, numbers);
        }
        
        return Task.CompletedTask;
    }
    
    public abstract class SchedulerService
    {
        public static async Task Start()
        {
            var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();
            
            var jobDetail = CreateDailyJob();
            var trigger = CreateDailyTrigger();
            
            await scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
    
    private static IJobDetail CreateDailyJob()
    {
        return JobBuilder.Create<DailyJob>().WithIdentity("dailyJob", "group1").Build();
    }
    
    private static ITrigger CreateDailyTrigger()
    {
        return TriggerBuilder.Create()
            .WithIdentity("dailyTrigger", "group1")
            .WithDailyTimeIntervalSchedule
            (
                s => s.WithIntervalInHours(24)
                .OnEveryDay()
                .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(11, 00))
            ).Build();
    }
}