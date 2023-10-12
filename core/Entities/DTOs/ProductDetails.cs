namespace core.Entities.DTOs
{
    public class ProductDetails 
    {
        public ProductDetails()
        {
        }

        public ProductDetails(string prodName, string prodPicture, string prodDescription
        , decimal prodPrice, int productBrandId, int productTypeId  )
        {
            this.prodName = prodName;
            this.prodPicture = prodPicture;
            this.prodDescription = prodDescription;
            this.prodPrice = prodPrice;
            this.productBrandId = productBrandId;
            this.productTypeId = productTypeId;
        }

        public String prodName { get; set; }
         public String prodPicture { get; set; }
        public String prodDescription { get; set; }
        public decimal prodPrice { get; set; }
        public int productBrandId  { get; set; }
        public int productTypeId { get; set; } 
       
    }
    }
