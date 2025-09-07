using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Domain.Core.Models;
public class Grade
{
    public Guid Id { get; set; } = default!;
    public decimal Score { get; set; }= default!;
    public Guid StudentId { get; set; } = default!;
    public Student Student { get; set; } = default!;
    public Guid SubjectId { get; set; }=default!;
    public Subject Subject { get; set; } = default!;
}
