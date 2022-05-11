using CompanyApp.Core;
using CompanyApp.Core.Domain.Models;
using MusicApp.Infrastructure.Database.Repositories;

namespace MusicApp;

public sealed class ParserRiaNewsService : IParserRiaNewsService
{
    private IRepository<MainTitle> riaNewsRepository;
    
    public ParserRiaNewsService(IRepository<MainTitle> riaNewsRepository)
    {
        this.riaNewsRepository = riaNewsRepository;
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
            }
        }
    }
}