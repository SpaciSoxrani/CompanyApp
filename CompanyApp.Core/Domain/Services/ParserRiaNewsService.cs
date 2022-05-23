using CompanyApp.Core.Domain.Models;
using MusicApp;
using MusicApp.Infrastructure.Database.Repositories;

namespace CompanyApp.Core.Domain.Services;

public sealed class ParserRiaNewsService : IParserRiaNewsService
{
    private readonly IClassificationService<MainTitle> classificationService;
    private IRepository<MainTitle> riaNewsRepository;
    private IRepositoryDateGroup groupsDateNewsRepo;
    private readonly ILogger<ParserRiaNewsService> logger;
    public ParserRiaNewsService(IClassificationService<MainTitle> classificationService,
        IRepository<MainTitle> riaNewsRepository, 
        IRepositoryDateGroup groupsDateNewsRepo, 
        ILogger<ParserRiaNewsService> logger)
    {
        this.classificationService = classificationService;
        this.riaNewsRepository = riaNewsRepository;
        this.groupsDateNewsRepo = groupsDateNewsRepo;
        this.logger = logger;
    }
    

    public void SaveAllAsync()
    {
        var riaNewsMainTitle = HtmlParser.HtmlAgilityPackParse();
        var existNewsMainTitle = riaNewsRepository.GetAll();
        GroupNewsByDate groupNewsByDate = new GroupNewsByDate();
        
        logger.LogInformation("About page visited at {DT}", 
            DateTime.UtcNow.ToLongTimeString());
        
        foreach (var mainTitle in riaNewsMainTitle)
        {
            if(!existNewsMainTitle.Any(s => s.Name.Equals(mainTitle.Name)))
            {
                var prediction=classificationService.ClassificationTexts(mainTitle);
                var newMainTitle = new MainTitle(mainTitle.Name,
                    Convert.ToBoolean(prediction.Prediction) ? "Positive" : "Negative",
                    prediction.Probability,
                    DateTime.Now);
                riaNewsRepository.Insert(newMainTitle);

            }
        }

        List<MainTitle> newsList = riaNewsRepository.GetAll().ToList();
        var groupsDateNews = groupNewsByDate.ReturnGroupsByDate(newsList);
        foreach (var group in groupsDateNews)
        {
            groupsDateNewsRepo.Insert(new NewsDateGroup(
                $"New group : {group.Key}",
                new DateTime(group.Key.Year, group.Key.Month, group.Key.Day),
                group.Value));
        }
    }
}