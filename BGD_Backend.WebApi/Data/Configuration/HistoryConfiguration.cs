using System;
using BGD_Backend.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BGD_Backend.WebApi.Data.Configuration
{
    public class HistoryConfiguration : IEntityTypeConfiguration<HistoryAction>
    {
         public void Configure(EntityTypeBuilder<HistoryAction> builder) {
            builder.ToTable("history");
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Action).IsRequired();
            builder.Property(i => i.UserId).IsRequired();
            builder.Property(i => i.ActionDate).IsRequired();
        }
    }
}
