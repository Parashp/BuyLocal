﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(BuyLocalContext))]
    [Migration("20200205234955_ProductTableAdded")]
    partial class ProductTableAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Models.Address", b =>
                {
                    b.Property<Guid>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Geo_Lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Geo_Lon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DataLayer.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("DataLayer.Models.Person", b =>
                {
                    b.Property<Guid>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BirthYear")
                        .HasColumnType("int");

                    b.Property<Guid>("ContactID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.HasIndex("AddressID");

                    b.HasIndex("ContactID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DataLayer.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("RoleCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            Description = "",
                            IsVisible = true,
                            RoleCode = "UR01",
                            RoleName = "Farmer"
                        },
                        new
                        {
                            RoleID = 2,
                            Description = "",
                            IsVisible = true,
                            RoleCode = "UR02",
                            RoleName = "Retailer"
                        },
                        new
                        {
                            RoleID = 3,
                            Description = "",
                            IsVisible = true,
                            RoleCode = "UR03",
                            RoleName = "Consumer"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("PersonID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("PersonID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLayer.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserRoleID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("DataLayer.Models.Person", b =>
                {
                    b.HasOne("DataLayer.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.HasOne("DataLayer.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Models.UserRole", b =>
                {
                    b.HasOne("DataLayer.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
