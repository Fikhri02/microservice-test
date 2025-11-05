// Infrastructure/Configurations/OrderConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//Fluent API configuration
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.OwnsMany(o => o.Items, i =>
        {
            i.WithOwner().HasForeignKey("OrderId");
            i.Property<Guid>("Id");
            i.HasKey("Id");
        });
    }
}
