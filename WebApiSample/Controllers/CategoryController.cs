using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.Models;

namespace WebApiSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        NorthwndContext db = new NorthwndContext();
        List<Category> categories = db.Categories.ToList();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        NorthwndContext db = new NorthwndContext();
        Category category = db.Categories.FirstOrDefault(x => x.CategoryId == id);

        if(category == null)
        {
            return NotFound("Böyle bir category mevcut değil");
        }

        return Ok(category);
    }
}
