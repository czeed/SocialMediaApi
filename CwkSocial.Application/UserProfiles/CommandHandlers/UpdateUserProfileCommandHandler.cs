using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.UserProfiles.Commands;
using CwkSocial.DataAcces;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.UserProfiles.CommandHandlers
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;
        public UpdateUserProfileCommandHandler( DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        { 
            var result = new OperationResult<UserProfile>(); 

            try
            {
                var userProfile = await _ctx.UserProfiles
                .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);

                if(userProfile is null)
                {
                    result.IsError = true;
                    var error = new Error { Code = ErrorCodes.NotFound, Message = $"No user found with ID {request.UserProfileId}" };
                    result.Errors.Add(error);
                    return result;
                }

                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName,
                    request.Email, request.PhoneNumber, request.DayOfBirth, request.CurrentCity);

                userProfile.UpdateBasicInfo(basicInfo);

                _ctx.UserProfiles.Update(userProfile);
                await _ctx.SaveChangesAsync();

                result.Payload = userProfile;
            }

            catch (Exception ex)
            {
                result.IsError = true;
                var error = new Error
                {
                    Code = ErrorCodes.ServerError,
                    Message = ex.Message,
                };
                result.Errors.Add(error);  
            }
            
            

            return result;

        }
    }
}
