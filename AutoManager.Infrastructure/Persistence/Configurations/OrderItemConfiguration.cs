using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutoManager.Domain.Entities;

namespace AutoManager.Infrastructure.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("ItemOrdemServico");

        builder.HasKey(oi => oi.Id);

        builder.Property(oi => oi.Description)
            .HasColumnName("Descricao")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(oi => oi.Price)
            .HasColumnName("Preco")
            .HasPrecision(10, 2)
            .IsRequired();

        // Relacionamento N:1 com OrdemServico
        builder.HasOne(oi => oi.ServiceOrder)
            .WithMany(so => so.Items)
            .HasForeignKey(oi => oi.ServiceOrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}