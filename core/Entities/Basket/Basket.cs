using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace core
{
    public class Basket
    {
        public Basket()
        {

       }
        public Basket(string id)
        {
            Id = id;
        }

         public string Id {get; set;}
        public List<BasketItems> Items {get; set;}
                      = new List<BasketItems>();
    
       

 
       
          }

   
}