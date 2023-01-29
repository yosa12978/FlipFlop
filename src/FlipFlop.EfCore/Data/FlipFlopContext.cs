using FlipFlop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipFlop.EfCore.Data
{
    public class FlipFlopContext : DbContext
    {
        public readonly ILogger _logger = default!;
        public FlipFlopContext()
        {

        }
        public FlipFlopContext(DbContextOptions<FlipFlopContext> options, ILogger<FlipFlopContext> logger) : base(options)
        {
            this._logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlite("Db Source = db.sqlite"); //  take this string from config file
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<Post>().HasKey(x => x.Id);
            builder.Entity<Comment>().HasKey(x => x.Id);
            builder.Entity<Image>().HasKey(x => x.Id);

            builder.Entity<Comment>()
                .HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.AuthorId);

            builder.Entity<Comment>()
                .HasOne<Post>()
                .WithMany()
                .HasForeignKey(x => x.PostId);

            builder.Entity<Post>()
                .HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.AuthorId);
            builder.Entity<Post>()
                .HasMany<Image>()
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);

            builder.Entity<User>()
                .HasMany<Comment>()
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);

            builder.Entity<User>()
                .HasMany<Post>()
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);

            builder.Entity<User>()
                .HasMany<Image>()
                .WithOne(x => x.Uploader)
                .HasForeignKey(x => x.UploaderId);

            builder.Entity<Image>()
                .HasOne(x => x.Post)
                .WithMany()
                .HasForeignKey(x => x.PostId);
            builder.Entity<Image>()
                .HasOne(x => x.Uploader)
                .WithMany()
                .HasForeignKey(x => x.UploaderId);
        }

        public DbSet<User> users { get; set; } = default!;
        public DbSet<Post> posts { get; set; } = default!;
        public DbSet<Image> images { get; set; } = default!;
        public DbSet<Comment> comments { get; set; } = default!;

    }
}
