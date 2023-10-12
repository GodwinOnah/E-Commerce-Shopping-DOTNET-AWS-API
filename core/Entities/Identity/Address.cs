namespace core.Entities.Identity
{
    public class Address
    {
         public int Id {get; set;}
          public string firstName {get; set;}
           public string? middleName {get; set;}
            public string lastName {get; set;}
             public string street {get; set;}
              public string city {get; set;}
               public string country{get; set;}
                public string zipcode {get; set;}
                 public string phone {get; set;}
                 public string UserId {get; set;}
                  public User user {get; set;}
    }
    }
