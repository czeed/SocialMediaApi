using AutoMapper;
using CwkSocial.Api.Contracts.UserProfile.Requests;
using CwkSocial.Api.Contracts.UserProfile.Responses;
using CwkSocial.Application.UserProfiles.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CwkSocial.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class UserProfileController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserProfileController( IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            return (IActionResult)Task.FromResult(Ok());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreate profile)
        {
           var command = _mapper.Map<CreateUserCommand>(profile);
           
            var response = await _mediator.Send(command); 

            var userProfil = _mapper.Map<UserProfileResponse>(response);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = response.UserProfileId }, userProfil);
        }

        [HttpGet]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            return Ok(new { id });
        }

    }
}
