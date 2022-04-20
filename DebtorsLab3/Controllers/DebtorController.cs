using DebtorsLab3.Models;
using DebtorsLab3.Services;
using Microsoft.AspNetCore.Mvc;

namespace DebtorsLab3.Controllers;

[ApiController]
[Route("[controller]")]
public class DebtorController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Debtor>> GetAll()
    {
        return DebtorService.GetAll();
    }

    [HttpGet("{id:int}")]
    public ActionResult<Debtor> Get(int id)
    {
        var debtor = DebtorService.Get(id);
        
        return debtor != null ? debtor : NoContent();
    }

    [HttpPost]
    public IActionResult Create(Debtor debtor)
    {
        DebtorService.Add(debtor);
        return CreatedAtAction(nameof(Create), DebtorService.GetAll());
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Debtor debtor)
    {
        var existingDebtor = DebtorService.Get(id);
        if (existingDebtor is null)
            return NoContent();

        DebtorService.Update(debtor, id);

        return CreatedAtAction(nameof(Update), DebtorService.GetAll());
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var debtor = DebtorService.Get(id);

        if (debtor == null)
            return NoContent();

        DebtorService.Delete(id);

        return CreatedAtAction(nameof(Delete), DebtorService.GetAll());
    }
}