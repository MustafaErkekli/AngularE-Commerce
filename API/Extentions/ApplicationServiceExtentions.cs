using API.Core.Interfaces;
using API.Infrastructure.Data;
using API.Infrastructure.Implements;
using API.Infrastructure.Services;

namespace API.Extentions
{
	public static class ApplicationServiceExtentions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IBasketRepository, BasketRepository>();
			return services;
		}
	}
}
