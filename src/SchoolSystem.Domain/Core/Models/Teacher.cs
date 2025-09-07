namespace SchoolSystem.Domain.Core.Models;
public class Teacher
{
    public Guid Id { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public ICollection<Class> Classes { get; set; } = new List<Class>();
    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
