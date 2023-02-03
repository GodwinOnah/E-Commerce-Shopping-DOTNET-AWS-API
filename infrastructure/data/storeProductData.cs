using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using core.Controllers;
using core.Entities;
using Microsoft.Extensions.Logging;


namespace infrastructure.data
{
    public class storeProductData
    {
        public static async Task storeProductsAsync(storeProducts context, ILoggerFactory ilogger){
            
            try{

                //This code read files, serialize them and save them to database

          


             if(!context.ProductBrand.Any()){

                    var productBrandsData=File.ReadAllText(
                        "../infrastructure/data/ProductsData/ProductBrands.json");

                    var brands=JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);

                    foreach(var y in brands){

                            context.ProductBrand.Add(y);

                    }
                        

                    await context.SaveChangesAsync();

            }

             if(!context.ProductType.Any()){

                    var productsTypesData=File.ReadAllText(
                        "../infrastructure/data/ProductsData/ProductTypes.json");

                    var types=JsonSerializer.Deserialize<List<ProductType>>(productsTypesData);


                    foreach(var z in types){

                            context.ProductType.Add(z);

                    }

                    await context.SaveChangesAsync();


            }

                    if(!context.Products.Any()){

                    var productsData=File.ReadAllText(
                        "../infrastructure/data/ProductsData/Products.json");

                    var products=JsonSerializer.Deserialize<List<Products>>(productsData);

                
                    foreach(var x in products){


                       

                       
                        context.Products.Add(x);

                    }

                    await context.SaveChangesAsync();
                    
            }
            
           

            }

            catch(Exception e){

               var logger= ilogger.CreateLogger<storeProductData>();

                logger.LogError(e.Message);


                // Console.WriteLine(55);


            }
            
        }
    }
}