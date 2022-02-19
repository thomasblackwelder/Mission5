﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission4.Models;

namespace Mission4.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20220219061116_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("Mission4.Models.ApplicationResponse", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<int>("RatingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId");

                    b.HasIndex("RatingId");

                    b.ToTable("responses");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Category = "Romance",
                            Director = "Martha Coolidge",
                            Edited = false,
                            LentTo = "",
                            Notes = "",
                            RatingId = 3,
                            Title = "Valley Girl",
                            Year = 1983
                        },
                        new
                        {
                            MovieId = 2,
                            Category = "Romance",
                            Director = "Jean-Pierre Jeunet",
                            Edited = false,
                            LentTo = "",
                            Notes = "",
                            RatingId = 3,
                            Title = "Amelie",
                            Year = 2001
                        },
                        new
                        {
                            MovieId = 3,
                            Category = "Romance",
                            Director = "Luca Guadagnino",
                            Edited = false,
                            LentTo = "",
                            Notes = "",
                            RatingId = 3,
                            Title = "Call Me by Your Name",
                            Year = 2017
                        });
                });

            modelBuilder.Entity("Mission4.Models.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RatingName")
                        .HasColumnType("TEXT");

                    b.HasKey("RatingId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            RatingId = 1,
                            RatingName = "G"
                        },
                        new
                        {
                            RatingId = 2,
                            RatingName = "PG"
                        },
                        new
                        {
                            RatingId = 3,
                            RatingName = "PG-13"
                        },
                        new
                        {
                            RatingId = 4,
                            RatingName = "R"
                        },
                        new
                        {
                            RatingId = 5,
                            RatingName = "NR"
                        });
                });

            modelBuilder.Entity("Mission4.Models.ApplicationResponse", b =>
                {
                    b.HasOne("Mission4.Models.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}