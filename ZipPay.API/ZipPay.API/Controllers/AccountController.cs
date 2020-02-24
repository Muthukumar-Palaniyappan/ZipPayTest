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
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
         _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET api/account
        [HttpGet]
        [ProducesResponseType(typeof(List<AccountDetail>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<AccountDetail>>> GetAccountList()
        {
            return Ok(await _mediator.Send(new GetAccountListQuery()));
        }


        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(AccountDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDetail>> Post([FromBody] Account account)
        {
            return Ok(await _mediator.Send(new CreateAccountCommand(account)));
        }

    }
}
