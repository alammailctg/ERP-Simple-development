using AenEnterprise.DomainModel.BlogsDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.Blogs
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id); // Primary Key

            builder.Property(c => c.Author)
                .IsRequired()           // Author is required
                .HasMaxLength(100);      // Max length of 100 characters

            builder.Property(c => c.Content)
                .IsRequired();           // Content is required

            builder.Property(c => c.DatePosted)
                .HasDefaultValueSql("GETDATE()"); // Default to current date

            builder.HasOne(c => c.Post)   // Each Comment belongs to one Post
                .WithMany(p => p.Comments) // Each Post has many Comments
                .HasForeignKey(c => c.PostId) // Foreign key
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete
        }
    }
}
