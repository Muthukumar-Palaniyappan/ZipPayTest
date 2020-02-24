using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZipPay.Business.Messages.Commands;
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
        [ProducesResponseType(typeof(List<UserDetail>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<UserDetail>>> GetUserList()
        {
            return Ok(await _mediator.Send(new GetUserListQuery()));
        }

        // GET api/user/doe@pubmail.com
        [HttpGet("{emailAddress}")]
        [ProducesResponseType(typeof(UserDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDetail>> GetUserByEmail(string emailAddress)
        {
            return Ok(await _mediator.Send(new GetUserByEmailQuery(emailAddress)));
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(UserDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDetail>> Post([FromBody] User user)
        {
            return Ok(await _mediator.Send(new CreateUserCommand(user)));
        }

    }
}
