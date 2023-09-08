﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaaSInNetCore.Data.Contexts;

#nullable disable

namespace SaaSInNetCore.Web.Data.Migrations.SaaSInNetCore.CatalogDb
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20230908055352_InitialCustomerDbMigration")]
    partial class InitialCustomerDbMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SaaSInNetCore.Data.Entities.Catalog.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Database")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DbConnectionString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HostName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subscription")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubscriptionExipreDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tenant", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}