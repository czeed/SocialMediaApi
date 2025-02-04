using CwkSocial.Application.UserProfiles.Querries;
using CwkSocial.DataAcces;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.UserProfiles.QuerryHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserProfile>
    {
        private readonly DataContext _ctx;

        public GetUserByIdQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<UserProfile> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await _ctx.UserProfiles.FirstOrDefaultAsync(user => user.UserProfileId == request.UserProfileId);

            return profile;
        }
    }
}
