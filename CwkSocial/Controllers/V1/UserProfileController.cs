using AutoMapper;
using CwkSocial.Api.Contracts.Common;
using CwkSocial.Api.Contracts.UserProfile.Requests;
using CwkSocial.Api.Contracts.UserProfile.Responses;
using CwkSocial.Api.Filters;
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
    public class UserProfileController : BaseController
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

            throw new NotImplementedException("not implemented");
            var query = new GetAllUserProfileQuery();
            var response = await _mediator.Send(query);

            var profiles = _mapper.Map<List<UserProfileResponse>>(response.Payload);

            return Ok(profiles);    
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreate profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            var response = await _mediator.Send(command); 
            var userProfil = _mapper.Map<UserProfileResponse>(response.Payload);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = response.Payload.UserProfileId }, userProfil);
        }

        [HttpGet]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
           var query = new GetUserByIdQuery { UserProfileId = Guid.Parse(id)};
           var response = await _mediator.Send(query);
           
           if(response.IsError)
           {
               return HandleErrorResponse(response.Errors);
           }

           var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);

           return Ok(userProfile);
        }

        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [ValidateModel]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileUpdate profile)
        {
            var command = _mapper.Map<UpdateUserProfileCommand>(profile);
            command.UserProfileId = Guid.Parse(id);

            var response = await _mediator.Send(command);

            if ( response.IsError)
            {
              return HandleErrorResponse(response.Errors);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserProfileCommand { UserProfileId = Guid.Parse(id)};

            var response = await _mediator.Send(command);

            return response.IsError ? HandleErrorResponse(response.Errors) : NoContent();
        }

    }
}
