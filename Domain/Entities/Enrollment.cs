﻿namespace Domain.Entities;

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollDate { get; set; }
    public int Grade { get; set; }
    
    public Student Student { get; set; }
    public Course Course { get; set; }
}