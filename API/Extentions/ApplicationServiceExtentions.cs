using API.Core.Interfaces;
using API.Infrastructure.Implements;

namespace API.Extentions
{
	public static class ApplicationServiceExtentions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IBasketRepository, BasketRepository>();
			return services;
		}
	}
}
