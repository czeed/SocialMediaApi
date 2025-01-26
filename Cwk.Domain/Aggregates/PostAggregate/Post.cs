using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.PostAggregate
{
    public class Post
    {

        private readonly List<PostComment> _comments = new List<PostComment>();
        private readonly List<PostInteraction> _interactions = new List<PostInteraction>();

        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public string TextContent { get; private set; } = string.Empty;
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModified { get; private set;}
        public IEnumerable<PostComment> Comments { get { return _comments; } }
        public IEnumerable<PostInteraction> Interaction { get { return _interactions; } }

        private Post()
        {
        }


        // FACTORIES
        public static Post CreatePost(Guid userProfileId, string textContent)
        {
            return new Post
            {
                UserProfileId = userProfileId,
                TextContent = textContent,
                CreatedDate = DateTime.Now,
                LastModified = DateTime.Now,
            };
        }

        // public methods
        public void UpdatePostText(string newText)
        {
            TextContent = newText;
            LastModified = DateTime.UtcNow;
        }

        public void AddPostComment(PostComment newComment) 
        { 
           _comments.Add(newComment);
        }

        public void RemovePostComment(PostComment comment)
        {
            _comments.Remove(comment);
        }

        public void AddInteraction(PostInteraction interaction)
        {
            _interactions.Add(interaction); 
        }

        public void RemoveInteraction(PostInteraction interaction)
        {
            _interactions.Remove(interaction);
        }
    }
}
