// 2 references
public class AuditLog
{
    // 0 references
    public int Id { get; set; }

    // 1 reference
    public string Action { get; set; } = string.Empty;

    // 0 references
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}