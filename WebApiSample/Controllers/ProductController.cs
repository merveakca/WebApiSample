using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.DTO;
using WebApiSample.Models;

namespace WebApiSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        NorthwndContext db = new NorthwndContext();
        //List<Product> products = db.Products.ToList();

        //var data = db.Products.Select(x => new
        //{
        //    x.ProductName,
        //    x.UnitPrice
        //}).ToList();

        List<GetAllProductsResponseDto> model = db.Products.Select(q => new GetAllProductsResponseDto
        {
            Id = q.ProductId,
            ProductName = q.ProductName,
            UnitPrice = q.UnitPrice,
            UnitsInStock = q.UnitsInStock
        }).ToList();

        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        NorthwndContext db = new NorthwndContext();

        Product product = db.Products.Find(id);

        if (product != null)
        {
            GetProductByIdResponseDto model = new GetProductByIdResponseDto();
            model.Id = product.ProductId;
            model.ProductName = product.ProductName;
            model.UnitPrice = product.UnitPrice;
            model.UnitsInStock = product.UnitsInStock;
            model.QuantityPerUnit = product.QuantityPerUnit;

            return Ok(model);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Create(CreateProductRequestDto model)
    {
        NorthwndContext db = new NorthwndContext();
        Product product=new Product();
        product.ProductName = model.ProductName;
        product.UnitPrice = model.UnitPrice;

        db.Products.Add(product);
        db.SaveChanges();

        return Ok(model);
    }
}
