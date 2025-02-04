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
    public class GetAllUserProfileQueryHandler : IRequestHandler<GetAllUserProfileQuery, IEnumerable<UserProfile>>
    {

        private readonly DataContext _ctx;

        public GetAllUserProfileQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfileQuery request, CancellationToken cancellationToken)
        { 
           var profiles = await _ctx.UserProfiles.ToListAsync();

           return profiles;
        }
    }
}
