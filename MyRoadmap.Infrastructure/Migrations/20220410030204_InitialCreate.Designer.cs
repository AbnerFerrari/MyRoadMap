﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyRoadmap.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyRoadmap.Infrastructure.Migrations
{
    [DbContext(typeof(MyRoadmapContext))]
    [Migration("20220410030204_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyRoadmap.Domain.Entities.Roadmap", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("PriorityLevel")
                        .HasColumnType("integer")
                        .HasColumnName("priority_level");

                    b.HasKey("Id")
                        .HasName("pk_roadmaps");

                    b.ToTable("roadmaps", (string)null);
                });

            modelBuilder.Entity("MyRoadmap.Domain.Entities.RoadmapItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<long>("LastRequiredItemId")
                        .HasColumnType("bigint")
                        .HasColumnName("last_required_item_id");

                    b.HasKey("Id")
                        .HasName("pk_roadmap_items");

                    b.HasIndex("LastRequiredItemId")
                        .HasDatabaseName("ix_roadmap_items_last_required_item_id");

                    b.ToTable("roadmap_items", (string)null);
                });

            modelBuilder.Entity("MyRoadmap.Domain.Entities.Topic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("goal");

                    b.HasKey("Id")
                        .HasName("pk_topics");

                    b.ToTable("topics", (string)null);
                });

            modelBuilder.Entity("MyRoadmap.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long>("RoadmapId")
                        .HasColumnType("bigint")
                        .HasColumnName("roadmap_id");

                    b.Property<long>("TopicOfInterestId")
                        .HasColumnType("bigint")
                        .HasColumnName("topic_of_interest_id");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("RoadmapId")
                        .HasDatabaseName("ix_users_roadmap_id");

                    b.HasIndex("TopicOfInterestId")
                        .HasDatabaseName("ix_users_topic_of_interest_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("MyRoadmap.Domain.Entities.RoadmapItem", b =>
                {
                    b.HasOne("MyRoadmap.Domain.Entities.Roadmap", "LastRequiredItem")
                        .WithMany("RoadmapItem")
                        .HasForeignKey("LastRequiredItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_roadmap_items_roadmaps_last_required_item_id");

                    b.Navigation("LastRequiredItem");
                });

            modelBuilder.Entity("MyRoadmap.Domain.Entities.User", b =>
                {
                    b.HasOne("MyRoadmap.Domain.Entities.Roadmap", "Roadmap")
                        .WithMany()
                        .HasForeignKey("RoadmapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_roadmaps_roadmap_id");

                    b.HasOne("MyRoadmap.Domain.Entities.Topic", "TopicOfInterest")
                        .WithMany()
                        .HasForeignKey("TopicOfInterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_topics_topic_of_interest_id");

                    b.Navigation("Roadmap");

                    b.Navigation("TopicOfInterest");
                });

            modelBuilder.Entity("MyRoadmap.Domain.Entities.Roadmap", b =>
                {
                    b.Navigation("RoadmapItem");
                });
#pragma warning restore 612, 618
        }
    }
}
