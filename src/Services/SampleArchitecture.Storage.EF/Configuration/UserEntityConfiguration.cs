using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleArchitecture.Storage.Entities;

namespace SampleArchitecture.Storage.Configuration
{
    /// <summary>
    /// The user entity configuration.
    /// </summary>
    /// <seealso cref="IEntityTypeConfiguration{TEntity}"/>
    internal sealed class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).IsRequired();

            builder
                .HasMany(e => e.Posts)
                .WithOne(e => e.User)
                .IsRequired();
        }
    }
}