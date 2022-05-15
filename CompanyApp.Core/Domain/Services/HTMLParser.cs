using CompanyApp.Core.Domain.Models;
using HtmlAgilityPack;
using MusicApp.Infrastructure.Database.Repositories;

namespace CompanyApp.Core;

public class HtmlParser
{
    static IRepository<MainTitle> riaNewsRepository;
    public static IEnumerable<MainTitle> HtmlAgilityPackParse()
    {
        var html = @"https://ria.ru/";
        HtmlWeb htmlSnippet = new HtmlWeb();
        var htmlDoc = htmlSnippet.Load(html);

        List<string> hrefTags = new List<string>();
        List<MainTitle> riaNewsMainTitles = new List<MainTitle>();

        foreach (HtmlNode text in htmlDoc.DocumentNode
                     .SelectNodes("//div[contains(@class, 'cell-list__list')]/div/a"))
        {
            if(text.InnerText != null)
            {
                //Console.WriteLine(link.InnerText);
                hrefTags.Add(text.InnerText);
                var mainTitle = new MainTitle(text.InnerText, null, 0, DateTime.Today);
               
                riaNewsMainTitles.Add(mainTitle);
            }
        }
        return riaNewsMainTitles;
    }
}