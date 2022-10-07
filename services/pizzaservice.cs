using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using poyectox.models;
namespace poyectox.services
{
    public class pizzaservice
    {
      static List <pizza> pizzas {get;} 

      static int nextID = 3;

      static pizzaservice()
          {
         pizzas = new List<pizza>{
          new pizza {ID = 1, Name = "clasica queso", isglutenfree = false },
          new pizza {ID = 2, Name = "clasica queso y jamon", isglutenfree = false },   
          };
          }
          public static List<pizza> GetAll()=> pizzas; 

          public static pizza Get (int ID) =>pizzas.FirstOrDefault(p => p.ID == ID);

          public static void Add(pizza pizza)
          {
            pizza.ID = nextID++; 
            pizzas.Add(pizza);
          }


       }


 }
    