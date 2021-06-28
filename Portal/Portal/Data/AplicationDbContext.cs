using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Portal.Models;
using Portal.Models.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Data
{
    public class AplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Course> courses { get; set; }
        public DbSet<Border> borders { get; set; }
        public DbSet<BorderMark> borderMarks { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<SchoolDay> schoolDays { get; set; }
        public DbSet<Numerator> numeratorSchedules { get; set; }
        public DbSet<Denominator> denominatorSchedules { get; set; }
        public DbSet<Answer> answers { get; set; }
        public DbSet<SubjectMark> answerMarks { get; set; }
        public DbSet<FinallyMark> finallyMarks { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<RegistrationApplication> registrationApplications { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<UserImage> userImages { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasMany<Notification>(x => x.notifications).WithOne()
                .HasForeignKey(y => y.personalNumber);
            builder.Entity<User>().HasOne<UserImage>(x => x.image).WithOne()
                .HasForeignKey<UserImage>(y => y.userId);

            builder.Entity<Student>().HasOne<Group>(x => x.group).WithMany(y => y.students);
            builder.Entity<Student>().HasMany<Answer>(x => x.answers).WithOne(y => y.student);
            builder.Entity<Student>().HasMany<FinallyMark>(x => x.marks).WithOne(y => y.student);

            builder.Entity<Course>().HasMany<Border>(x => x.borders).WithOne(y => y.course);
            builder.Entity<Course>().HasMany<FinallyMark>(x => x.marks).WithOne(y => y.course);
            builder.Entity<Course>().HasOne<Teacher>(x => x.teacher).WithMany(y => y.courses);

            builder.Entity<Border>().HasMany<Subject>(x => x.subjects).WithOne(y => y.border);
            builder.Entity<Border>().HasMany<BorderMark>(x => x.marks).WithOne(y => y.border);

            builder.Entity<Subject>().HasMany<Answer>(x => x.answers).WithOne(y => y.subject);
            builder.Entity<Answer>().HasOne<SubjectMark>(x => x.mark)
                .WithOne().HasForeignKey<SubjectMark>(x => x.answerId);

            builder.Entity<Teacher>().HasOne<Group>(x => x.group).WithOne(y => y.curator).
                HasForeignKey<Group>(z => z.curatorId);

            builder.Entity<Numerator>().HasMany<SchoolDay>(x => x.days).WithOne(y => y.numerator);
            builder.Entity<Denominator>().HasMany<SchoolDay>(x => x.days).WithOne(y => y.denominator);

            builder.Entity<Group>().HasMany<Course>(x => x.courses).WithOne(y => y.group);
            builder.Entity<Group>().HasOne<Denominator>(x => x.denominatorSchedule)
                .WithOne().HasForeignKey<Denominator>(x => x.groupId);
            builder.Entity<Group>().HasOne<Numerator>(x => x.numeratorSchedule)
                .WithOne().HasForeignKey<Numerator>(x => x.groupId);

            base.OnModelCreating(builder);
        }
    }
}
