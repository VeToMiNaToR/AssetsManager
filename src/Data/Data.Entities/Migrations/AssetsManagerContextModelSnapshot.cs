﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using devdeer.AssetsManager.Data.Entities;

#nullable disable

namespace devdeer.AssetsManager.Data.Entities.Migrations
{
    [DbContext(typeof(AssetsManagerContext))]
    partial class AssetsManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("devdeer.AssetsManager.Data.Entities.Asset", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateOnly>("AcquisitionDate")
                        .HasColumnType("date");

                    b.Property<string>("AssetKey")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Availability")
                        .HasColumnType("int");

                    b.Property<long>("BrandId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Ownership")
                        .HasColumnType("int");

                    b.Property<string>("PrimaryImagePath")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SecondaryImagePath")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<long?>("WorkerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("WorkplaceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.HasIndex("WorkerId");

                    b.HasIndex("WorkplaceId");

                    b.HasIndex(new[] { "AssetKey" }, "UX_Asset_AssetKey")
                        .IsUnique();

                    b.ToTable("Asset", "AssetData");
                });

            modelBuilder.Entity("devdeer.AssetsManager.Data.Entities.Entities.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Brand", "BaseData");
                });

            modelBuilder.Entity("devdeer.AssetsManager.Data.Entities.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Category", "BaseData");
                });

            modelBuilder.Entity("devdeer.AssetsManager.Data.Entities.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Location", "BaseData");
                });

            modelBuilder.Entity("devdeer.AssetsManager.Data.Entities.Entities.Worker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Worker", "BaseData");
                });

            modelBuilder.Entity("devdeer.AssetsManager.Data.Entities.Entities.Workplace", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Workplace", "BaseData");
                });

            modelBuilder.Entity("devdeer.AssetsManager.Data.Entities.Asset", b =>
                {
                    b.HasOne("devdeer.AssetsManager.Data.Entities.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devdeer.AssetsManager.Data.Entities.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devdeer.AssetsManager.Data.Entities.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("devdeer.AssetsManager.Data.Entities.Entities.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId");

                    b.HasOne("devdeer.AssetsManager.Data.Entities.Entities.Workplace", "Workplace")
                        .WithMany()
                        .HasForeignKey("WorkplaceId");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Location");

                    b.Navigation("Worker");

                    b.Navigation("Workplace");
                });
#pragma warning restore 612, 618
        }
    }
}
