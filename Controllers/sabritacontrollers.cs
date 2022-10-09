using poyectox.services;
using poyectox.models;
using Microsoft.AspNetCore.Mvc;


namespace poyectox.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class sabritacontrollers : ControllerBase
{
    public sabritacontrollers()
    {
        
    }
 
     [HttpGet]
     public ActionResult<List<sabrita>> GetAll() => sabritaservice.GetAll();
     
     [HttpGet("{id}")]
     public ActionResult<sabrita> Get (int id)

      {
     var sabrita = sabritaservice.Get(id);
     if(sabrita == null)

      
         return NotFound();
         return sabrita;
        
    }
       [HttpPost]
       public IActionResult create (sabrita sabrita)
        {
            sabritaservice.Add(sabrita);

            return CreatedAtAction(nameof(create),new{ID = sabrita},sabrita);

         }

         [HttpDelete("{id}")]
         public IActionResult Delete(int id)
         {
            var sabrita = sabritaservice.Get(id);
            if(sabrita is null)
            return NotFound();

            sabritaservice.Delete(id);
            return NoContent();
         }

         [HttpPut("{ID}")]
         public IActionResult update(int ID,sabrita sabrita)
         {
            if (ID != sabrita.ID)
            return BadRequest();

            var existingsabrita = sabritaservice.Get(ID);
            if (existingsabrita is null)
            return NotFound();

            sabritaservice.update(sabrita);

            return NoContent();
         }
}
}