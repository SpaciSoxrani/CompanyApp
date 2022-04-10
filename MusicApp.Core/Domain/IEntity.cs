namespace MusicApp.Core.Domain;

public interface IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}