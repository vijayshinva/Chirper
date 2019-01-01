using Chirper.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;

namespace Chirper.Domain.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubscribeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // POST: api/Subscribe
        [HttpPost]
        public HttpResponseMessage Post([FromBody] string value)
        {
            _mediator.Publish(new SubscribeToChirpUser(12345, "test@test.com"));
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }
    }
}
