using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.Models;

namespace WebApiSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        NorthwndContext db = new NorthwndContext();
        List<Supplier> suppliers = db.Suppliers.ToList();
        return Ok(suppliers);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        NorthwndContext db = new NorthwndContext();
        Supplier supplier = db.Suppliers.FirstOrDefault(x => x.SupplierId == id);

        if (supplier == null)
        {
            return NotFound("Böyle bir suplier mevcut değil");
        }

        return Ok(supplier);
    }

    [HttpPost]
    public IActionResult Create(Supplier supplier)
    {
        NorthwndContext db = new NorthwndContext();
        db.Suppliers.Add(supplier);
        db.SaveChanges();
        return Ok(db);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        NorthwndContext db = new NorthwndContext();
        Supplier supplier = db.Suppliers.FirstOrDefault(x => x.SupplierId == id);

        if(supplier == null)
        {
            return NotFound("Böyle bir supplier bulunamadı");
        }

        db.Suppliers.Remove(supplier);
        db.SaveChanges();
        return Ok("silme işlemi başarılı");
    }

    [HttpPut]
    public IActionResult Put(Supplier supplier)
    {
        NorthwndContext db = new NorthwndContext();

        Supplier entity = db.Suppliers.FirstOrDefault(x=>x.SupplierId == supplier.SupplierId);

        if (entity == null)
        {
            return NotFound();
        }

        entity.SupplierId = supplier.SupplierId;
        entity.CompanyName = supplier.CompanyName;
        entity.ContactName = supplier.ContactName;
        entity.ContactTitle = supplier.ContactTitle;

        db.SaveChanges();
        return Ok(entity);
    }
}
