namespace MusicApp.Core.Domain.Models;

public class BaseEntity : IEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
}