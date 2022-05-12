using CompanyApp.Core;
using CompanyApp.Core.Domain.Models;
using MusicApp.Infrastructure.Database.Repositories;

namespace MusicApp;

public sealed class ParserRiaNewsService : IParserRiaNewsService
{
    private readonly IClassificationService classificationService;
    private IRepository<MainTitle> riaNewsRepository;
    private readonly ILogger<ParserRiaNewsService> logger;
    public ParserRiaNewsService(IClassificationService classificationService,
        IRepository<MainTitle> riaNewsRepository, ILogger<ParserRiaNewsService> logger)
    {
        this.classificationService = classificationService;
        this.riaNewsRepository = riaNewsRepository;
        this.logger = logger;
    }
    

    public void SaveAllAsync()
    {
        var riaNewsMainTitle = HtmlParser.HtmlAgilityPackParse();
        var existNewsMainTitle = riaNewsRepository.GetAll();
        
        bool anyNull = Enumerable.Empty<string>().Any();
        bool anyMainTitles = existNewsMainTitle.Any();
        
        foreach (var mainTitle in riaNewsMainTitle)
        {
            if(!existNewsMainTitle.Any(s => s.Name.Equals(mainTitle.Name)))
            {
                riaNewsRepository.Insert(mainTitle);
                classificationService.ClassificationTexts(mainTitle.Name);
            }
        }
    }
}