using AenEnterprise.DomainModel.BlogsDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.Blogs
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id); // Primary Key

            builder.Property(p => p.Title)
                .IsRequired()           // Title is required
                .HasMaxLength(200);      // Max length of 200 characters

            builder.Property(p => p.Content)
                .IsRequired();           // Content is required

            builder.Property(p => p.PublishedDate)
                .HasDefaultValueSql("GETDATE()"); // Default to current date

            builder.HasOne(p => p.Category)   // Each Post belongs to one Category
                .WithMany(bc => bc.Posts)     // Each Category has many Posts
                .HasForeignKey(p => p.CategoryId) // Foreign key
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete

            builder.HasMany(p => p.Comments)  // One-to-many relationship
                .WithOne(c => c.Post)         // Each Comment belongs to one Post
                .HasForeignKey(c => c.PostId) // Foreign key
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete
        }
    }

}
