using System.ComponentModel.DataAnnotations;

namespace MusicApp.Core.Domain.Models;

public class MusicEvent : BaseEntity
{
    // public MusicEvent(long id, string? name, string? genre, DateTime releaseDate, decimal price, bool isComplete, EventPlace eventPlace)
    // {
    //     this.Id = id;
    //     this.Name = name;
    //     this.Genre = genre;
    //     this.ReleaseDate = releaseDate;
    //     this.Price = price;
    //     this.IsComplete = isComplete;
    //     this.eventPlace = eventPlace;
    // }

    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Genre { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
    public decimal Price { get; set; }
    public bool IsComplete { get; set; }
    
    public EventPlace eventPlace { get; set; }
}