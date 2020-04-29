using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcDatabase.Models
{
    public class Comment
    {
        public Comment()
        { }
        public Guid CommentId { get; set; }
        public string Text { get; set; }

        public Post Post { get; set; }

        public static Comment Create(string text)
        {
            return new Comment()
            {
                CommentId = Guid.NewGuid(),
                Text = text,
            };
        }
    }
}
