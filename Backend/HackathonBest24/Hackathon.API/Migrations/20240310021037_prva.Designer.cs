﻿// <auto-generated />
using System;
using Hackathon.API.Modeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hackathon.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240310021037_prva")]
    partial class prva
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hackathon.API.Modeli.Materijal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OblastId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<string>("Putanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OblastId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("Materijal");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Oblast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredmetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PredmetId");

                    b.ToTable("Oblast");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Odgovor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Esejsko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PitanjeId")
                        .HasColumnType("int");

                    b.Property<bool>("Tacan")
                        .HasColumnType("bit");

                    b.Property<string>("Tekst")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PitanjeId");

                    b.ToTable("Odgovor");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Pitanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrojBodova")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OblastId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipPitanjaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OblastId");

                    b.HasIndex("ProfesorId");

                    b.HasIndex("TipPitanjaId");

                    b.ToTable("Pitanje");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.ProfesoriPredmeti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PredmetId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PredmetId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("ProfesoriPredmeti");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Razred", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RazredBroj")
                        .HasColumnType("int");

                    b.Property<string>("RazredKlasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipSkoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipSkoleId");

                    b.ToTable("Razred");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.RazrediProfesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<int>("RazredId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfesorId");

                    b.HasIndex("RazredId");

                    b.ToTable("RazrediProfesor");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RazredId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RazredId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.StudentiTestovi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumPocetka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZavrsetka")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<int>("UkupnoBodova")
                        .HasColumnType("int");

                    b.Property<bool>("Zavrsen")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TestId");

                    b.ToTable("StudentiTestovi");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.StudentiTestoviOdgovori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OdgovorId")
                        .HasColumnType("int");

                    b.Property<int>("StudentiTestoviId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OdgovorId");

                    b.HasIndex("StudentiTestoviId");

                    b.ToTable("StudentiTestoviOdgovori");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<DateTime>("AktivanDo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PredmetId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<int>("Trajanje")
                        .HasColumnType("int");

                    b.Property<int>("UkupnoBodova")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PredmetId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.TestoviPitanja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PitanjeId")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PitanjeId");

                    b.HasIndex("TestId");

                    b.ToTable("TestoviPitanja");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.TipPitanja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipPitanja");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.TipSkole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipSkole");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Materijal", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Oblast", "Oblast")
                        .WithMany()
                        .HasForeignKey("OblastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.API.Modeli.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oblast");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Oblast", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predmet");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Odgovor", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Pitanje", "Pitanje")
                        .WithMany()
                        .HasForeignKey("PitanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pitanje");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Pitanje", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Oblast", "Oblast")
                        .WithMany()
                        .HasForeignKey("OblastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.API.Modeli.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.API.Modeli.TipPitanja", "TipPitanja")
                        .WithMany()
                        .HasForeignKey("TipPitanjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oblast");

                    b.Navigation("Profesor");

                    b.Navigation("TipPitanja");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.ProfesoriPredmeti", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.API.Modeli.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predmet");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Razred", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.TipSkole", "TipSkole")
                        .WithMany()
                        .HasForeignKey("TipSkoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipSkole");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.RazrediProfesor", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.API.Modeli.Razred", "Razred")
                        .WithMany()
                        .HasForeignKey("RazredId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profesor");

                    b.Navigation("Razred");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Student", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Razred", "Razred")
                        .WithMany()
                        .HasForeignKey("RazredId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Razred");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.StudentiTestovi", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.API.Modeli.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.StudentiTestoviOdgovori", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Odgovor", "Odgovor")
                        .WithMany()
                        .HasForeignKey("OdgovorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.API.Modeli.StudentiTestovi", "StudentiTestovi")
                        .WithMany()
                        .HasForeignKey("StudentiTestoviId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Odgovor");

                    b.Navigation("StudentiTestovi");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.Test", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.API.Modeli.Profesor", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Predmet");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Hackathon.API.Modeli.TestoviPitanja", b =>
                {
                    b.HasOne("Hackathon.API.Modeli.Pitanje", "Pitanje")
                        .WithMany()
                        .HasForeignKey("PitanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackathon.API.Modeli.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pitanje");

                    b.Navigation("Test");
                });
#pragma warning restore 612, 618
        }
    }
}
