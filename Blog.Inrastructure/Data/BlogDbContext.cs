using Blog.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Inrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ////user
            //modelBuilder.Entity<User>(entity =>
            //{
            //    // PK
            //    entity.HasKey(user => user.Id); // key
            //    // username
            //    entity.Property(user => user.UserName)
            //    .IsRequired()
            //    .HasMaxLength(150);

            //    entity.HasIndex(user => user.Email).IsUnique();


            //});
            //modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();



            // relations 
            //  1 - 1   , 1 - M , M - M 
            // post , comment 1 - M
            //modelBuilder.Entity<Post>().HasMany(post => post.Comments)
            //        .WithOne(comment => comment.Post)
            //        .HasForeignKey(commet => commet.PostId);

            // post , category M - M
            //modelBuilder.Entity<Post>().HasMany(post => post.Category)
            //    .WithMany(Category => Category.Posts).
            //    UseingEntity(entity => entity.ToTable("PostCategories"));

        }


    }
}
