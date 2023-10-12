namespace API.DTOs
{
    public class ProductsShapedObject
    {
        public int id { get; set; }
        public String prodName { get; set; }
        public String prodDescription { get; set; }
        public decimal prodPrice { get; set; }
        public String prodPicture { get; set; }
        public String productBrand  { get; set; }
        public String productType { get; set; }      
    }
}