using System.Reflection;
using API.Application.Jobs;
using API.Application.Services;

namespace API.Application
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ILogJob, LogJob>();
        }
    }
}
