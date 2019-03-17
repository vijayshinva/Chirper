using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chirper.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chirper.WebApi.Messages.Controllers
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
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _mediator.Publish(new PostMessage(12345, "53C0FDDF-666A-4D52-BAF9-3D09147B2581", value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
