using StudentRosterDbApi.Models;

namespace StudentRosterDbApi.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Course { get; set; } = string.Empty;
    public int YearLevel { get; set; }

    // One-to-Many Foreign Key
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    // Many-to-Many Navigation Property
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}