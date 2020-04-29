using System;
using System.Collections.Generic;
using System.Text;
using GrpcDatabase.Exceptions;
using GrpcDatabase.Models;
using System.Linq;

namespace GrpcDatabase
{
    class DataBaseAPI
    {
        public static Post AddPost(Post post)
        {
            using DataBaseContext context = new DataBaseContext();
            context.Posts.Add(post);
            context.SaveChanges();
            return post;
        }
        public static Post UpdatePost(Post newPost)
        {
            throw new NotImplementedException();
        }
        public static void DeletePost(Guid id)
        {
            using DataBaseContext context = new DataBaseContext();
            Post post = GetPostById(id);
            if (post == null)
                throw new NoFoundException();
            context.Posts.Remove(post);
            context.SaveChanges();
        }
        public static Post GetPostById(Guid id)
        {
            using DataBaseContext context = new DataBaseContext();
            return context.Posts.Where(p => p.PostId == id).FirstOrDefault();
        }
        public static List<Post> GetAllPosts()
        {
            using DataBaseContext context = new DataBaseContext();
            return context.Posts.Include(p => p.Comments).ToList();
        }
        public static Comment AddComment(Comment comment)
        {
            using DataBaseContext context = new DataBaseContext();
            context.Comments.Add(comment);
            context.SaveChanges();
            return comment;
        }
        public static Comment UpdateComment(Comment newComment)
        {
            throw new NotImplementedException();
        }
        public static Comment GetCommentById(Guid id)
        {
            using DataBaseContext context = new DataBaseContext();
            return context.Comments.Where(c => c.CommentId == id).FirstOrDefault();
        }
    }
}
