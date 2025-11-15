using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok(new string[] { "Item1", "Item2", "Item3" });
    }

    [HttpGet("{id}")]
    public IActionResult GetItem(int id)
    {
        return Ok(new { Id = id, Name = $"Item{id}" });
    }
}