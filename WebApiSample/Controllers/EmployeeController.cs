using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.Models;

namespace WebApiSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        NorthwndContext db = new NorthwndContext();
        List<Employee> employees = db.Employees.ToList();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        NorthwndContext db = new NorthwndContext();
        Employee employee = db.Employees.FirstOrDefault(x => x.EmployeeId == id);

        if (employee == null)
        {
            return NotFound("Böyle bir employee mevcut değil");
        }

        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Post(Employee employee)
    {
        NorthwndContext db = new NorthwndContext();
        db.Employees.Add(employee);
        db.SaveChanges();

        return Ok("Ekleme işlemi başarılı");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        NorthwndContext db = new NorthwndContext();
        Employee employee = db.Employees.Find(id);

        if (employee == null)
        {
            return NotFound("Böyle bir employee bulunamadı");
        }

        db.Employees.Remove(employee);
        db.SaveChanges();
        return Ok("işlem başarılı");
    }

    [HttpPut]
    public IActionResult Put(Employee employee)
    {
        NorthwndContext db = new NorthwndContext();

        // öncelikle güncellenecek datayı buluyoruz
        Employee entity = db.Employees.FirstOrDefault(q=>q.EmployeeId == employee.EmployeeId);

        entity.FirstName= employee.FirstName;
        entity.LastName= employee.LastName;
        entity.Title= employee.Title;
        db.SaveChanges();

        return Ok("Güncelleme işlemi başarılı");
    }
}
