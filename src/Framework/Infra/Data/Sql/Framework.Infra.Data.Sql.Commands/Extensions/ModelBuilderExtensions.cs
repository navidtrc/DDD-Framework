﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Framework.Core.Domain.Entities;
using Framework.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Framework.Infra.Data.Sql.Commands.Extensions;
public static class ModelBuilderExtensions
{
    public static void AddBusinessId(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model
                                               .GetEntityTypes()
                                               .Where(e => typeof(AggregateRoot).IsAssignableFrom(e.ClrType) ||
                                                    typeof(Entity).IsAssignableFrom(e.ClrType)))
        {
            modelBuilder.Entity(entityType.ClrType)
                .Property<BusinessId>("BusinessId").HasConversion(c => c.Value, d => BusinessId.FromGuid(d))
                .IsUnicode()
                .IsRequired();
            modelBuilder.Entity(entityType.ClrType).HasAlternateKey("BusinessId");
        }
    }
    public static ModelBuilder UseValueConverterForType<T>(this ModelBuilder modelBuilder, ValueConverter converter, int maxLenght = 0)
    {
        return modelBuilder.UseValueConverterForType(typeof(T), converter, maxLenght);
    }
    public static ModelBuilder UseValueConverterForType(this ModelBuilder modelBuilder, Type type, ValueConverter converter, int maxLength = 0)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == type);

            foreach (var property in properties)
            {
                modelBuilder.Entity(entityType.Name).Property(property.Name)
                    .HasConversion(converter);
                if (maxLength > 0)
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasMaxLength(maxLength);
            }
        }

        return modelBuilder;
    }
}

