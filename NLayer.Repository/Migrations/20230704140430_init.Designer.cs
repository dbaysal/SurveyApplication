﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230704140430_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NLayer.Core.Models.CheckBoxSurveyQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("CheckBoxSurveyQuestions");
                });

            modelBuilder.Entity("NLayer.Core.Models.RadioButtonSurveyQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("RadioButtonSurveyQuestions");
                });

            modelBuilder.Entity("NLayer.Core.Models.RatingSurveyQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.Property<int>("TotalRating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("RatingSurveyQuestion");
                });

            modelBuilder.Entity("NLayer.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SurveyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalParticipation")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("NLayer.Core.Models.SurveyQuestionItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CheckBoxSurveyQuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RadioButtonSurveyQuestionId")
                        .HasColumnType("int");

                    b.Property<int>("TotalSelected")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CheckBoxSurveyQuestionId");

                    b.HasIndex("RadioButtonSurveyQuestionId");

                    b.ToTable("SurveyQuestionItems");
                });

            modelBuilder.Entity("NLayer.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "admin123",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "123",
                            Username = "default user"
                        });
                });

            modelBuilder.Entity("NLayer.Core.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("NLayer.Core.Models.CheckBoxSurveyQuestion", b =>
                {
                    b.HasOne("NLayer.Core.Models.Survey", null)
                        .WithMany("CheckBoxSurveyQuestions")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("NLayer.Core.Models.RadioButtonSurveyQuestion", b =>
                {
                    b.HasOne("NLayer.Core.Models.Survey", null)
                        .WithMany("RadioButtonSurveyQuestions")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("NLayer.Core.Models.RatingSurveyQuestion", b =>
                {
                    b.HasOne("NLayer.Core.Models.Survey", null)
                        .WithMany("RatingSurveyQuestions")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("NLayer.Core.Models.Survey", b =>
                {
                    b.HasOne("NLayer.Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NLayer.Core.Models.SurveyQuestionItem", b =>
                {
                    b.HasOne("NLayer.Core.Models.CheckBoxSurveyQuestion", null)
                        .WithMany("SurveyQuestionItems")
                        .HasForeignKey("CheckBoxSurveyQuestionId");

                    b.HasOne("NLayer.Core.Models.RadioButtonSurveyQuestion", null)
                        .WithMany("SurveyQuestionItems")
                        .HasForeignKey("RadioButtonSurveyQuestionId");
                });

            modelBuilder.Entity("NLayer.Core.Models.UserRole", b =>
                {
                    b.HasOne("NLayer.Core.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NLayer.Core.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NLayer.Core.Models.CheckBoxSurveyQuestion", b =>
                {
                    b.Navigation("SurveyQuestionItems");
                });

            modelBuilder.Entity("NLayer.Core.Models.RadioButtonSurveyQuestion", b =>
                {
                    b.Navigation("SurveyQuestionItems");
                });

            modelBuilder.Entity("NLayer.Core.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("NLayer.Core.Models.Survey", b =>
                {
                    b.Navigation("CheckBoxSurveyQuestions");

                    b.Navigation("RadioButtonSurveyQuestions");

                    b.Navigation("RatingSurveyQuestions");
                });

            modelBuilder.Entity("NLayer.Core.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
