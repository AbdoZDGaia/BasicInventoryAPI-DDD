using Inventory.Api.ActionFilters;
using Inventory.Api.Services;
using Inventory.Domain.Domains.Products;
using Inventory.Domain.Interfaces;
using Inventory.Infrastructure;
using Inventory.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NLog;

namespace Inventory.Api.Extensions
{
    public static class BuilderExtensions
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var config = builder.Configuration;

            ConfigureJson(services);
            ConfigureSqlContext(services, config);
            ConfigureControllers(services);
            ConfigureCors(services);
            AddSwagger(services);
            AddDbFactory(services);
            AddAutoMapper(services);
            AddFilters(services);
            AddUoW(services);
            AddServices(services);
            AddLogging(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }

        private static void AddFilters(IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
        }

        private static void AddUoW(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddDbFactory(IServiceCollection services)
        {
            services.AddScoped<Func<InventoryDbContext>>((provider) => () => provider.GetService<InventoryDbContext>());
            services.AddScoped<DbFactory>();
        }

        public static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
        }

        private static void ConfigureControllers(IServiceCollection services)
        {
            NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
                new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
                .Services.BuildServiceProvider()
                .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>().First();

            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
                config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
            })
                .AddXmlDataContractSerializerFormatters();
        }

        private static void ConfigureSqlContext(IServiceCollection services, IConfiguration config)
        {
            services.AddSqlServer<InventoryDbContext>(
                config.GetConnectionString("SqlConnection"),
                options => options.MigrationsAssembly(typeof(Program).Assembly.GetName().Name));
        }

        private static void AddLogging(IServiceCollection services)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            services.AddSingleton<ILoggerManager, NLogLoggerManager>();
        }

        private static void ConfigureJson(IServiceCollection services)
        {
            services.Configure<JsonOptions>(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });
        }
        private static void AddSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Basic Inventory API", Version = "v1" });
            });
        }
    }
}
