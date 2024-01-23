﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcSupreMarketCrudveResimEkleme.Data.Context;

#nullable disable

namespace MvcSupreMarketCrudveResimEkleme.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20240123134131_Ilk")]
    partial class Ilk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MvcSupreMarketCrudveResimEkleme.Data.Class.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("kategoriler");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ad = "Su & İçecek"
                        },
                        new
                        {
                            Id = 2,
                            Ad = "Meyve & Sebze"
                        },
                        new
                        {
                            Id = 3,
                            Ad = "Süt Ürünleri"
                        },
                        new
                        {
                            Id = 4,
                            Ad = "Atıştırmalık"
                        },
                        new
                        {
                            Id = 5,
                            Ad = "Temel Gıda"
                        },
                        new
                        {
                            Id = 6,
                            Ad = "Kahvaltılık"
                        },
                        new
                        {
                            Id = 7,
                            Ad = "Fırından"
                        },
                        new
                        {
                            Id = 8,
                            Ad = "Kişisel Bakım"
                        },
                        new
                        {
                            Id = 9,
                            Ad = "Evcil Hayvan"
                        },
                        new
                        {
                            Id = 10,
                            Ad = "Ev Bakım"
                        });
                });

            modelBuilder.Entity("MvcSupreMarketCrudveResimEkleme.Data.Class.Resim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DosyaTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DosyaYolu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UrunId")
                        .IsUnique();

                    b.ToTable("resimler");
                });

            modelBuilder.Entity("MvcSupreMarketCrudveResimEkleme.Data.Class.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SatistanKaldirilmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("StokMiktari")
                        .HasColumnType("int");

                    b.Property<bool>("StotkataMi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KategoriId");

                    b.ToTable("urunler");
                });

            modelBuilder.Entity("MvcSupreMarketCrudveResimEkleme.Data.Class.Resim", b =>
                {
                    b.HasOne("MvcSupreMarketCrudveResimEkleme.Data.Class.Urun", "Urun")
                        .WithOne("Resim")
                        .HasForeignKey("MvcSupreMarketCrudveResimEkleme.Data.Class.Resim", "UrunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("MvcSupreMarketCrudveResimEkleme.Data.Class.Urun", b =>
                {
                    b.HasOne("MvcSupreMarketCrudveResimEkleme.Data.Class.Kategori", "Kategori")
                        .WithMany("Urunler")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("MvcSupreMarketCrudveResimEkleme.Data.Class.Kategori", b =>
                {
                    b.Navigation("Urunler");
                });

            modelBuilder.Entity("MvcSupreMarketCrudveResimEkleme.Data.Class.Urun", b =>
                {
                    b.Navigation("Resim");
                });
#pragma warning restore 612, 618
        }
    }
}
