﻿using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

	[Route("error/{code}")]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class ErrorController : BaseApiController
	{
		public IActionResult Index(int code)
		{
			return new ObjectResult(new ApiResponse(code));
		}
	}
}
