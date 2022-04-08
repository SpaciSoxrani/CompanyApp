namespace MusicApp.Core.Domain.Models;
public class EventPlace
{
    public string? Id { get; set; }
    public string? PlaceName { get; set; }

    // internal EventPlace(string placeName, string? id=null)
    // {
    //     this.Id = id;
    //     this.PlaceName = placeName;
    // }
}