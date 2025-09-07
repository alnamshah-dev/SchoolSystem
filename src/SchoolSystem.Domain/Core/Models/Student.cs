namespace SchoolSystem.Domain.Core.Models;
public class Student
{
    public Guid Id { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public Guid ClassId { get; set; } =default!;
    public Class Class { get; set; } = default!;
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();

}
