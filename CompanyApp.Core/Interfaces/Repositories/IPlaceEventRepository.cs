using CompanyApp.Core.Domain.Models;

namespace CompanyApp.Core.Interfaces;

public interface IPlaceEventRepository
{
    Task<EventPlace> Create(EventPlace eventPlace);
    Task<EventPlace> FindByName(string eventPlace);
}