using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Serializers;
using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Services.BrandServices;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.FeatureServices;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.OfferDiscountServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOfferServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
           services.AddScoped<ICategoryService, CategoryService>();
           services.AddScoped<IProductService, ProductService>();
           services.AddScoped<IProductDetailService, ProductDetailService>();
           services.AddScoped<IProductImageService, ProductImageService>();
           services.AddScoped<IFeatureSliderService, FeatureSliderService>();
           services.AddScoped<ISpecialOfferService, SpecialOfferService>();
           services.AddScoped<IFeatureService, FeatureService>();
           services.AddScoped<IOfferDiscountService, OfferDiscountService>();
           services.AddScoped<IBrandService, BrandService>();
           services.AddScoped<IAboutService, AboutService>();
        }

        public static void ConfigureAuthentication(this IServiceCollection services , IConfiguration configuration) 
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = configuration["IdentityServerUrl"];
                opt.Audience = "ResourceCatalog";
            });
        }
        
        public static void ConfigureDatabaseSettings (this IServiceCollection services , IConfiguration configuration )
        {
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));

            services.AddScoped<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

        }
    }
}
