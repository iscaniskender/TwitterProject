using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace DAL.Context
{
    public class TwetterContext:DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-P4JO1BR\SQLEXPRESS;Database=TweetterProject;integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Connection>().HasKey(c => new { c.takipid, c.TakipciId });
            modelBuilder.Entity<Like>().HasKey(c => new { c.TweetId, c.UserId });
            modelBuilder.Entity<Retweet>().HasKey(c => new { c.TweetId, c.UserId });
            modelBuilder.Entity<Reply>().HasKey(c => new { c.TweetId, c.UserId });
        }

        public DbSet<User>Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Retweet> Retweets { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Connection> Connections { get; set; }
       
    }
 
}
