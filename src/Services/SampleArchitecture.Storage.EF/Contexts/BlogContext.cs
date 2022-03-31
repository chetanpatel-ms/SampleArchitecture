using Microsoft.EntityFrameworkCore;
using SampleArchitecture.Storage.Configuration;
using SampleArchitecture.Storage.Entities;

namespace SampleArchitecture.Storage.Contexts
{
    /// <summary>
    /// The blog context.
    /// </summary>
    /// <seealso cref="DbContext"/>
    internal class BlogContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BlogContext" />.
        /// </summary>
        public BlogContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="BlogContext" />.
        /// </summary>
        /// <param name="options">The <see cref="DbContextOptions" />.</param>
        public BlogContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        public DbSet<PostEntity> Posts { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}