using API.Core.DbModels;
namespace API.Core.Interfaces
{
	public interface IProductRepository
	{
		/// <summary>
		/// Returns one product by id #mustafa
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Product> GetProductByIdAsync(int id);

		/// <summary>
		/// lists all products#mustafa
		/// </summary>
		/// <returns></returns>
		Task<IReadOnlyList<Product>> GetProductAsync(); //IReadOnlyList=> değişikliklerin yapılamayacağı çoklu kayıtların tutulacağı liste
		Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
		Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
	}
}
