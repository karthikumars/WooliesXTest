using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Shopping.Api.Infrastructure;
using Shopping.Models;
using Shopping.Repositories;
using Shopping.Repositories.Interfaces;
using Shopping.Services;
using Shopping.Services.Interfaces;
using Shopping.Services.ProductsSorting;
using System.IO;
using System.Text.Json.Serialization;

namespace ShoppingApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddApplicationInsightsTelemetry();

            services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Shopping.Api.xml");
                c.IncludeXmlComments(filePath, includeControllerXmlComments: true);
            });

            services.Configure<WooliesXApiDetail>(options => Configuration.GetSection("WooliesXApiDetail").Bind(options));

            services.AddTransient<IShoppingService, ShoppingService>();
            services.AddTransient<IShoppingRepository, ShoppingRepository>();
            services.AddTransient<IProductSorter, ProductSorter>();
            services.AddTransient<IProductSortingStrategy, ProductsSortingByName>();
            services.AddTransient<IProductSortingStrategy, ProductsSortingByPrice>();
            services.AddTransient<IProductSortingStrategy, ProductsSortingByRecommended>();
            services.AddTransient<ITrolleyTotalCalculator, TrolleyTotalCalculator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}