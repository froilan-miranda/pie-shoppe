
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly IPieRepository _pieRepository;

    public SearchController(IPieRepository pieRepository)
    {
        _pieRepository = pieRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_pieRepository.AllPies);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var pie = _pieRepository.AllPies.Any(p => p.PieId == id);
        
        if (!pie) return NotFound();

        return Ok(pie);
    }

    [HttpPost]
    public IActionResult SearchPies([FromBody] string searchQuery)
    {
        IEnumerable<Pie> pies = new List<Pie>();
        if (!string.IsNullOrEmpty(searchQuery))
        {
            pies = _pieRepository.SearchPies(searchQuery);
        }

        return new JsonResult(pies);
    }
        
}