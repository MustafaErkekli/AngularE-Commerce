using Data.API.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Data.API.DataContext
{
	public class StoreContext : DbContext
	{
		public StoreContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Product>Products { get; set; }
	}
}
