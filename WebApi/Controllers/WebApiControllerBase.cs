﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MerchandisingManagement.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public abstract class WebApiControllerBase
	{
		public IMediator Mediator { get; set; }

	}
}
