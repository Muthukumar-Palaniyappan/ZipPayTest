using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZipPay.Business.Messages.Queries;
using ZipPay.DataContract;

namespace ZipPay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
         _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

 
        // GET api/user
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUserList()
        {
            return await _mediator.Send(new GetUserListQuery());
        }

        // GET api/user/doe@pubmail.com
        [HttpGet("{emailAddress}")]
        public async Task<ActionResult<User>> GetUserByEmail(string emailAddress)
        {
            return await _mediator.Send(new GetUserByEmailQuery(emailAddress));
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
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
