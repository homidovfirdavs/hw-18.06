using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options): DbContext (options)
{
public DbSet<Instructor> Instructors { get; set; }
public DbSet<Course> Courses { get; set; }
public DbSet<CourseAssignment> CourseAssignments { get; set; }
public DbSet<Student> Students { get; set; }
public DbSet<Enrollment> Enrollments { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Instructor>()
        .HasMany(i => i.CourseAssignments)
        .WithOne(c => c.Instructor)
        .HasForeignKey(c => c.InstructorId);
    modelBuilder.Entity<Course>()
        .HasMany(c => c.Enrollments)
        .WithOne(e => e.Course)
        .HasForeignKey(c => c.CourseId);
    modelBuilder.Entity<Course>()
        .HasMany(c => c.CourseAssignments)
        .WithOne(c => c.Course)
        .HasForeignKey(c => c.CourseId);
    modelBuilder.Entity<Student>()
        .HasMany(s => s.Enrollments)
        .WithOne(e => e.Student)
        .HasForeignKey(s => s.StudentId);
        
}


}