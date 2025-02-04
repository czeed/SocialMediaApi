using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.UserProfiles.Querries
{
    public class GetAllUserProfileQuery: IRequest<IEnumerable<UserProfile>>
    {

    }
}
