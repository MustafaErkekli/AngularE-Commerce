using API.Core.DbModels.Identity;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extentions
{
	public static class IdentityServiceExtentions
	{
		public static IServiceCollection AddIdentityService(this IServiceCollection services)
		{
			var builder = services.AddIdentityCore<AppUser>();
			builder = new IdentityBuilder(builder.UserType, builder.Services);
			builder.AddEntityFrameworkStores<StoreContext>();
			builder.AddSignInManager<SignInManager<AppUser>>();
			services.AddAuthentication();

			return services;
		}
	}
}
