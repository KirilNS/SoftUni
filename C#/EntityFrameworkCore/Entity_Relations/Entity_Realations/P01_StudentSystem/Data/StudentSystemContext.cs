using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DataSetting.ConectionString);
            }
        }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode();

                entity.Property(p => p.PhoneNumber)
                .HasColumnType("CHAR(10)");

                entity.Property(p => p.RegisteredOn)
                .HasDefaultValue(DateTime.Now);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(p => p.CourseId);

                entity.Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

                entity.Property(p => p.Description)
                .IsUnicode();

                entity.Property(p => p.StartDate)
                .IsRequired();

                entity.Property(p => p.EndDate)
                .IsRequired();

                entity.Property(p => p.Price)
                .IsRequired();
            });

            modelBuilder.Entity<Resource>(entity=> 
            {
                entity.HasKey(p => p.ResourceId);

                entity.Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

                entity.Property(p => p.Url)
                .IsRequired();

                entity.Property(p => p.ResourceType)
                .IsRequired();

                entity.HasOne(c => c.Course)
                .WithMany(r => r.Resources)
                .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(p => p.HomeworkId);

                entity.Property(p => p.Content)
                .IsRequired();

                entity.Property(p => p.ContentType)
                .IsRequired();

                entity.Property(p => p.SubmissionTime)
                .IsRequired();

                entity.HasOne(e => e.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(e => e.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasOne(s => s.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(s => s.StudentId);

                entity.HasOne(s => s.Course)
                .WithMany(s => s.StudentsEnrolled)
                .HasForeignKey(s => s.CourseId);

                entity.HasKey(s => new { s.CourseId, s.StudentId });
                
            });
        }



    }
}
