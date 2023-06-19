using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => 
        PizzaService.GetAll();


    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id) {
        // The var keyword instructs the compiler to infer the type of the variable from the expression on the right side of the initialization statement.
        var pizza = PizzaService.Get(id);
        if (pizza == null) {
            return NotFound();
        }
        return pizza;
    }
        

    // POST action
    // Lets the client know if the request succeeded 
    // and provides the ID of the newly created pizza.
    [HttpPost]
    public IActionResult Create(Pizza pizza) {
        PizzaService.Add(pizza);
        // uses the action name to generate a location HTTP response header with a URL to the newly created pizza
        return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
    }

    // PUT action: modify ot update a pizza in the inventory
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza) {
        if (id != pizza.Id) {
            return BadRequest();
        }
        var existingPizza = PizzaService.Get(id);
        if (existingPizza == null) {
            return NotFound();
        }

        PizzaService.Update(pizza);
        return NoContent();
     }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        var existingPizza = PizzaService.Get(id);
        if (existingPizza == null) {
            return NotFound();
        }
        PizzaService.Delete(id);
        return NoContent();
    }
}



// Post request 