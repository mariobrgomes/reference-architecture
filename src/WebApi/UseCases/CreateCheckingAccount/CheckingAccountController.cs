using Application.CreateCheckingAccount;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApi.UseCases.CreateCheckingAccount
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingAccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckingAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create a checking account.
        /// </summary>
        /// <response code="200">The closed account id.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to Close an Account.</param>
        /// <returns>The account id.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateCheckingAccountResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody][Required] CreateCheckingAccountRequest request)
        {
            var input = new CreateCheckingAccountInput(request.TradingAccount, request.Brand,
                request.FullName, request.PhoneNumber);

            var result = await _mediator.Send(input);
            
            return null;
        }
    }
}
