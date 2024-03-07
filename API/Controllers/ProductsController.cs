using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Dtos;
using API.Helpers;
using API.Infrastructure.DataContext;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Controllers
{
	//[Route("api/[controller]")]
	//[ApiController]
	public class ProductsController : BaseApiController
	{

		private readonly IGenericRepository<Product> _productRepository;
		private readonly IGenericRepository<ProductBrand> _productBrandRepository;
		private readonly IGenericRepository<ProductType> _productTypeRepository;
		private readonly IMapper _mapper;
		public ProductsController(IGenericRepository<Product> productRepository,
			IGenericRepository<ProductBrand> productBrandRepository,
			IGenericRepository<ProductType> productTypeRepository,
			IMapper mapper
			)
		{
			_productRepository = productRepository;
			_productBrandRepository = productBrandRepository;
			_productTypeRepository = productTypeRepository;
			_mapper = mapper;

		}
		[HttpGet]
		public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
		{
			var spec = new ProductsWithProductTypeAndBrandsSpecification(productSpecParams);
			var countSpec = new ProductWithFilterForsCountSpecification(productSpecParams);
			var totalItems = await _productRepository.CountAsync(countSpec);
			var products =await _productRepository.ListAsync(spec);

			var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
			return Ok(new Pagination<ProductToReturnDto>(productSpecParams.PageIndex,productSpecParams.PageSize,totalItems,data));
		}
			
		[HttpGet("{id}")]
		public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
		{
			var spec = new ProductsWithProductTypeAndBrandsSpecification(id);
			//var data = await _productRepository.GetEntityWithSpec(spec);
			//return data;
			var product = await _productRepository.GetEntityWithSpec(spec);
			//return new ProductToReturnDto
			//{
			//	Id = product.Id,
			//	Name = product.Name,
			//	Description = product.Description,
			//	PictureUrl = product.PictureUrl,
			//	Price = product.Price,
			//	ProductBrand = product.ProductBrand != null ? product.ProductBrand.Name : string.Empty,
			//	ProductType = product.ProductType != null ? product.ProductType.Name : string.Empty
			//};
			return _mapper.Map<Product, ProductToReturnDto>(product);
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
