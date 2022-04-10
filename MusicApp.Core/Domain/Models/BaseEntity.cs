namespace MusicApp.Core.Domain.Models;

public class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}