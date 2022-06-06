﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.AggregateModels.BuyerAggregate;
using OrderService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.EntityConfigurations
{
    public class CardTypeEntityConfiguration : IEntityTypeConfiguration<CardType>
    {
        public void Configure(EntityTypeBuilder<CardType> builder)
        {
            builder.ToTable("cardypes", OrderDbContext.DEFAULT_SCHEMA);

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(i => i.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(i => i.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
