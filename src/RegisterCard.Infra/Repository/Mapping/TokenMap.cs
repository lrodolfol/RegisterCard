using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RegisterCard.Core.Aggregates;

namespace RegisterCard.Infra.Repository.Mapping;
public class TokenMap : IEntityTypeConfiguration<Token>
{
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.ToTable("Token");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

        builder.Property(x => x.Number)
            .HasColumnName("Number")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255)
            .IsRequired();
    }
}
