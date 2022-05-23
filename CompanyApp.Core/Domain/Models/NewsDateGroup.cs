using Microsoft.EntityFrameworkCore;

namespace CompanyApp.Core.Domain.Models;

public sealed class NewsDateGroup : BaseEntity
{
    public Guid? Id { get; set; }
    public string? Name{ get; set; }
    public DateTime DateTime { get; set; }
    
    public List<MainTitle> News { get; set; }

     public NewsDateGroup(string name, DateTime dateTime, List<MainTitle> news) : this(name, dateTime)
     {
         // Name = name;
         // DateTime = dateTime;
         News = news;
     }

    private NewsDateGroup(string name, DateTime dateTime)
    {
        Name = name;
        DateTime = dateTime;
    }
}