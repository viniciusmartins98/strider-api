using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Strider.BackEnd.Api.Controllers
{
    public abstract class ApiControllerBase<T> : ControllerBase
    {
        public IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
