namespace SchoolSystem.Domain.Core.Models;
public class Subject
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public Guid TeacherId { get; set; } = default!;
    public Teacher Teacher { get; set; } = default!;
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    public ICollection<Class> Classes { get; set; } = new List<Class>();

}
