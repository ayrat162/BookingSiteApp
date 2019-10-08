﻿// <auto-generated />
using BookingDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingDAL.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20191008042652_AddedHotelDetails")]
    partial class AddedHotelDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("BookingShared.Models.HotelDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullDescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("HotelModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HotelModelId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("BookingShared.Models.HotelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescriptionShort")
                        .HasColumnType("TEXT");

                    b.Property<string>("MapLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Stars")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("BookingShared.Models.HotelDetailsModel", b =>
                {
                    b.HasOne("BookingShared.Models.HotelModel", "HotelModel")
                        .WithMany()
                        .HasForeignKey("HotelModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
