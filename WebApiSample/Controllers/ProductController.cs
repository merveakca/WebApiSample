using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.Models;

namespace WebApiSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    public List<Product> GetAll()
    {
        NorthwndContext db = new NorthwndContext();
        List<Product> products = db.Products.ToList();
        return products;
    }

    [HttpGet("{id}")]
    public Product Get(int id)
    {
        NorthwndContext db = new NorthwndContext();
        Product product = db.Products.FirstOrDefault(x => x.ProductId == id);
        return product;
    }
}
