﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientPortalWebApp.Data;

#nullable disable

namespace PatientPortalWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240404113932_CurrentPatientId to doctors table")]
    partial class CurrentPatientIdtodoctorstable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PatientPortalWebApp.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("PatientPortalWebApp.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppointmentTime")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("PatientPortalWebApp.Models.Doctors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CurrentPatientId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("PatientPortalWebApp.Models.MedicalRecords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DoctorID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Medication")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PatientID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("PatientPortalWebApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PatientPortalWebApp.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AffiliateId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
