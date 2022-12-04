using System;
using BGD_Backend.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BGD_Backend.WebApi.Data.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder) {
            builder.ToTable("items");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.HasMany<HistoryAction>().WithOne(i => i.Item).HasForeignKey(i => i.ItemId).HasConstraintName("FK_ItemId");
            builder.Property(i => i.Name).IsRequired();
            builder.Property(i => i.FixedQuantity).IsRequired();
            builder.Property(i => i.ActualQuantity).IsRequired();
        }

    }
}
