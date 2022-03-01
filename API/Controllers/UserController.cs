using Application.Commands;
using Application.Queries;
using Application.Responses;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<User>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("{name}")]
        public async Task<ActionResult<User>> GetUserByName(String name )
        {
            var user = await _mediator.Send(new GetUserByNameQuery { Name = name});
            if (user is null) return NotFound();
            return Ok(user);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> CreateNewUser([FromBody] CreateNewUserCommand command )
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
