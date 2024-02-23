using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		//private readonly StoreContext _context;
		//private readonly IProductRepository _productRepository;
		private readonly IGenericRepository<Product> _productRepository;
		private readonly IGenericRepository<ProductBrand> _productBrandRepository;
		private readonly IGenericRepository<ProductType> _productTypeRepository;
		public ProductsController(IGenericRepository<Product> productRepository,
			IGenericRepository<ProductBrand> productBrandRepository,
			IGenericRepository<ProductType> productTypeRepository
			)
		{
			_productRepository = productRepository;
			_productBrandRepository = productBrandRepository;
			_productTypeRepository = productTypeRepository;
			//_context = context;
			//_productRepository = productRepository;
		}
		[HttpGet]
		public async Task<ActionResult<List<Product>>> GetProducts()
		{
			var data = await _productRepository.ListAllAsync();
			return Ok(data);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var data = await _productRepository.GetByIdAsync(id);
			return data;
		}
		[HttpGet("brands")]
		public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
		{
			var data = await _productBrandRepository.ListAllAsync();
			return Ok(data);
		}
		[HttpGet("types")]
		public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
		{
			var data = await _productTypeRepository.ListAllAsync();
			return Ok(data);
		}
	}
}
