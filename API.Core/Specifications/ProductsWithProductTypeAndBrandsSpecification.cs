using API.Core.DbModels;

namespace API.Core.Specifications
{
	public class ProductsWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
	{
		//x.Name.ToLower().Contains(productSpecParams.Search)
		public ProductsWithProductTypeAndBrandsSpecification(ProductSpecParams productSpecParams)
			: base(x =>
			(string.IsNullOrWhiteSpace(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)|| x.Description.ToLower().Contains(productSpecParams.Search))
			&&
			(!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
			&&
			(!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId)
			)
			

		{
			AddInclude(p => p.ProductBrand);
			AddInclude(x => x.ProductType);
			//AddOrderBy(x => x.Name);

			ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

			if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
			{
				switch (productSpecParams.Sort)
				{
					case "priceAsc":
						AddOrderBy(p => p.Price);
						break;
					case "priceDesc":
						AddOrderByDescending(p => p.Price);
						break;
					default:
						AddOrderBy(p => p.Name);
						break;
				}
			}
		}
		public ProductsWithProductTypeAndBrandsSpecification(int id) : base(x => x.Id == id)
		{
			AddInclude(p => p.ProductBrand);
			AddInclude(x => x.ProductType);
		}
	}
}
