﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NginxDashCore.Data;

namespace NginxDashCore.Migrations
{
    [DbContext(typeof(NginxDashContext))]
    partial class NginxDashContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("NginxDashCore.Data.Entities.Domain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfMd5Sum")
                        .HasMaxLength(32);

                    b.Property<bool>("ForceHttps");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("LastConf")
                        .HasColumnType("text");

                    b.Property<string>("Name");

                    b.Property<string>("TestConf")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("NginxDashCore.Data.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<string>("ConfMd5Sum")
                        .HasMaxLength(32);

                    b.Property<string>("LastConf")
                        .HasColumnType("text");

                    b.Property<string>("Match")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Modifier");

                    b.Property<Guid?>("SubdomainId");

                    b.Property<string>("TestConf")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SubdomainId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("NginxDashCore.Data.Entities.LocationSetting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Directive");

                    b.Property<Guid?>("LocationId");

                    b.Property<string>("value");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationSetting");
                });

            modelBuilder.Entity("NginxDashCore.Data.Entities.Subdomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfMd5Sum")
                        .HasMaxLength(32);

                    b.Property<Guid?>("DomainId");

                    b.Property<bool>("ForceHttps");

                    b.Property<bool>("IsDomainRoot");

                    b.Property<string>("LastConf")
                        .HasColumnType("text");

                    b.Property<string>("Name");

                    b.Property<string>("TestConf")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.ToTable("Subdomains");
                });

            modelBuilder.Entity("NginxDashCore.Data.Entities.Location", b =>
                {
                    b.HasOne("NginxDashCore.Data.Entities.Subdomain")
                        .WithMany("Locations")
                        .HasForeignKey("SubdomainId");
                });

            modelBuilder.Entity("NginxDashCore.Data.Entities.LocationSetting", b =>
                {
                    b.HasOne("NginxDashCore.Data.Entities.Location")
                        .WithMany("Settings")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("NginxDashCore.Data.Entities.Subdomain", b =>
                {
                    b.HasOne("NginxDashCore.Data.Entities.Domain")
                        .WithMany("Subdomains")
                        .HasForeignKey("DomainId");
                });
#pragma warning restore 612, 618
        }
    }
}
