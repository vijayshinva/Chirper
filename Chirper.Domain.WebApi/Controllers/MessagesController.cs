using Chirper.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;

namespace Chirper.Domain.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Messages
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Messages/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Messages
        [HttpPost]
        public HttpResponseMessage Post([FromBody] string value)
        {
            _mediator.Publish(new PostMessage(12345, "test@test.com", value));
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
