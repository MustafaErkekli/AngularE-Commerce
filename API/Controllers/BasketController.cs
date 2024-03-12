using API.Core.DbModels;
using API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	//[ApiExplorerSettings(IgnoreApi = true)]
	public class BasketController : BaseApiController
	{
		private readonly IBasketRepository _basketRepository;

		public BasketController(IBasketRepository basketRepository)
		{
			_basketRepository = basketRepository;
		}
		[HttpGet]
		public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
		{
			var basket = await _basketRepository.GetBasketAsync(id);
			return Ok(basket ?? new CustomerBasket(id));
		}
		[HttpPost]
		public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
		{
			var updateBasket=await _basketRepository.UpdateBasketAsync(basket);
			return Ok(updateBasket);
		}
		[HttpPost("delete")]
		public async Task  DeleteBasketAsync(string id)
		{
			await _basketRepository.DeleteBasket(id);
		}
	}
}
