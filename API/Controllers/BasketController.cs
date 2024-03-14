using API.Core.DbModels;
using API.Core.Interfaces;
using API.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	//[ApiExplorerSettings(IgnoreApi = true)]
	public class BasketController : BaseApiController
	{
		private readonly IBasketRepository _basketRepository;
		private readonly IMapper _mapper;

		public BasketController(IBasketRepository basketRepository,IMapper mapper)
		{
			_basketRepository = basketRepository;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
		{
			var basket = await _basketRepository.GetBasketAsync(id);
			return Ok(basket ?? new CustomerBasket(id));
		}
		[HttpPost]
		public async Task<ActionResult<CustomerBasketDto>> UpdateBasket(CustomerBasketDto basket)
		{
			var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
			var updateBasket=await _basketRepository.UpdateBasketAsync(customerBasket);
			return Ok(updateBasket);
		}
		[HttpPost("delete")]
		public async Task  DeleteBasketAsync(string id)
		{
			await _basketRepository.DeleteBasket(id);
		}
	}
}
