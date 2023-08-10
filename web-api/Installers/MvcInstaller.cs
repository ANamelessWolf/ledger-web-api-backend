using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Nameless.LedgerWebApi.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ledger Web api",
                    Description = "<p><b>Ledger web api</b></p><p>API encargada de manejar la integración de datos</p>",
                    Contact = new OpenApiContact
                    {
                        Name = "Ledger API",
                        Url = new Uri("https://github.com/anamelesswolf")
                    }
                });
                /*
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
                */
            });
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
