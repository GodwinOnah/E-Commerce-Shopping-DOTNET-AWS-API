namespace core.Entities.Oders
{
    public class ProductOrdered
    {
        public ProductOrdered()
        {
        }

        public ProductOrdered(int id, string prodName, string prodPicture)
        {
            this.id = id;
            this.prodName = prodName;
            this.prodPicture = prodPicture;
        }

        public int id { get; set; }
        public string prodName { get; set; }
        public string prodPicture { get; set; }
        
    }
}