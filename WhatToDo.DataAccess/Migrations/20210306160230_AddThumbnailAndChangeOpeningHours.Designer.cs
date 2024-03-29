﻿// <auto-generated />
using System;
using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WhatToDo.DataAccess.Migrations
{
    [DbContext(typeof(PlacesContext))]
    [Migration("20210306160230_AddThumbnailAndChangeOpeningHours")]
    partial class AddThumbnailAndChangeOpeningHours
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WhatToDo.DataAccess.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Number")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ImageId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.OpeningHours", b =>
                {
                    b.Property<int>("OpeningHoursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ClosingHour")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayOfTheWeek")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpeningHour")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("OpeningHoursId");

                    b.HasIndex("PlaceId");

                    b.ToTable("OpeningHours");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ThumbnailImageId")
                        .HasColumnType("int");

                    b.HasKey("PlaceId");

                    b.HasIndex("AddressId");

                    b.HasIndex("ThumbnailImageId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.Url", b =>
                {
                    b.Property<int>("UrlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("UrlAdress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("UrlId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Urls");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.Category", b =>
                {
                    b.HasOne("WhatToDo.DataAccess.Models.Place", null)
                        .WithMany("Categories")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.Image", b =>
                {
                    b.HasOne("WhatToDo.DataAccess.Models.Place", null)
                        .WithMany("Images")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.OpeningHours", b =>
                {
                    b.HasOne("WhatToDo.DataAccess.Models.Place", null)
                        .WithMany("OpeningHoursList")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.Place", b =>
                {
                    b.HasOne("WhatToDo.DataAccess.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("WhatToDo.DataAccess.Models.Image", "Thumbnail")
                        .WithMany()
                        .HasForeignKey("ThumbnailImageId");

                    b.Navigation("Address");

                    b.Navigation("Thumbnail");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.Url", b =>
                {
                    b.HasOne("WhatToDo.DataAccess.Models.Place", null)
                        .WithMany("Urls")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("WhatToDo.DataAccess.Models.Place", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Images");

                    b.Navigation("OpeningHoursList");

                    b.Navigation("Urls");
                });
#pragma warning restore 612, 618
        }
    }
}
