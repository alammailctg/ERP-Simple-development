using AenEnterprise.DomainModel.BlogsDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations.Blogs
{
    public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.HasKey(bc => bc.Id); // Primary Key

            builder.Property(bc => bc.Name)
                .IsRequired()           // Name is required
                .HasMaxLength(100);      // Max length of 100 characters

            builder.HasMany(bc => bc.Posts)  // One-to-many relationship
                .WithOne(p => p.Category)    // Each Post has one Category
                .HasForeignKey(p => p.CategoryId) // Foreign key
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete

            // Optional: Set a table name if different from the class name
            builder.ToTable("BlogCategories");
        }
    }

}
