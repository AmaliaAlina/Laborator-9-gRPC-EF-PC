using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
using GrpcDatabase.Models;

namespace GrpcDatabase
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PostCommentGRPC;Integrated Security=True");
        }
    }
}
