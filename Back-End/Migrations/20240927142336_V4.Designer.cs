﻿// <auto-generated />
using System;
using Back_End.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Back_End.Migrations
{
    [DbContext(typeof(FlightSystemDBContext))]
    [Migration("20240927142336_VD")]
    partial class VD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Back_End.Models.Entities.Document", b =>
                {
                    b.Property<Guid>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document_File")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Document_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("Document_TypeTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Flight_No")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("DocumentId");

                    b.HasIndex("Document_TypeTypeId");

                    b.HasIndex("Flight_No");

                    b.HasIndex("GroupId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Document_Type", b =>
                {
                    b.Property<Guid>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Type_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("TypeId");

                    b.ToTable("Document_Types");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Flight", b =>
                {
                    b.Property<Guid>("Flight_No")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Departure_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Point_Of_Loadding")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Point_Of_UnLoadding")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Rotue")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<TimeSpan>("TimeFlight")
                        .HasColumnType("time");

                    b.Property<int>("Total_Document")
                        .HasColumnType("int");

                    b.HasKey("Flight_No");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Group_Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Permission", b =>
                {
                    b.Property<Guid>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Permission_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PermissionId");

                    b.HasIndex("GroupId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role_Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Setting", b =>
                {
                    b.Property<Guid>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Captcha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SettingId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Back_End.Models.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Document", b =>
                {
                    b.HasOne("Back_End.Models.Entities.Document_Type", "Document_Type")
                        .WithMany("Documents")
                        .HasForeignKey("Document_TypeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_End.Models.Entities.Flight", "Flight")
                        .WithMany("Documents")
                        .HasForeignKey("Flight_No")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_End.Models.Entities.Group", "Group")
                        .WithMany("Documents")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document_Type");

                    b.Navigation("Flight");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Permission", b =>
                {
                    b.HasOne("Back_End.Models.Entities.Group", "Group")
                        .WithMany("Permissions")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Setting", b =>
                {
                    b.HasOne("Back_End.Models.Entities.User", "User")
                        .WithOne("Setting")
                        .HasForeignKey("Back_End.Models.Entities.Setting", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Back_End.Models.Entities.User", b =>
                {
                    b.HasOne("Back_End.Models.Entities.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Back_End.Models.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Document_Type", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Flight", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Group", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Permissions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Back_End.Models.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Back_End.Models.Entities.User", b =>
                {
                    b.Navigation("Setting")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
