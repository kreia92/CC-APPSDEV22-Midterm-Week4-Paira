// 7 references
public class StudentDto
{
    // 1 reference
    public int Id { get; set; }

    // 0 references
    public string FirstName { get; set; } = string.Empty;

    // 0 references
    public string LastName { get; set; } = string.Empty;

    // 1 reference
    public string DepartmentName { get; set; } = string.Empty; // Flattened from Department.Name
}