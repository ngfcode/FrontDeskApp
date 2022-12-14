using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontDeskApp.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public abstract class BaseController : ControllerBase
{
	private IMediator _mediator;
	protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
