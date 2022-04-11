namespace MusicApp.Core.Domain.Models;
public class EventPlace : BaseEntity
{
    public new string? Id { get; set; }
    public new string? Name { get; set; }

    // internal EventPlace(string placeName, string? id=null)
    // {
    //     this.Id = id;
    //     this.PlaceName = placeName;
    // }
}