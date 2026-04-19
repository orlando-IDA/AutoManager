using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutoManager.Domain.Entities;

namespace AutoManager.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Pagamento");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.TotalAmount)
            .HasColumnName("ValorTotal")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(p => p.Method)
            .HasColumnName("Metodo")
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        // Relacionamento 1:1 com OrdemServico
        builder.HasOne(p => p.ServiceOrder)
            .WithOne(so => so.Payment)
            .HasForeignKey<Payment>(p => p.ServiceOrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}