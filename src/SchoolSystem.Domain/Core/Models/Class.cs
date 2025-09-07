namespace SchoolSystem.Domain.Core.Models;
public class Class
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Section { get; set; } = default!;
    public string RoomNumber { get; set; } = default!;
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}