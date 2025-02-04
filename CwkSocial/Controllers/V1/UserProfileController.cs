using AutoMapper;
using CwkSocial.Api.Contracts.UserProfile.Requests;
using CwkSocial.Api.Contracts.UserProfile.Responses;
using CwkSocial.Application.Enums;
using CwkSocial.Application.UserProfiles.Commands;
using CwkSocial.Application.UserProfiles.Querries;
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
            var query = new GetAllUserProfileQuery();
            var response = await _mediator.Send(query);

            var profiles = _mapper.Map<List<UserProfileResponse>>(response);

            return Ok(profiles);    
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
           var query = new GetUserByIdQuery { UserProfileId = Guid.Parse(id)};
           var response = await _mediator.Send(query);
           
           if(response is null)
           {
               return NotFound($"No user with id: {id} found. ");
           }

           var userProfile = _mapper.Map<UserProfileResponse>(response);

           return Ok(userProfile);
        }

        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileUpdate profile)
        {
            var command = _mapper.Map<UpdateUserProfileCommand>(profile);
            command.UserProfileId = Guid.Parse(id);

            var response = await _mediator.Send(command);

            if ( response.IsError)
            {
                if (response.Errors.Any(er => er.Code == ErrorCodes.NotFound))
                {
                    var error = response.Errors.First( e => e.Code == ErrorCodes.NotFound);
                    return NotFound(error.Message);
                }

                if (response.Errors.Any(er => er.Code == ErrorCodes.ServerError))
                {
                    var error = response.Errors.First(e => e.Code == ErrorCodes.ServerError);
                    return StatusCode(500, error.Message);
                }

            }

            return NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserProfileCommand { UserProfileId = Guid.Parse(id)};

            var response = await _mediator.Send(command);

            return NoContent();
        }

    }
}
