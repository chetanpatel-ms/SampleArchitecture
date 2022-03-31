using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleArchitecture.Storage.Entities;

namespace SampleArchitecture.Storage.Configuration
{
    /// <summary>
    /// The post entity configuration.
    /// </summary>
    /// <seealso cref="IEntityTypeConfiguration{TEntity}"/>
    internal sealed class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Value).IsRequired();
        }
    }
}