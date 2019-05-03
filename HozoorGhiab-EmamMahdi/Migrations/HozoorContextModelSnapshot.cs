﻿// <auto-generated />
using System;
using HozoorGhiabEmamMahdi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HozoorGhiabEmamMahdi.Migrations
{
    [DbContext(typeof(HozoorContext))]
    partial class HozoorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HozoorGhiabEmamMahdi.Models.Doroos", b =>
                {
                    b.Property<int>("DoroosId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<int>("DarsTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OstadId");

                    b.Property<bool>("Status");

                    b.HasKey("DoroosId");

                    b.HasIndex("OstadId");

                    b.ToTable("Dorooses");
                });

            modelBuilder.Entity("HozoorGhiabEmamMahdi.Models.Doroos_User", b =>
                {
                    b.Property<int>("DoroosId");

                    b.Property<int>("UserId");

                    b.HasKey("DoroosId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Doroos_Users");
                });

            modelBuilder.Entity("HozoorGhiabEmamMahdi.Models.Hozoor", b =>
                {
                    b.Property<int>("HozoorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DarsId");

                    b.Property<bool>("Hazer");

                    b.Property<DateTime>("Tarikh");

                    b.Property<int>("UserId");

                    b.HasKey("HozoorId");

                    b.HasIndex("DarsId");

                    b.HasIndex("UserId");

                    b.ToTable("Hozoors");
                });

            modelBuilder.Entity("HozoorGhiabEmamMahdi.Models.Ostad", b =>
                {
                    b.Property<int>("OstadId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account");

                    b.Property<string>("Address");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Tell")
                        .HasMaxLength(11);

                    b.HasKey("OstadId");

                    b.ToTable("Ostads");
                });

            modelBuilder.Entity("HozoorGhiabEmamMahdi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("Tell")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HozoorGhiabEmamMahdi.Models.Doroos", b =>
                {
                    b.HasOne("HozoorGhiabEmamMahdi.Models.Ostad", "Ostad")
                        .WithMany("Dorooses")
                        .HasForeignKey("OstadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HozoorGhiabEmamMahdi.Models.Doroos_User", b =>
                {
                    b.HasOne("HozoorGhiabEmamMahdi.Models.Doroos", "Doroos")
                        .WithMany("Doroos_Users")
                        .HasForeignKey("DoroosId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HozoorGhiabEmamMahdi.Models.User", "User")
                        .WithMany("Doroos_Users")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HozoorGhiabEmamMahdi.Models.Hozoor", b =>
                {
                    b.HasOne("HozoorGhiabEmamMahdi.Models.Doroos", "Dars")
                        .WithMany("Hozoors")
                        .HasForeignKey("DarsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HozoorGhiabEmamMahdi.Models.User", "User")
                        .WithMany("Hozoors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
