namespace MessageBot;

public static class Program
{
    public static async Task Main()
    {
        await DailyJob.SchedulerService.Start();
        Console.WriteLine("Bot de WhatsApp rodando...");
        Console.ReadLine();
    }
}