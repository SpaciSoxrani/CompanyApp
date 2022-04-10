namespace MusicApp.Core.Domain;

public interface IEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
}