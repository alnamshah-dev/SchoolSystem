namespace SchoolSystem.Application.Exceptions;

public class GradeNotFoundException:NotFoundException
{
    public GradeNotFoundException(Guid Id) : base("Grade", Id)
    {
    }
}
