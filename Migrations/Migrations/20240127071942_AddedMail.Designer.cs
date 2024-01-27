﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Migrations;

#nullable disable

namespace Migrations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240127071942_AddedMail")]
    partial class AddedMail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Migrations.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attempts")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Attempts = 0,
                            Login = "test_login",
                            PasswordHash = "my_passhash",
                            UserId = -5
                        },
                        new
                        {
                            Id = -2,
                            Attempts = 0,
                            Login = "test_login2",
                            PasswordHash = "my_testPassHash",
                            UserId = -5
                        });
                });

            modelBuilder.Entity("Migrations.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("mail");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("surname");

                    b.Property<int?>("UserAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserAddressId")
                        .IsUnique()
                        .HasFilter("[UserAddressId] IS NOT NULL");

                    b.ToTable("user_table", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Email = "Harriet_Ferry98@hotmail.com",
                            FirstName = "Harriet",
                            LastName = "Ferry"
                        },
                        new
                        {
                            Id = -2,
                            Email = "Shawn8@yahoo.com",
                            FirstName = "Shawn",
                            LastName = "Fahey"
                        },
                        new
                        {
                            Id = -3,
                            Email = "Nancy_MacGyver@hotmail.com",
                            FirstName = "Nancy",
                            LastName = "MacGyver"
                        },
                        new
                        {
                            Id = -4,
                            Email = "Greg.Pagac@hotmail.com",
                            FirstName = "Greg",
                            LastName = "Pagac"
                        },
                        new
                        {
                            Id = -5,
                            Email = "Noah.Durgan76@hotmail.com",
                            FirstName = "Noah",
                            LastName = "Durgan",
                            UserAddressId = -1
                        },
                        new
                        {
                            Id = -6,
                            Email = "Mike93@yahoo.com",
                            FirstName = "Mike",
                            LastName = "Kling"
                        },
                        new
                        {
                            Id = -7,
                            Email = "Noel.Bernhard28@yahoo.com",
                            FirstName = "Noel",
                            LastName = "Bernhard"
                        },
                        new
                        {
                            Id = -8,
                            Email = "Jerome.Huels2@gmail.com",
                            FirstName = "Jerome",
                            LastName = "Huels"
                        },
                        new
                        {
                            Id = -9,
                            Email = "Amy.Stokes3@yahoo.com",
                            FirstName = "Amy",
                            LastName = "Stokes"
                        },
                        new
                        {
                            Id = -10,
                            Email = "Opal.Yundt@hotmail.com",
                            FirstName = "Opal",
                            LastName = "Yundt"
                        });
                });

            modelBuilder.Entity("Migrations.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserAddresses");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            City = "Baku",
                            Country = "AZ",
                            UserId = -5
                        });
                });

            modelBuilder.Entity("Migrations.Account", b =>
                {
                    b.HasOne("Migrations.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Migrations.User", b =>
                {
                    b.HasOne("Migrations.UserAddress", "UserAddress")
                        .WithOne("User")
                        .HasForeignKey("Migrations.User", "UserAddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("UserAddress");
                });

            modelBuilder.Entity("Migrations.User", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Migrations.UserAddress", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
