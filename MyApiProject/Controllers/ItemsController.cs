using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers;

[ApiController]
public class ItemsController : ControllerBase
{
    // Variable to store text (simulating global variable)
    private static string storedText = "";

    // GET /
    [HttpGet("/")]
    public IActionResult ReadHello()
    {
        return Ok(new { message = "Hello API!" });
    }

    // GET /items/{item_id}
    [HttpGet("/items/{item_id}")]
    public IActionResult ReadItem(int item_id, [FromQuery] string? q = null)
    {
        return Ok(new { item_id, query = q });
    }

    // PUT /text
    [HttpPut("/text")]
    public IActionResult StoreText(string text)
    {
        storedText = text;
        return Ok("ok");
    }

    // GET /text
    [HttpGet("/text")]
    public IActionResult GetText()
    {
        return Ok(storedText);
    }
}