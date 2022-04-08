namespace MusicApp.Core.Domain.Models;
public class EventPlace
{
    public string? Id { get; }
    public string? PlaceName { get; }

    internal EventPlace(string placeName, string? id=null)
    {
        this.Id = id;
        this.PlaceName = placeName;
    }
}