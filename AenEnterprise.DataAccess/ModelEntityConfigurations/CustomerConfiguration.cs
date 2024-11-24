using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id); // Set Id as primary key

            builder.Property(c => c.Name)
                .IsRequired() // Mark Name as required
                .HasMaxLength(100); // Set a max length for Name

            builder.Property(c => c.CreatedDate)
                .IsRequired(); // Ensure CreatedDate is required

            builder.Property(c => c.Description)
                .HasMaxLength(500); // Set a max length for Description

            builder.Property(c => c.Address)
                .HasMaxLength(250); // Set a max length for Address

            builder.Property(c => c.MobileNo)
                .HasMaxLength(15); // Set a max length for MobileNo

            builder.Property(c => c.Balance)
                .HasColumnType("decimal(18,2)"); // Specify the type for Balance

            // Seed data with unique IDs
            builder.HasData(
                new Customer { Id = 1, Name = "Alam", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Plate Customer", MobileNo = "01887969696", Balance = 200.00m },
                new Customer { Id = 2, Name = "Shamim Enterprise", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Brass Customer", MobileNo = "01887969696", Balance = 1000.00m },
                new Customer { Id = 3, Name = "Shahab Uddin", Address = "Chittagong", CreatedDate = DateTime.Now, Description = "This is Plate Customer", MobileNo = "01887969696", Balance = 500.00m },
                new Customer { Id = 4, Name = "Abdul Matin", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Abdul Matin's Customer", MobileNo = "01887969696", Balance = 500.00m },
                new Customer { Id = 5, Name = "Abdur Rahman", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Abdur Rahman's Customer", MobileNo = "01887969696", Balance = 4100.00m },
                new Customer { Id = 6, Name = "Abdus Salam", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Abdus Salam's Customer", MobileNo = "01887969696", Balance = 400.00m },
                new Customer { Id = 7, Name = "Abul Bashar", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Abul Bashar's Customer", MobileNo = "01887969696", Balance = 3300.00m },
                new Customer { Id = 8, Name = "Abul Kashem", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Abul Kashem's Customer", MobileNo = "01887969696", Balance = 2200.00m },
                new Customer { Id = 9, Name = "Abutaher", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Abutaher's Customer", MobileNo = "01887969696", Balance = 1100.00m },
                new Customer { Id = 10, Name = "Agrabad Office", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Agrabad Office's Customer", MobileNo = "01887969696", Balance = 4500.00m },
                // Continue with unique Ids...
                new Customer { Id = 11, Name = "Akkas", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Akkas's Customer", MobileNo = "01887969696", Balance = 600.00m },
                new Customer { Id = 12, Name = "Al Madina", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Al Madina's Customer", MobileNo = "01887969696", Balance = 2000.00m },
                new Customer { Id = 13, Name = "Alamgir", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Alamgir's Customer", MobileNo = "01887969696", Balance = 200.00m },
                new Customer { Id = 14, Name = "AR Enterprise", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is AR Enterprise's Customer", MobileNo = "01887969696", Balance = 800.00m },
                new Customer { Id = 15, Name = "Ayub Khan", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Ayub Khan's Customer", MobileNo = "01887969696", Balance = 4500.00m },
                new Customer { Id = 16, Name = "AZ Brothers", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is AZ Brothers' Customer", MobileNo = "01887969696", Balance = 600.00m },
                // Add more customers with unique Ids...
                new Customer { Id = 17, Name = "Bablu", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Bablu's Customer", MobileNo = "01887969696", Balance = 200.00m },
                new Customer { Id = 18, Name = "Bacha Meah", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Bacha Meah's Customer", MobileNo = "01887969696", Balance = 14000.00m },
                new Customer { Id = 19, Name = "Bismillah", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Bismillah's Customer", MobileNo = "01887969696", Balance = 2200.00m },
                new Customer { Id = 20, Name = "Dalehsar Iron", Address = "Dhaka", CreatedDate = DateTime.Now, Description = "This is Dalehsar Iron's Customer", MobileNo = "01887969696", Balance = 100.00m }
                // Make sure to continue with unique Ids...
            );
        }
    }
}
