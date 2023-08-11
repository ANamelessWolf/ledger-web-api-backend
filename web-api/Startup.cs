using System.IdentityModel.Tokens.Jwt;
using Nameless.LedgerWebApi.Installers;
using Nameless.Ledger.BI;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;
using Nameless.WebApi.Repositories;
using Nameless.Ledger.BI.Repositories.Implements;

namespace Nameless.LedgerWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public readonly string MyAllowSpecificOrigins;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MyAllowSpecificOrigins = Configuration.GetSection("AllowedHosts").Value;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            /*
            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", opt =>
            {
                opt.Authority = "https://localhost:44304/IdentityServerMX/";
                opt.RequireHttpsMetadata = false;                
                opt.Audience = "iMerchantMxAngular";
                opt.TokenValidationParameters = new TokenValidationParameters
                {                    
                    //RoleClaimType = "role"
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    //policy.RequireClaim("IntegrationMxApi");
                });
            });
            */

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins(MyAllowSpecificOrigins)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });


            services.InstallServicesInAssembly(Configuration);

            services.AddDbContext<NamelessBIContext>(
                    options => options.UseMySQL(Configuration.GetConnectionString("connectionStrig")));

            // repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(DbContext), typeof(NamelessBIContext));

            //Catalogues
            services.AddScoped(typeof(FinancingEntityRepository), typeof(FinancingEntityRepository));
            //Tables

            //Views

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowOrigin");
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers()
                  //  .RequireAuthorization("ApiScope")
                  ;
                });
            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.DocumentTitle = "Nameless - Ledger API";
                config.InjectJavascript("/swagger-ui/custom.js");
                config.InjectStylesheet("/swagger-ui/custom.css");
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "NamelessLedgerAPI");
            });

        }
    }
}
