﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(FlightSystemDBContext))]
    [Migration("20241017113811_add verificationCode")]
    partial class addverificationCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Document", b =>
                {
                    b.Property<Guid>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Document_File")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Document_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("FlightId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Signature")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Update_at")
                        .HasColumnType("datetime2");

                    b.Property<double>("Version")
                        .HasColumnType("float");

                    b.HasKey("DocumentId");

                    b.HasIndex("FlightId");

                    b.HasIndex("TypeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.DocumentType", b =>
                {
                    b.Property<Guid>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Permission")
                        .HasColumnType("int");

                    b.Property<string>("Type_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("TypeId");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Flight", b =>
                {
                    b.Property<Guid>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Departure_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Rotue")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<TimeSpan>("TimeFlight")
                        .HasColumnType("time");

                    b.Property<int?>("Total_Document")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Group_Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("Members")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupId");

                    b.HasIndex("PermissionId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.GroupDocument", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId", "DocumentId");

                    b.HasIndex("DocumentId");

                    b.ToTable("GroupDocuments");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.GroupDocumentType", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("GroupDocumentsTypes");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Permission", b =>
                {
                    b.Property<Guid>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Permission_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Setting", b =>
                {
                    b.Property<Guid>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Captcha")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Logo")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Theme")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SettingId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Create_at")
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
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("Update_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationCode")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("UserId");

                    b.HasIndex("GroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Document", b =>
                {
                    b.HasOne("FlightSystem.Domain.Domain.Entities.Flight", "Flight")
                        .WithMany("Documents")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightSystem.Domain.Domain.Entities.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Group", b =>
                {
                    b.HasOne("FlightSystem.Domain.Domain.Entities.Permission", "Premisstion")
                        .WithMany("Groups")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Premisstion");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.GroupDocument", b =>
                {
                    b.HasOne("FlightSystem.Domain.Domain.Entities.Document", "Document")
                        .WithMany("GroupDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightSystem.Domain.Domain.Entities.Group", "Group")
                        .WithMany("GroupDocuments")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.GroupDocumentType", b =>
                {
                    b.HasOne("FlightSystem.Domain.Domain.Entities.Group", "Group")
                        .WithMany("GroupDocumentTypes")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightSystem.Domain.Domain.Entities.DocumentType", "DocumentType")
                        .WithMany("GroupDocumentTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Setting", b =>
                {
                    b.HasOne("FlightSystem.Domain.Domain.Entities.User", "User")
                        .WithOne("Setting")
                        .HasForeignKey("FlightSystem.Domain.Domain.Entities.Setting", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.User", b =>
                {
                    b.HasOne("FlightSystem.Domain.Domain.Entities.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Document", b =>
                {
                    b.Navigation("GroupDocuments");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.DocumentType", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("GroupDocumentTypes");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Flight", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Group", b =>
                {
                    b.Navigation("GroupDocumentTypes");

                    b.Navigation("GroupDocuments");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.Permission", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("FlightSystem.Domain.Domain.Entities.User", b =>
                {
                    b.Navigation("Setting");
                });
#pragma warning restore 612, 618
        }
    }
}
