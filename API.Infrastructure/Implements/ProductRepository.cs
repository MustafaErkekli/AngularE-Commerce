﻿using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Implements
{
	public class ProductRepository : IProductRepository
	{
		private readonly StoreContext _context;
		public ProductRepository(StoreContext context)
		{
			_context = context;
		}
		public async Task<Product> GetProductByIdAsync(int id)
		{
			return await _context.Products
				.Include(p => p.ProductBrand)
				.Include(p => p.ProductType)
				.FirstOrDefaultAsync(p => p.Id == id);
		}
		/// <summary>
		/// Tüm ürünleri listeler
		/// </summary>
		/// <returns></returns>
		public async Task<IReadOnlyList<Product>> GetProductAsync()
		{
			return await _context.Products
				.Include(p=>p.ProductBrand)
				.Include(p=>p.ProductType)
				.ToListAsync();
		}

		public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
		{
			return await _context.ProductTypes.ToListAsync();
		}

		public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
		{
			return await _context.ProductBrands.ToListAsync();	
		}
	}
}
