using MusicApp;
using NCrontab;

namespace CompanyApp.Core.Domain.Services;

public class MyTestHostedService : BackgroundService
{
    private CrontabSchedule _schedule;
    private DateTime _nextRun;
    private IParserRiaNewsService _parserRiaNewsService;

    private  string Schedule => "*/10 * * * * *"; //Runs every 10 seconds

    public MyTestHostedService(IServiceScopeFactory factory)
    {
        _schedule = CrontabSchedule.Parse(Schedule,new CrontabSchedule.ParseOptions { IncludingSeconds = true });
        _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        _parserRiaNewsService = factory.CreateScope().ServiceProvider.GetRequiredService<IParserRiaNewsService>();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        do
        {
            var now = DateTime.Now;
            var nextrun = _schedule.GetNextOccurrence(now);
            if (now > _nextRun)
            {
                Process();
                _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            }
            await Task.Delay(5000, stoppingToken); //5 seconds delay
        }
        while (!stoppingToken.IsCancellationRequested);
    }

    private void Process()
    {
        _parserRiaNewsService.SaveAllAsync();
        Console.WriteLine("hello world"+ DateTime.Now.ToString("F"));
    }
}