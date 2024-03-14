using API.Core.DbModels.Identity;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extentions
{
	public static class IdentityServiceExtentions
	{
		public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration config)
		{
			var builder = services.AddIdentityCore<AppUser>();
			builder = new IdentityBuilder(builder.UserType, builder.Services);
			builder.AddEntityFrameworkStores<StoreContext>()
				.AddDefaultTokenProviders();
			builder.AddSignInManager<SignInManager<AppUser>>();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					{
						options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
						{
							ValidateIssuerSigningKey = true,
							IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
							ValidIssuer = config["Token:Issuer"],
							ValidateAudience = false,
							ValidateIssuer = false
						};
					});


			return services;
		}
	}
}
