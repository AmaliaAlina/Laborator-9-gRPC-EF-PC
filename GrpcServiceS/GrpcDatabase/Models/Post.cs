using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcDatabase.Models
{
    public class Post
    {
        public Post()
        { }
        public Guid PostId { get; private set; }
        public string Description { get; private set; }
        public string Domain { get; private set; }
        public DateTime Date { get; private set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public static Post Create(string description, string domain, DateTime date)
        {
            return new Post()
            {
                PostId = Guid.NewGuid(),
                Description = description,
                Domain = domain,
                Date = date
            };
        }
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }
    }
}
