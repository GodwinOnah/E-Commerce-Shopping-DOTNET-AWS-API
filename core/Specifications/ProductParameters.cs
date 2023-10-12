namespace core.Specifications
{
    public class ProductParameters
    {
        private const int maxPage=10;
        public int pageIndex {get; set;}=1;

        private int pageSize=8;

        public int PageSize
        {
            get=>pageSize;
            set=>pageSize=(value<maxPage)?value:maxPage;
        }

        public int? brandId {get; set;}

        public int? typeId {get; set;}

        public string sort {get; set;}

        public string search;

         public string Search
        {
            get=>search;
            set=>search=value.ToLower();
            

        }





    }
}