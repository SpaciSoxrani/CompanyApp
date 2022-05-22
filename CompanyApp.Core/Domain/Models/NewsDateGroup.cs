namespace CompanyApp.Core.Domain.Models;

public class NewsDateGroup : BaseEntity
{
    public new Guid? Id { get; set; }
    public new string? Name{ get; set; }
    public DateTime DateTime { get; set; }
    
    public IEnumerable<MainTitle> News { get; set; }

    public NewsDateGroup(string name, DateTime dateTime, IEnumerable<MainTitle> news)
    {
        Name = name;
        DateTime = dateTime;
        News = news;
    }
}