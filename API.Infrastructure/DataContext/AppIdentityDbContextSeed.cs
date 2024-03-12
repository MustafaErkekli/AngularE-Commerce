using API.Core.DbModels.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.DataContext
{
	public class AppIdentityDbContextSeed
	{
		public static async Task SeedUserAsync(UserManager<AppUser> userManager)
		{
		
			if(!userManager.Users.Any())
			{
				var user = new AppUser
				{
					DisplayName = "Mustafa",
					Email = "emustafaerkekli.ee@gmail.com",
					UserName = "emustafaerkekli.ee@gmail.com",
					Address = new Address
					{
						FirstName = "Mustafa",
						LastName = "Erkekli",
						Street = "Nazar Sokak",
						City = "Ankara",
						State = "TR",
						ZipCode = "06500"
					}
				};
				await userManager.CreateAsync(user,"Ankara123*");
			}
		}
	}
}
