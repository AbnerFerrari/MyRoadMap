﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyRoadMap.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyRoadMap.Infrastructure.Migrations
{
    [DbContext(typeof(MyRoadMapContext))]
    partial class MyRoadMapContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("MyRoadMap.Domain.Model.Entities.RoadMap", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_road_maps");

                    b.ToTable("road_maps", (string)null);
                });

            modelBuilder.Entity("MyRoadMap.Domain.Model.Entities.Step", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("Done")
                        .HasColumnType("boolean")
                        .HasColumnName("done");

                    b.Property<int>("Index")
                        .HasColumnType("integer")
                        .HasColumnName("index");

                    b.Property<long>("RoadMapId")
                        .HasColumnType("bigint")
                        .HasColumnName("road_map_id");

                    b.HasKey("Id")
                        .HasName("pk_steps");

                    b.HasIndex("RoadMapId")
                        .HasDatabaseName("ix_steps_road_map_id");

                    b.ToTable("steps", (string)null);
                });

            modelBuilder.Entity("MyRoadMap.Domain.Model.Entities.Step", b =>
                {
                    b.HasOne("MyRoadMap.Domain.Model.Entities.RoadMap", "RoadMap")
                        .WithMany("Steps")
                        .HasForeignKey("RoadMapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_steps_road_maps_road_map_id");

                    b.Navigation("RoadMap");
                });

            modelBuilder.Entity("MyRoadMap.Domain.Model.Entities.RoadMap", b =>
                {
                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}