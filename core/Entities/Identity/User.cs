using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace core.Entities.Identity
{
    public class User : IdentityUser
    {

        public string userName {get; set;}

         public Address address {get; set;}
        
    }

    public class Address
    {

         public string Id {get; set;}
          public string FirstName {get; set;}
           public string MiddleName {get; set;}
            public string LastName {get; set;}
             public string street {get; set;}
              public string city {get; set;}
               public string country{get; set;}
                public string zipcode {get; set;}

                 public string userId {get; set;}
                  public User user {get; set;}
    }
}