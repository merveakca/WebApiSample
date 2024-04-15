using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.Models;

namespace WebApiSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        NorthwndContext db = new NorthwndContext();
        List<Customer> customers = db.Customers.ToList();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        NorthwndContext db = new NorthwndContext();

        Customer customer = db.Customers.FirstOrDefault(q => q.CustomerId == id);

        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult Create(Customer customer)
    {
        NorthwndContext db = new NorthwndContext();
        db.Customers.Add(customer);
        db.SaveChanges();
        return Ok(db);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        NorthwndContext db = new NorthwndContext();
        Customer customer = db.Customers.FirstOrDefault(q => q.CustomerId == id);

        if (customer == null)
        {
            return NotFound("Böyle bir customer bulunamadı");
        }

        db.Customers.Remove(customer);
        db.SaveChanges();
        return Ok("Silme işlem başarılı");
    }

    [HttpPut]
    public IActionResult Put(Customer customer)
    {
        NorthwndContext db = new NorthwndContext();

        Customer entity = db.Customers.FirstOrDefault(q => q.CustomerId == customer.CustomerId);

        if (entity == null)
        {
            return NotFound();
        }

        entity.CompanyName = customer.CompanyName;
        entity.ContactName = customer.ContactName;
        entity.Phone = customer.Phone;

        db.SaveChanges();
        return Ok(entity);
    }
}
