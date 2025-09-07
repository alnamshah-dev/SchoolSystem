namespace SchoolSystem.Application.Exceptions;
public class SubjectNotFoundException : NotFoundException
{
    public SubjectNotFoundException(Guid Id) : base("Subject", Id)
    {
    }
}
