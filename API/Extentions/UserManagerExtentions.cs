using API.Core.DbModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Extentions
{
	public static class UserManagerExtentions
	{
		public static async Task<AppUser> FindByUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> input ,ClaimsPrincipal user)
		{
			var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
			return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
		}

		public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user)
		{
			var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
			return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
		}
	}
}
