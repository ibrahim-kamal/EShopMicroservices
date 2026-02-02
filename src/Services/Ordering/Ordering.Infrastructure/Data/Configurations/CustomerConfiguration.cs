using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObject;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasConversion(customerId => customerId.Value, dbId => CustomerId.Of(dbId));
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

            builder.Property(c => c.Email).HasMaxLength(255);

            builder.HasIndex(c => c.Email).IsUnique();
        }

    }
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasConversion(OrderId => OrderId.Value, dbId => OrderId.Of(dbId));

            builder.Property(o => o.CustomerId)
                .HasConversion(customerId => customerId.Value, dbId => CustomerId.Of(dbId));

            builder.Property(o => o.OrderName)
                .HasConversion(orderName => orderName.Value, dbName => OrderName.Of(dbName));
        }

    }
}
