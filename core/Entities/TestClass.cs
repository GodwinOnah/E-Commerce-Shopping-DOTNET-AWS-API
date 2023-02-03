using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class TestClass
    {

        public TestClass(string id)
        {
            Id = id;
        }

         public string Id {get; set;}

       
         public List<TestClass2> testClass2 {get; set;}
                      = new List<TestClass2>();
    
       
          }

          public interface TestClass2{

        public int Id {get; set;}
        public string Name {get; set;}

         public decimal Price {get; set;}

         public int Quantity {get; set;}

       


          }

          public class TestClass3{

                TestClass test=new TestClass("3");

          }
    

        
    }
