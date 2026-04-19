using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutoManager.Domain.Entities;

namespace AutoManager.Infrastructure.Persistence.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Veiculo");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.LicensePlate)
            .HasColumnName("Placa")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(v => v.Manufacturer)
            .HasColumnName("Montadora")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(v => v.Model)
            .HasColumnName("Modelo")
            .HasMaxLength(100)
            .IsRequired();

        // Relacionamento N:1 com Cliente
        builder.HasOne(v => v.Customer)
            .WithMany(c => c.Vehicles)
            .HasForeignKey(v => v.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}