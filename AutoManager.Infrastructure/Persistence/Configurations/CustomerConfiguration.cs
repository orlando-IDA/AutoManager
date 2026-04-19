using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutoManager.Domain.Entities;

namespace AutoManager.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Cliente");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasColumnName("Nome")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Cpf)
            .HasColumnName("Cpf")
            .HasMaxLength(14)
            .IsRequired();

        builder.Property(c => c.Phone)
            .HasColumnName("Telefone")
            .HasMaxLength(15);
            
        builder.HasMany(c => c.Vehicles)
            .WithOne(v => v.Customer)
            .HasForeignKey(v => v.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}