using System.Net.Http.Headers;
using API.DTOs;
using API.ErrorsHandlers;
using AutoMapper;
using core.Controllers;
using core.Entities.DTOs;
using core.Interfaces;
using core.Specifications;
using infrastructure.data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

   
    public class ProdController: ApiControllerBase
    {
        private readonly IgenericInterfaceRepository<Products> _products;
        private readonly IgenericInterfaceRepository<ProductBrand> _productBrands;

         private readonly IgenericInterfaceRepository<ProductType> _productTypes;
          private readonly productContext  _context;
         private readonly IProductDetails _productDetails;

         private readonly IMapper _imapper;
          private readonly IWebHostEnvironment  _webhost;
        
        public ProdController(
            IgenericInterfaceRepository<Products> products,
            IgenericInterfaceRepository<ProductBrand> productBrands,
            IgenericInterfaceRepository<ProductType> productTypes,
            productContext context,
            IProductDetails productDetails,
            IMapper imapper,
            IWebHostEnvironment webhost)
                            {
                                _productTypes = productTypes;
                                _productBrands = productBrands;
                                _products = products;
                                _productDetails = productDetails;
                                _context=context;
                            _imapper = imapper;
                            _webhost = webhost;
                            }

        [HttpPost] 
        public async Task<ActionResult> UploadProductsUrlToDb(ProductDetails productsDetails)
        {                   
            var productDetailsFormated = new ProductDetails(){
                    prodName = productsDetails.prodName,
                    prodPicture = "/bags/"+productsDetails.prodPicture.Substring(12),
                    prodDescription = productsDetails.prodDescription,
                    prodPrice = productsDetails.prodPrice,
                    productBrandId = productsDetails.productBrandId,
                    productTypeId = productsDetails.productTypeId
            };
               await _productDetails.UploadProductAsync(productDetailsFormated);
                return Ok();             
        }   

        [HttpPost("savePicture")] //This endpoint save picture in the files folder
        public async Task<ActionResult> SaveProductsPicture()
        {     
            var file = Request.Form.Files[0];
             var folder = Path.Combine("files","bags");
             var pathToSave = Path.Combine(Directory.GetCurrentDirectory(),folder);

             if(file.Length>0){
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullpath = Path.Combine(pathToSave,fileName);
                var dbPath = Path.Combine(folder,fileName);

                using (var stream = new FileStream(fullpath, FileMode.Create)){
                         await   file.CopyToAsync(stream);
                }

                return Ok(new {dbPath});
                
             }

            return BadRequest();
          }
    
        [HttpDelete("{id}")] 
        public async Task<bool> DeleteProducts(int id)
        {
               await _productDetails.DeleteProductAsync(id);
                return true;             
        }  
        // [Cashing(600)]
        [HttpGet]
        public async Task<ActionResult<ProductsPagination<ProductsShapedObject>>> GetProducts(
            [FromQuery]ProductParameters parameters)//The [FromQuery] help the controller trace the parameter from the object passed
        {
             var countPageSpecification = new ProductSpecificationWithFilter(parameters);
             var totalProducts = await _products.CountPage(countPageSpecification);
             var specification = new GetProductsWithBrandAndType(parameters);
             var productsList = await _products.ListAllAsync(specification);
             var data = _imapper.Map<IReadOnlyList<Products>,
                             IReadOnlyList<ProductsShapedObject>>(productsList);
             return Ok(new ProductsPagination<ProductsShapedObject>
                (parameters.pageIndex,parameters.PageSize,totalProducts,data));
        }

        // [Cashing(600)]
        [HttpGet("{id}")]// Notice the curly braces
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Responses),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductsShapedObject>> GetProducts(int id)
        {
            var specification = new GetProductsWithBrandAndType(id);
            var product = await _products.GetProductsWithSpecification(specification);
            if(product==null) return NotFound(new Responses(400));
            return _imapper.Map<Products,ProductsShapedObject>(product);
        }

        // [Cashing(600)]
        [HttpGet("brands")] //No curly braces
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            var productBrandList=await _productBrands.ListAllAsync();          
            return Ok(productBrandList);
        }

        // [Cashing(600)]
        [HttpGet("types")] //No curly braces
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {
            var productTypeList = await _productTypes.ListAllAsync();
             return Ok(productTypeList);
        }   
}
}