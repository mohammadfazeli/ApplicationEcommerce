using Core.InterFace;
using Core.Specefication;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Helper
{
    public static class DependecyInjectionExtention
    {

        public static IServiceCollection ConfigDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ISpecefication<>), typeof(BaseSpecefication<>));

            return services;
        }
    }
}
