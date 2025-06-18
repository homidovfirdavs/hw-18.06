namespace Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    
    public List<Enrollment> Enrollments { get; set; } 
}