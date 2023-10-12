namespace core.Entities.Oders
{
    public class ShippingAddress
    {
        public ShippingAddress()
        {
        }

        public ShippingAddress(string firstName,string middleName,string lastName,string street, string city, string country, string zipcode, string phone)
{
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.street = street;
            this.city = city;
            this.country = country;
            this.zipcode = zipcode;
            this.phone = phone;
        }
             public string firstName {get; set;}
           public string? middleName {get; set;}
            public string lastName {get; set;}
             public string street {get; set;}
              public string city {get; set;}
               public string country{get; set;}
                public string zipcode {get; set;}
                 public string phone {get; set;}
        
    }
}