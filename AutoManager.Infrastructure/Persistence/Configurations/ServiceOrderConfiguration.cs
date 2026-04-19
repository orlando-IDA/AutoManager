using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutoManager.Domain.Entities;

namespace AutoManager.Infrastructure.Persistence.Configurations;

public class ServiceOrderConfiguration : IEntityTypeConfiguration<ServiceOrder>
{
    public void Configure(EntityTypeBuilder<ServiceOrder> builder)
    {
        builder.ToTable("OrdemServico");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.EntryDate)
            .IsRequired();

        builder.Property(c => c.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        // 1:1 com Pagamento (ServiceOrder é o principal)
        builder.HasOne(so => @so.Payment)
            .WithOne(p => p.ServiceOrder)
            .HasForeignKey<Payment>(p => p.ServiceOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // 1:N com OrderItem
        builder.HasMany(so => so.Items)
            .WithOne(oi => oi.ServiceOrder)
            .HasForeignKey(oi => oi.ServiceOrderId);
    }
}