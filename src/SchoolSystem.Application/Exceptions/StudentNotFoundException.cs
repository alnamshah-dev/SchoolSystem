namespace SchoolSystem.Application.Exceptions;

public class StudentNotFoundException:NotFoundException
{
    public StudentNotFoundException(Guid Id) : base("Student", Id)
    {
    }
}
