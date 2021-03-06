﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using TicketTrader.EventDefinitions.EntityFramework;

namespace TicketTrader.EventDefinitions.EntityFramework.Migrations
{
    [DbContext(typeof(DalContext))]
    [Migration("20170913203436_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("DescriptionId");

                    b.Property<TimeSpan>("Duration");

                    b.Property<int?>("RootId");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.HasIndex("RootId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.EventCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.EventDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Authors");

                    b.Property<string>("Cast");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("EventDescriptions");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.EventDescriptionCategories", b =>
                {
                    b.Property<int>("DescriptionId");

                    b.Property<int>("CategoryId");

                    b.HasKey("DescriptionId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("EventDescriptionCategories");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("GrossAmount");

                    b.Property<decimal>("NetAmount");

                    b.Property<decimal>("VatRate");

                    b.HasKey("Id");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.PriceList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.PriceOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("PriceId");

                    b.Property<int>("PriceZoneId");

                    b.HasKey("Id");

                    b.HasIndex("PriceId");

                    b.HasIndex("PriceZoneId");

                    b.ToTable("PriceOptions");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.PriceZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("PriceListId");

                    b.Property<int>("ScenePriceZoneId");

                    b.HasKey("Id");

                    b.HasIndex("PriceListId");

                    b.ToTable("PriceZones");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.Scene", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName");

                    b.Property<int>("EventId");

                    b.Property<int?>("RootId");

                    b.Property<string>("UniqueName");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.HasIndex("RootId");

                    b.ToTable("Scenes");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("EventId");

                    b.Property<int?>("PriceZoneId");

                    b.Property<int?>("SceneId");

                    b.Property<int>("SceneSeatId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PriceZoneId");

                    b.HasIndex("SceneId");

                    b.ToTable("Seats");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Seat");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("SceneSectorId");

                    b.HasKey("Id");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.NumberedSeat", b =>
                {
                    b.HasBaseType("TicketTrader.EventDefinitions.Entities.Seat");

                    b.Property<string>("Number");

                    b.Property<int?>("SectorId");

                    b.HasIndex("SectorId");

                    b.ToTable("NumberedSeat");

                    b.HasDiscriminator().HasValue("NumberedSeat");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.UnnumberedSeat", b =>
                {
                    b.HasBaseType("TicketTrader.EventDefinitions.Entities.Seat");

                    b.Property<string>("Name");

                    b.ToTable("UnnumberedSeat");

                    b.HasDiscriminator().HasValue("UnnumberedSeat");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.Event", b =>
                {
                    b.HasOne("TicketTrader.EventDefinitions.Entities.EventDescription", "Description")
                        .WithMany("Events")
                        .HasForeignKey("DescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketTrader.EventDefinitions.Entities.Event", "Root")
                        .WithMany()
                        .HasForeignKey("RootId");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.EventDescriptionCategories", b =>
                {
                    b.HasOne("TicketTrader.EventDefinitions.Entities.EventCategory", "Category")
                        .WithMany("EventCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketTrader.EventDefinitions.Entities.EventDescription", "Description")
                        .WithMany("EventCategories")
                        .HasForeignKey("DescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.PriceList", b =>
                {
                    b.HasOne("TicketTrader.EventDefinitions.Entities.Event", "Event")
                        .WithMany("PriceLists")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.PriceOption", b =>
                {
                    b.HasOne("TicketTrader.EventDefinitions.Entities.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId");

                    b.HasOne("TicketTrader.EventDefinitions.Entities.PriceZone", "PriceZone")
                        .WithMany("Options")
                        .HasForeignKey("PriceZoneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.PriceZone", b =>
                {
                    b.HasOne("TicketTrader.EventDefinitions.Entities.PriceList", "PriceList")
                        .WithMany("PriceZones")
                        .HasForeignKey("PriceListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.Scene", b =>
                {
                    b.HasOne("TicketTrader.EventDefinitions.Entities.Event", "Event")
                        .WithOne("Scene")
                        .HasForeignKey("TicketTrader.EventDefinitions.Entities.Scene", "EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketTrader.EventDefinitions.Entities.Scene", "Root")
                        .WithMany()
                        .HasForeignKey("RootId");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.Seat", b =>
                {
                    b.HasOne("TicketTrader.EventDefinitions.Entities.Event", "Event")
                        .WithMany("Seats")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketTrader.EventDefinitions.Entities.PriceZone")
                        .WithMany("Seats")
                        .HasForeignKey("PriceZoneId");

                    b.HasOne("TicketTrader.EventDefinitions.Entities.Scene")
                        .WithMany("Seats")
                        .HasForeignKey("SceneId");
                });

            modelBuilder.Entity("TicketTrader.EventDefinitions.Entities.NumberedSeat", b =>
                {
                    b.HasOne("TicketTrader.EventDefinitions.Entities.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId");
                });
#pragma warning restore 612, 618
        }
    }
}
