using AenEnterprise.DomainModel.AccountsAndFinance.GeneralLedger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AenEnterprise.DataAccess.ModelEntityConfigurations
{
    public class LedgerPostingConfiguration : IEntityTypeConfiguration<LedgerPosting>
    {
        public void Configure(EntityTypeBuilder<LedgerPosting> builder)
        {
            builder.HasKey(lp => lp.LedgerPostingId);

            builder.Property(p => p.Amount)
           .HasColumnType("decimal(18, 2)");

            builder.Property(lp => lp.PostingDate)
                .IsRequired();

            builder.HasOne(lp => lp.AccountGroup)
                .WithMany(a => a.LedgerPostings)
                .HasForeignKey(lp => lp.AccountGroupId);

            builder.HasData(
                new LedgerPosting { LedgerPostingId = 1, PostingDate = DateTime.Now, Description = "Ledger posting 1", Amount = 5000, IsDebit = true, AccountGroupId = 1 },
                new LedgerPosting { LedgerPostingId = 2, PostingDate = DateTime.Now, Description = "Ledger posting 2", Amount = 3000, IsDebit = false, AccountGroupId = 2 }
            );
        }
    }

}
