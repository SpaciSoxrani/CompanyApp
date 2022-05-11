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

        foreach (HtmlNode link in htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'cell-list__list')]/div/a"))
        {
            //HtmlAttribute att = link.Attributes["href"];
            //if (att != null)
            if(link.InnerText != null)
            {
                // hrefTags.Add(att.Value);
                // Console.WriteLine(att.Value);
                Console.WriteLine(link.InnerText);
                hrefTags.Add(link.InnerText);
                var mainTitle = new MainTitle();
                mainTitle.Name = link.InnerText;
                riaNewsMainTitles.Add(mainTitle);
            }
        }
        return riaNewsMainTitles;
    }
}