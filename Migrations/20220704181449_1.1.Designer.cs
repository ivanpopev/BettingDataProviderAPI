﻿// <auto-generated />
using System;
using BettingDataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BettingDataProvider.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220704181449_1.1")]
    partial class _11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BettingDataProvider.Models.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsLive")
                        .HasColumnType("bit");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsLive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("MatchType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Odd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.ToTable("Odds");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Bet", b =>
                {
                    b.HasOne("BettingDataProvider.Models.Match", null)
                        .WithMany("Bet")
                        .HasForeignKey("MatchId");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Event", b =>
                {
                    b.HasOne("BettingDataProvider.Models.Sport", null)
                        .WithMany("Event")
                        .HasForeignKey("SportId");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Match", b =>
                {
                    b.HasOne("BettingDataProvider.Models.Event", null)
                        .WithMany("Match")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Odd", b =>
                {
                    b.HasOne("BettingDataProvider.Models.Bet", null)
                        .WithMany("Odd")
                        .HasForeignKey("BetId");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Bet", b =>
                {
                    b.Navigation("Odd");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Event", b =>
                {
                    b.Navigation("Match");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Match", b =>
                {
                    b.Navigation("Bet");
                });

            modelBuilder.Entity("BettingDataProvider.Models.Sport", b =>
                {
                    b.Navigation("Event");
                });
#pragma warning restore 612, 618
        }
    }
}
