using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RegisterCard.Core.Entities;

namespace RegisterCard.Infra.Repository.Mapping;
public class CreditCardMap : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.ToTable("CreditCard");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(x => x.Number)
            .HasColumnName("Number")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(16)
            .IsRequired();

        builder.Property(x => x.SecurityCode)
            .HasColumnName("SecurityCode")
            .HasColumnType("SMALLINT")
            .IsRequired();

        builder.HasOne(card => card.Client)
            .WithMany(client => client.CreditCards)
            .HasConstraintName("Fk_Client_CreditCard")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Token)
            .WithOne()
            .HasForeignKey<CreditCard>(x => x.TokenId)
            .HasConstraintName("FK_CreditCard_Token")
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
