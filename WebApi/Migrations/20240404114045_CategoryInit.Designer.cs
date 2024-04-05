﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Contexts;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240404114045_CategoryInit")]
    partial class CategoryInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YoutubeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseEntityId")
                        .IsUnique();

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("WebApi.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebApi.Entities.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectedOption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactForms");
                });

            modelBuilder.Entity("WebApi.Entities.CourseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArticleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DownloadResource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBestSeller")
                        .HasColumnType("bit");

                    b.Property<string>("LikesInNumbers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LikesInPercent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("WebApi.Entities.DetailsList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Detail_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail_10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail_4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail_5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail_6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail_7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail_8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail_9")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseEntityId")
                        .IsUnique();

                    b.ToTable("detailsLists");
                });

            modelBuilder.Entity("WebApi.Entities.PointList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Point_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Point_10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Point_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Point_3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Point_4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Point_5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Point_6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Point_7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Point_8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Point_9")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseEntityId")
                        .IsUnique();

                    b.ToTable("pointLists");
                });

            modelBuilder.Entity("WebApi.Entities.Reviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseEntityId")
                        .HasColumnType("int");

                    b.Property<string>("EmptyStarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullStarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewNumbers")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseEntityId")
                        .IsUnique();

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WebApi.Entities.SubscriberEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Advertising")
                        .HasColumnType("bit");

                    b.Property<bool>("DailyNews")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Events")
                        .HasColumnType("bit");

                    b.Property<bool>("Podcasts")
                        .HasColumnType("bit");

                    b.Property<bool>("Startups")
                        .HasColumnType("bit");

                    b.Property<bool>("WeekReview")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("WebApi.Entities.Author", b =>
                {
                    b.HasOne("WebApi.Entities.CourseEntity", null)
                        .WithOne("Author")
                        .HasForeignKey("WebApi.Entities.Author", "CourseEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Entities.CourseEntity", b =>
                {
                    b.HasOne("WebApi.Entities.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApi.Entities.DetailsList", b =>
                {
                    b.HasOne("WebApi.Entities.CourseEntity", null)
                        .WithOne("DetailsList")
                        .HasForeignKey("WebApi.Entities.DetailsList", "CourseEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Entities.PointList", b =>
                {
                    b.HasOne("WebApi.Entities.CourseEntity", null)
                        .WithOne("PointList")
                        .HasForeignKey("WebApi.Entities.PointList", "CourseEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Entities.Reviews", b =>
                {
                    b.HasOne("WebApi.Entities.CourseEntity", null)
                        .WithOne("Reviews")
                        .HasForeignKey("WebApi.Entities.Reviews", "CourseEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Entities.CourseEntity", b =>
                {
                    b.Navigation("Author");

                    b.Navigation("DetailsList");

                    b.Navigation("PointList");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}