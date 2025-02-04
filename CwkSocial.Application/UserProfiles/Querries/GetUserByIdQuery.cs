using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;


namespace CwkSocial.Application.UserProfiles.Querries
{
    public class GetUserByIdQuery : IRequest<UserProfile>
    {
        public Guid UserProfileId { get; set; }
    }
}
