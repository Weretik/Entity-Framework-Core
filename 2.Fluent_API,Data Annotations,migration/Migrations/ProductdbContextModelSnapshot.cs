﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _2.Fluent_API_Data_Annotations_migration;

#nullable disable

namespace _2.Fluent_API_Data_Annotations_migration.Migrations
{
    [DbContext(typeof(ProductdbContext))]
    partial class ProductdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("_2.Fluent_API_Data_Annotations_migration.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("Product_id");

                    b.Property<int>("AlterId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("ManufactureDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id", "AlterId");

                    b.ToTable("Products", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
