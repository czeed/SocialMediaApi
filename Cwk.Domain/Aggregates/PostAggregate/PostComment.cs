using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.PostAggregate
{
    public class PostComment
    {
        public Guid CommentId { get; private  set; }
        public Guid PostId { get; private set; }
        public string CommentText { get; private set; } = string.Empty;
        public Guid UserProfileId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastModified { get; private set; }

        public PostComment()
        {
            
        }

        // FACTORIES

        public static PostComment CreatePostCommand(Guid postId, string commentText, Guid userProfileId)
        {
            // TO DO : add valdation 

            return new PostComment
            {
                PostId = postId,
                CommentText = commentText,
                UserProfileId = userProfileId,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };
        }

        // piblic methods

        public void UpdateCommentText(string newText)
        {
            CommentText = newText;
            LastModified = DateTime.UtcNow;
        }
    }
}
