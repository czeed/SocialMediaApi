using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.PostAggregate
{
    public class PostInteraction
    {
        public Guid InteractionId { get; private set; }
        public Guid PostId { get; private set; }
        public InteractionType InteractionType { get; private set; }

        private PostInteraction()
        {
        }

        // FACTORIES
        public static PostInteraction CreatePostInteraction(Guid postId, InteractionType interactionType)
        {
            return new PostInteraction
            {
                PostId = postId,
                InteractionType = interactionType
            };
        }
    }
}
