namespace core.Entities.Oders
{
    public class ItemOrdered : ProductEntities
    {
        public ItemOrdered()
        {
        }

        public ItemOrdered(ProductOrdered productOrdered, decimal itemPrice, int itemQuntity)
        {
            this.productOrdered = productOrdered;
            this.itemPrice = itemPrice;
            this.quantity = itemQuntity;
        }

        public ProductOrdered productOrdered {get; set;}
         public decimal itemPrice {get; set;}
          public int  quantity {get; set;}
    }
}