using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using poyectox.services;
using poyectox.models;
using Microsoft.AspNetCore.Mvc;


namespace poyectox.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class pizzacontrollers : ControllerBase
{
    public pizzacontrollers()
    {
        
    }
 
     [HttpGet]
     public ActionResult<List<pizza>> GetAll() => pizzaservice.GetAll();
     
     [HttpGet("{id}")]
     public ActionResult<pizza> Get (int id)

      {
     var pizza = pizzaservice.Get(id);
     if(pizza == null)

      
         return NotFound();
         return pizza;
        
    }
       [HttpPost]
       public IActionResult create (pizza pizza)
        {
            pizzaservice.Add(pizza);

            return CreatedAtAction(nameof(create),new{ID = pizza},pizza);

         }

         [HttpDelete("{id}")]
         public IActionResult Delete(int id)
         {
            var pizza = pizzaservice.Get(id);
            if(pizza is null)
            return NotFound();

            pizzaservice.Delete(id);
            return NoContent();
         }

         [HttpPut("{ID}")]
         public IActionResult update(int ID,pizza pizza)
         {
            if (ID != pizza.ID)
            return BadRequest();

            var existingpizza = pizzaservice.Get(ID);
            if (existingpizza is null)
            return NotFound();

            pizzaservice.update(pizza);

            return NoContent();
         }
}
}