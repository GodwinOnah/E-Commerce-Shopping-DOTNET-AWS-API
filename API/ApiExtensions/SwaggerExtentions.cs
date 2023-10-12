using Microsoft.OpenApi.Models;

namespace API.ApiExtensions
{
    public static class SwaggerExtentions
    {

         public static IServiceCollection AddSwaggerDocumentation(
            this IServiceCollection  services){
                
                services.AddEndpointsApiExplorer();

                services.AddSwaggerGen(c=>{

                    var SecurityScema = new OpenApiSecurityScheme{
                            Description = "JWT Bearer Scheme",
                             Name = "Authorization",
                             In = ParameterLocation.Header,
                               Type = SecuritySchemeType.Http,
                                Scheme = "Bearer",
                                 Reference = new OpenApiReference{
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                        }
                    };

                    c.AddSecurityDefinition("Bearer", SecurityScema);

                    var SecuriryRequirement = new OpenApiSecurityRequirement{
                        {
                           SecurityScema, new[]{"Bearer"}
                        }
                    };

                    c.AddSecurityRequirement(SecuriryRequirement);
                }

                );

                return services;

         }


         public static IApplicationBuilder UseSwaggerDocumentation(this  IApplicationBuilder  app){

                app.UseSwagger();//available for both production and development mode
                app.UseSwaggerUI();//available for both production and development mode

               
                return app;
        
    }
}
}