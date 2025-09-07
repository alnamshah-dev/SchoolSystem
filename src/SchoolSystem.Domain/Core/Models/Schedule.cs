namespace SchoolSystem.Domain.Core.Models;
public class Schedule
{
    public Guid Id { get; set; } = default!;
    public Guid ClassId { get; set; } = default!;
    public DayOfWeek DayOfWeek { get; set; } = default!;
    public DateTime StartTime { get; set; } = default!;
    public DateTime EndTime { get; set; } = default!;
    public string RoomNumber { get; set; } = default!;
    public Class Class { get; set; } = default!;
    public Guid SubjectId { get; set; } = default!;
    public Subject Subject { get; set; } = default!;
    public Guid TeacherId { get; set; } =default!;
    public Teacher Teacher { get; set; } = default!;
}