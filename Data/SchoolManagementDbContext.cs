using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementApp.MVC.Data;

public partial class SchoolManagementDbContext : DbContext
{
    public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC07EA8C925D");

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Classes__CourseI__4BAC3F29");

            entity.HasOne(d => d.Lecture).WithMany(p => p.Classes)
                .HasForeignKey(d => d.LectureId)
                .HasConstraintName("FK__Classes__Lecture__4AB81AF0");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC276BB93C9C");

            entity.HasIndex(e => e.Code, "UQ__Courses__A25C5AA7CF358703").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enrollme__3214EC070C7A9077");

            entity.Property(e => e.Grade).HasMaxLength(2);

            entity.HasOne(d => d.Class).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Enrollmen__Class__4F7CD00D");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Enrollmen__Stude__4E88ABD4");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lectures__3214EC27E74402AE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("LASTNAME");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC27811F0634");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("LASTNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
