﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240420102229_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.DataModels.PersonDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateDateTimeInPersianFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);
                });

            modelBuilder.Entity("Infrastructure.DataModels.PersonDataModel", b =>
                {
                    b.OwnsMany("Infrastructure.DataModels.DocumentDataModel", "Documents", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Descriminator")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("DocumentUrl")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("PersianValidUntil_Day")
                                .HasColumnType("int");

                            b1.Property<int>("PersianValidUntil_Month")
                                .HasColumnType("int");

                            b1.Property<int>("PersianValidUntil_Year")
                                .HasColumnType("int");

                            b1.Property<Guid>("PersonDataModelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("ValidUntile")
                                .HasColumnType("datetime2");

                            b1.HasKey("Id");

                            b1.HasIndex("PersonDataModelId");

                            b1.ToTable("Documents", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PersonDataModelId");
                        });

                    b.OwnsOne("Infrastructure.DataModels.AddressDataModel", "HomeAddress", b1 =>
                        {
                            b1.Property<Guid>("PersonDataModelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Number")
                                .HasColumnType("int");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonDataModelId");

                            b1.ToTable("Persons");

                            b1.WithOwner()
                                .HasForeignKey("PersonDataModelId");
                        });

                    b.OwnsOne("Infrastructure.DataModels.AddressDataModel", "WorkAddress", b1 =>
                        {
                            b1.Property<Guid>("PersonDataModelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Number")
                                .HasColumnType("int");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PersonDataModelId");

                            b1.ToTable("Persons");

                            b1.WithOwner()
                                .HasForeignKey("PersonDataModelId");
                        });

                    b.Navigation("Documents");

                    b.Navigation("HomeAddress")
                        .IsRequired();

                    b.Navigation("WorkAddress");
                });
#pragma warning restore 612, 618
        }
    }
}
