﻿// <auto-generated />
using System;
using CompanyApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompanyApp.Infrastructure.Migrations
{
    [DbContext(typeof(CompanyAppContext))]
    partial class CompanyAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.2.22153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CompanyApp.Core.Domain.Models.MainTitle", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("NewsDateGroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("Prediction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Probability")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("NewsDateGroupId");

                    b.ToTable("MainTitle");
                });

            modelBuilder.Entity("CompanyApp.Core.Domain.Models.NewsDateGroup", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NewsDateGroups");
                });

            modelBuilder.Entity("CompanyApp.Core.Domain.Models.MainTitle", b =>
                {
                    b.HasOne("CompanyApp.Core.Domain.Models.NewsDateGroup", null)
                        .WithMany("News")
                        .HasForeignKey("NewsDateGroupId");
                });

            modelBuilder.Entity("CompanyApp.Core.Domain.Models.NewsDateGroup", b =>
                {
                    b.Navigation("News");
                });
#pragma warning restore 612, 618
        }
    }
}