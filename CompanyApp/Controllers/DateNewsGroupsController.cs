using CompanyApp.Core.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Infrastructure.Database.Repositories;

namespace CompanyApp.Controllers;

public class DateNewsGroupsController : ControllerBase
{
    private IRepositoryDateGroup<NewsDateGroup> newsDateGroupsRepository;

    public DateNewsGroupsController(IRepositoryDateGroup<NewsDateGroup> newsDateGroupsRepository)
    {
        this.newsDateGroupsRepository= newsDateGroupsRepository;
    }
    
    [HttpGet]
    public IEnumerable<NewsDateGroup> GetDateGroups() => newsDateGroupsRepository.GetAll();
        
    [HttpGet]
    [Route("{id}")]
    public NewsDateGroup GetDateGroupById(Guid id) => newsDateGroupsRepository.GetById(id);
    
    [HttpGet]
    [Route("{dateTime}")]
    public NewsDateGroup GetDateGroupByDate(DateTime dateTime) => newsDateGroupsRepository.GetByDate(dateTime);
}