using FruitSA.Repository.UserRepository;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Smartproduct.Interface.Category;
using Smartproduct.Interface.File;
using Smartproduct.Interface.Product;
using Smartproduct.Interface.User;
using Smartproduct.Repository.Category;
using Smartproduct.Repository.File;
using Smartproduct.Repository.Product;

namespace Smartproduct.Api
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureTransient(this IServiceCollection services)
        {
            services.AddTransient<IExternalUser, ExternalUserRepository>();
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IFile, FileRepository>();
        }

        public static void ConfigureOutputFormatters(this IServiceCollection services)
        {
            services.AddControllers(opt => // or AddMvc()
            {
                // remove formatter that turns nulls into 204 - No Content responses
                // this formatter breaks Angular's Http response JSON parsing
                opt.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            });
        }
    }
}
