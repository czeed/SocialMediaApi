using AutoMapper;
using CwkSocial.Application.UserProfiles.Commands;
using CwkSocial.DataAcces;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.UserProfiles.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        private readonly DataContext _ctx;
       

        public CreateUserCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
          
        }
        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName,
                request.Email, request.PhoneNumber, request.DayOfBirth, request.CurrentCity); 

            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);

            await _ctx.UserProfiles.AddAsync(userProfile);

            await _ctx.SaveChangesAsync();


            return userProfile;
        }
    }
}
