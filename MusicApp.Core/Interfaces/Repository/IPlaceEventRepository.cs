using MusicApp.Core.Domain.Models;

namespace MusicApp.Core.Interfaces;

public interface IPlaceEventRepository
{
    Task<EventPlace> Create(EventPlace eventPlace);
    Task<EventPlace> FindByName(string eventPlace);
}