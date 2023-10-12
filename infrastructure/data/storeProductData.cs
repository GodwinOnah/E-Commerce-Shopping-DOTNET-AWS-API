using System.Reflection;
using System.Text.Json;
using core.Controllers;
using core.Entities.Oders;
using Microsoft.Extensions.Logging;


namespace infrastructure.data
{
    public class StoreProductData
    {
        public static async Task storeProductsAsync(productContext context, ILoggerFactory ilogger){
            
            try{

                //This code read files, serialize them and save them to database

            //     var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //  if(!context.ProductBrand.Any()){
            //         var productBrandsData=File.ReadAllText(
            //             path+@"/data/ProductsData/ProductBrands.json");
            //         var brands=JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);
            //         foreach(var y in brands){
            //               context.ProductBrand.AddRange(y);
            //         }
            //         await context.SaveChangesAsync();
            // }

            //  if(!context.ProductType.Any()){
            //         var productsTypesData=File.ReadAllText(
            //             path+@"/data/ProductsData/ProductTypes.json");
            //         var types=JsonSerializer.Deserialize<List<ProductType>>(productsTypesData);
            //         foreach(var z in types){
            //                 context.ProductType.AddRange(z);
            //         }
            //         await context.SaveChangesAsync();
            // }

            // if(!context.Products.Any()){
            //         var productsData=File.ReadAllText(
            //             path+@"/data/ProductsData/Products.json");
            //         var products=JsonSerializer.Deserialize<List<Products>>(productsData);              
            //      foreach(var x in products){          
            //             context.Products.AddRange(x);
            //         }
            //         await context.SaveChangesAsync();
            //           }          

            //  if(!context.Delivery.Any()){
            //         var deliveries=File.ReadAllText(
            //             path+@"/data/ProductsData/Delivery.json");
            //         var delivery=JsonSerializer.Deserialize<List<Delivery>>(deliveries);              
            //      foreach(var x in delivery){          
            //             context.Delivery.AddRange(x);
            //         }
            //         await context.SaveChangesAsync();
            //           }          }

            // catch(Exception e){
            //    var logger= ilogger.CreateLogger<StoreProductData>();
            //     logger.LogError(e.Message);

             if(!context.ProductBrand.Any()){
                    var productBrandsData=File.ReadAllText(
                        "../infrastructure/data/ProductsData/ProductBrands.json");
                    var brands=JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);
                    foreach(var y in brands){
                          context.ProductBrand.AddRange(y);
                    }
                    await context.SaveChangesAsync();
            }

             if(!context.ProductType.Any()){
                    var productsTypesData=File.ReadAllText(
                        "../infrastructure/data/ProductsData/ProductTypes.json");
                    var types=JsonSerializer.Deserialize<List<ProductType>>(productsTypesData);
                    foreach(var z in types){
                            context.ProductType.AddRange(z);
                    }
                    await context.SaveChangesAsync();
            }

            if(!context.Products.Any()){
                    var productsData=File.ReadAllText(
                        "../infrastructure/data/ProductsData/Products.json");
                    var products=JsonSerializer.Deserialize<List<Products>>(productsData);              
                 foreach(var x in products){          
                        context.Products.AddRange(x);
                    }
                    await context.SaveChangesAsync();
                      }          

             if(!context.Delivery.Any()){
                    var deliveries=File.ReadAllText(
                        "../infrastructure/data/ProductsData/Delivery.json");
                    var delivery=JsonSerializer.Deserialize<List<Delivery>>(deliveries);              
                 foreach(var x in delivery){          
                        context.Delivery.AddRange(x);
                    }
                    await context.SaveChangesAsync();
                      }          }

            catch(Exception e){
               var logger= ilogger.CreateLogger<StoreProductData>();
                logger.LogError(e.Message);

            }
            
        }
    }
}