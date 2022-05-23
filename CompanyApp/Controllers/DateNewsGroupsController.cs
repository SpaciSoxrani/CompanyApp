using CompanyApp.Core.Domain.Models;
using CompanyApp.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Infrastructure.Database.Repositories;

namespace CompanyApp.Controllers;

[Route("api/[controller]")]
public class DateNewsGroupsController : ControllerBase
{
    private readonly CompanyAppContext _context;
    private IRepositoryDateGroup newsDateGroupsRepository;

    public DateNewsGroupsController(IRepositoryDateGroup newsDateGroupsRepository)
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