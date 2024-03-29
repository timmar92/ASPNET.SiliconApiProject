using Microsoft.OpenApi.Models;

namespace WebApi.Config;

public static class SwaggerConfig
{
    public static void RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo { Title = "Silicon Web Api", Version = "v1" });

            //API Key
            x.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Query,
                Type = SecuritySchemeType.ApiKey,
                Name = "key",
                Description = "Enter API-Key"
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        }
                    },
                    Array.Empty<string>()
                }
            });

        });
    }
}
