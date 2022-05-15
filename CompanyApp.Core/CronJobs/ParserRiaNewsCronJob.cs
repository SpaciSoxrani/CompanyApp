using CompanyApp.Core.Domain.Models;
using MusicApp;
using MusicApp.Infrastructure.Database.Repositories;

namespace CompanyApp.Core.Domain.Services;

public class ParserRiaNewsCronJob : CronJobService
{
    private readonly ILogger<ParserRiaNewsCronJob> _logger;
    private readonly IParserRiaNewsService _parserRiaNewsService;
    
    public ParserRiaNewsCronJob(IScheduleConfig<ParserRiaNewsCronJob> config, ILogger<ParserRiaNewsCronJob> logger, IServiceScopeFactory factory)
        : base(config.CronExpression, config.TimeZoneInfo)
    {
        _logger = logger;
        _parserRiaNewsService = factory.CreateScope().ServiceProvider.GetRequiredService<IParserRiaNewsService>();
    }
    
    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("CronJob RiaNewsParser starts.");
        return base.StartAsync(cancellationToken);
    }

    public override Task DoWork(CancellationToken cancellationToken)
    {
        //переопределить этот метод
        _logger.LogInformation($"{DateTime.Now:hh:mm:ss} CronJob RiaNewsParser is working.");
        
        _parserRiaNewsService.SaveAllAsync();
        
        
        return Task.CompletedTask;
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("CronJob RiaNewsParser is stopping.");
        return base.StopAsync(cancellationToken);
    }
}