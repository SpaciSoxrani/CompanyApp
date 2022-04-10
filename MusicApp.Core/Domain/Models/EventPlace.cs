namespace MusicApp.Core.Domain.Models;
public class EventPlace : BaseEntity
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }

    // internal EventPlace(string placeName, string? id=null)
    // {
    //     this.Id = id;
    //     this.PlaceName = placeName;
    // }
}