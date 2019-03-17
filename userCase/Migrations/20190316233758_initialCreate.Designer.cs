﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using userCase.Models;

namespace userCase.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20190316233758_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("userCase.Models.City", b =>
                {
                    b.Property<int>("cityID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cityCode");

                    b.Property<string>("cityName")
                        .HasMaxLength(100);

                    b.HasKey("cityID");

                    b.ToTable("cities");

                    b.HasData(
                        new { cityID = 1, cityCode = 1, cityName = "Adana" },
                        new { cityID = 2, cityCode = 2, cityName = "Adıyaman" },
                        new { cityID = 3, cityCode = 3, cityName = "Afyon" },
                        new { cityID = 4, cityCode = 4, cityName = "Ağrı" },
                        new { cityID = 5, cityCode = 5, cityName = "Amasya" },
                        new { cityID = 6, cityCode = 34, cityName = "İstanbul" },
                        new { cityID = 7, cityCode = 35, cityName = "İzmir" }
                    );
                });

            modelBuilder.Entity("userCase.Models.District", b =>
                {
                    b.Property<int>("districtID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cityID");

                    b.Property<int>("districtCode")
                        .HasMaxLength(100);

                    b.Property<string>("districtName")
                        .HasMaxLength(100);

                    b.HasKey("districtID");

                    b.ToTable("districts");

                    b.HasData(
                        new { districtID = 1, cityID = 1, districtCode = 1104, districtName = "SEYHAN" },
                        new { districtID = 2, cityID = 1, districtCode = 1219, districtName = "CEYHAN" },
                        new { districtID = 3, cityID = 1, districtCode = 1329, districtName = "FEKE" },
                        new { districtID = 4, cityID = 2, districtCode = 1105, districtName = "MERKEZ" },
                        new { districtID = 5, cityID = 2, districtCode = 1182, districtName = "BESNİ" },
                        new { districtID = 6, cityID = 2, districtCode = 1246, districtName = "ÇELİKHAN" },
                        new { districtID = 7, cityID = 3, districtCode = 1103, districtName = "ADALAR" },
                        new { districtID = 8, cityID = 3, districtCode = 1166, districtName = "BAKIRKÖY" },
                        new { districtID = 9, cityID = 3, districtCode = 1183, districtName = "BEŞİKTAŞ" },
                        new { districtID = 10, cityID = 3, districtCode = 1203, districtName = "BORNOVA" },
                        new { districtID = 11, cityID = 3, districtCode = 1251, districtName = "ÇEŞME" }
                    );
                });

            modelBuilder.Entity("userCase.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("birthdate");

                    b.Property<int>("cityID");

                    b.Property<int>("districtID");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("name")
                        .HasMaxLength(100);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("surname")
                        .HasMaxLength(100);

                    b.HasKey("userID");

                    b.HasIndex("cityID");

                    b.HasIndex("districtID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("userCase.Models.User", b =>
                {
                    b.HasOne("userCase.Models.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("cityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("userCase.Models.District", "District")
                        .WithMany("Users")
                        .HasForeignKey("districtID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}