﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portal.Data;

namespace Portal.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20210605191809_Image")]
    partial class Image
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Portal.Models.Abstract.Denominator", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("groupId")
                        .IsUnique();

                    b.ToTable("denominatorSchedules");
                });

            modelBuilder.Entity("Portal.Models.Abstract.Numerator", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("groupId")
                        .IsUnique();

                    b.ToTable("numeratorSchedules");
                });

            modelBuilder.Entity("Portal.Models.Answer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("studentid")
                        .HasColumnType("int");

                    b.Property<int?>("subjectid")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("studentid");

                    b.HasIndex("subjectid");

                    b.ToTable("answers");
                });

            modelBuilder.Entity("Portal.Models.Border", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNow")
                        .HasColumnType("bit");

                    b.Property<int?>("courseid")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateOfBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfFinish")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numberOfPairs")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("courseid");

                    b.ToTable("borders");
                });

            modelBuilder.Entity("Portal.Models.BorderMark", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("borderid")
                        .HasColumnType("int");

                    b.Property<int?>("studentid")
                        .HasColumnType("int");

                    b.Property<double>("valueOfMark")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("borderid");

                    b.HasIndex("studentid");

                    b.ToTable("borderMarks");
                });

            modelBuilder.Entity("Portal.Models.Course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("groupid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numberOfBorders")
                        .HasColumnType("int");

                    b.Property<int?>("teacherid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("groupid");

                    b.HasIndex("teacherid");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("Portal.Models.FinallyMark", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("courseid")
                        .HasColumnType("int");

                    b.Property<int?>("studentid")
                        .HasColumnType("int");

                    b.Property<double>("valueOfMark")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("courseid");

                    b.HasIndex("studentid");

                    b.ToTable("finallyMarks");
                });

            modelBuilder.Entity("Portal.Models.Group", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsNowNumerator")
                        .HasColumnType("bit");

                    b.Property<int>("curatorId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("curatorId")
                        .IsUnique();

                    b.ToTable("groups");
                });

            modelBuilder.Entity("Portal.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("head")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("personalNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("personalNumber");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("Portal.Models.RegistrationApplication", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsTeacher")
                        .HasColumnType("bit");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("registrationApplications");
                });

            modelBuilder.Entity("Portal.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Portal.Models.SchoolDay", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("denominatorid")
                        .HasColumnType("int");

                    b.Property<string>("firstCourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("numeratorid")
                        .HasColumnType("int");

                    b.Property<string>("secondCourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("secondTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("thirdCourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("thirdTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("denominatorid");

                    b.HasIndex("numeratorid");

                    b.ToTable("schoolDays");
                });

            modelBuilder.Entity("Portal.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsHasGroup")
                        .HasColumnType("bit");

                    b.Property<DateTime>("dateOfBirthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfRegister")
                        .HasColumnType("datetime2");

                    b.Property<int?>("groupid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numberOfAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pageNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("speciality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("groupid");

                    b.ToTable("students");
                });

            modelBuilder.Entity("Portal.Models.Subject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsExpired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<bool>("IsToday")
                        .HasColumnType("bit");

                    b.Property<int?>("borderid")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("task")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("time")
                        .HasColumnType("time");

                    b.Property<DateTime>("timeBorderForAnswer")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("borderid");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("Portal.Models.SubjectMark", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("answerId")
                        .HasColumnType("int");

                    b.Property<int?>("studentid")
                        .HasColumnType("int");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.Property<double>("valueOfMark")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("answerId")
                        .IsUnique();

                    b.HasIndex("studentid");

                    b.ToTable("answerMarks");
                });

            modelBuilder.Entity("Portal.Models.Teacher", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsHasGroup")
                        .HasColumnType("bit");

                    b.Property<DateTime>("dateOfBirthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dateOfRegister")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numberOfAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("teachers");
                });

            modelBuilder.Entity("Portal.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTeacher")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Portal.Models.UserImage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fullPuth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("userImages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Portal.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Portal.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Portal.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Portal.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Portal.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Models.Abstract.Denominator", b =>
                {
                    b.HasOne("Portal.Models.Group", null)
                        .WithOne("denominatorSchedule")
                        .HasForeignKey("Portal.Models.Abstract.Denominator", "groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Models.Abstract.Numerator", b =>
                {
                    b.HasOne("Portal.Models.Group", null)
                        .WithOne("numeratorSchedule")
                        .HasForeignKey("Portal.Models.Abstract.Numerator", "groupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Models.Answer", b =>
                {
                    b.HasOne("Portal.Models.Student", "student")
                        .WithMany("answers")
                        .HasForeignKey("studentid");

                    b.HasOne("Portal.Models.Subject", "subject")
                        .WithMany("answers")
                        .HasForeignKey("subjectid");

                    b.Navigation("student");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("Portal.Models.Border", b =>
                {
                    b.HasOne("Portal.Models.Course", "course")
                        .WithMany("borders")
                        .HasForeignKey("courseid");

                    b.Navigation("course");
                });

            modelBuilder.Entity("Portal.Models.BorderMark", b =>
                {
                    b.HasOne("Portal.Models.Border", "border")
                        .WithMany("marks")
                        .HasForeignKey("borderid");

                    b.HasOne("Portal.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentid");

                    b.Navigation("border");

                    b.Navigation("student");
                });

            modelBuilder.Entity("Portal.Models.Course", b =>
                {
                    b.HasOne("Portal.Models.Group", "group")
                        .WithMany("courses")
                        .HasForeignKey("groupid");

                    b.HasOne("Portal.Models.Teacher", "teacher")
                        .WithMany("courses")
                        .HasForeignKey("teacherid");

                    b.Navigation("group");

                    b.Navigation("teacher");
                });

            modelBuilder.Entity("Portal.Models.FinallyMark", b =>
                {
                    b.HasOne("Portal.Models.Course", "course")
                        .WithMany("marks")
                        .HasForeignKey("courseid");

                    b.HasOne("Portal.Models.Student", "student")
                        .WithMany("marks")
                        .HasForeignKey("studentid");

                    b.Navigation("course");

                    b.Navigation("student");
                });

            modelBuilder.Entity("Portal.Models.Group", b =>
                {
                    b.HasOne("Portal.Models.Teacher", "curator")
                        .WithOne("group")
                        .HasForeignKey("Portal.Models.Group", "curatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("curator");
                });

            modelBuilder.Entity("Portal.Models.Notification", b =>
                {
                    b.HasOne("Portal.Models.User", null)
                        .WithMany("notifications")
                        .HasForeignKey("personalNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Models.SchoolDay", b =>
                {
                    b.HasOne("Portal.Models.Abstract.Denominator", "denominator")
                        .WithMany("days")
                        .HasForeignKey("denominatorid");

                    b.HasOne("Portal.Models.Abstract.Numerator", "numerator")
                        .WithMany("days")
                        .HasForeignKey("numeratorid");

                    b.Navigation("denominator");

                    b.Navigation("numerator");
                });

            modelBuilder.Entity("Portal.Models.Student", b =>
                {
                    b.HasOne("Portal.Models.Group", "group")
                        .WithMany("students")
                        .HasForeignKey("groupid");

                    b.Navigation("group");
                });

            modelBuilder.Entity("Portal.Models.Subject", b =>
                {
                    b.HasOne("Portal.Models.Border", "border")
                        .WithMany("subjects")
                        .HasForeignKey("borderid");

                    b.Navigation("border");
                });

            modelBuilder.Entity("Portal.Models.SubjectMark", b =>
                {
                    b.HasOne("Portal.Models.Answer", null)
                        .WithOne("mark")
                        .HasForeignKey("Portal.Models.SubjectMark", "answerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portal.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentid");

                    b.Navigation("student");
                });

            modelBuilder.Entity("Portal.Models.UserImage", b =>
                {
                    b.HasOne("Portal.Models.User", null)
                        .WithOne("image")
                        .HasForeignKey("Portal.Models.UserImage", "userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Models.Abstract.Denominator", b =>
                {
                    b.Navigation("days");
                });

            modelBuilder.Entity("Portal.Models.Abstract.Numerator", b =>
                {
                    b.Navigation("days");
                });

            modelBuilder.Entity("Portal.Models.Answer", b =>
                {
                    b.Navigation("mark");
                });

            modelBuilder.Entity("Portal.Models.Border", b =>
                {
                    b.Navigation("marks");

                    b.Navigation("subjects");
                });

            modelBuilder.Entity("Portal.Models.Course", b =>
                {
                    b.Navigation("borders");

                    b.Navigation("marks");
                });

            modelBuilder.Entity("Portal.Models.Group", b =>
                {
                    b.Navigation("courses");

                    b.Navigation("denominatorSchedule");

                    b.Navigation("numeratorSchedule");

                    b.Navigation("students");
                });

            modelBuilder.Entity("Portal.Models.Student", b =>
                {
                    b.Navigation("answers");

                    b.Navigation("marks");
                });

            modelBuilder.Entity("Portal.Models.Subject", b =>
                {
                    b.Navigation("answers");
                });

            modelBuilder.Entity("Portal.Models.Teacher", b =>
                {
                    b.Navigation("courses");

                    b.Navigation("group");
                });

            modelBuilder.Entity("Portal.Models.User", b =>
                {
                    b.Navigation("image");

                    b.Navigation("notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
