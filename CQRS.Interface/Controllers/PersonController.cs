using CQRS.Application.Commands.PersonCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Interface.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task GetPersonList(CancellationToken cancellationToken)
        {
            return _mediator.Send(new PersonCommand(), cancellationToken);
        }
    }
}
