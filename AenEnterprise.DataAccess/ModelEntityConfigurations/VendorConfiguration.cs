using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DomainModel.SupplyAndChainManagement.Configuration
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasKey(v => v.Id);


            builder.HasData(
                new Vendor { Id = 1, Name = "Vendor1", Address = "123 Main St", ContactNumber = "1234567890" },
                new Vendor { Id = 2, Name = "Vendor2", Address = "456 Second St", ContactNumber = "0987654321" }
            );
        }
    }
}
