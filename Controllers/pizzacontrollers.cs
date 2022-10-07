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
}
}