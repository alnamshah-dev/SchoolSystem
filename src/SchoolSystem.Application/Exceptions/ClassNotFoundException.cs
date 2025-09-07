namespace SchoolSystem.Application.Exceptions;

public class ClassNotFoundException: NotFoundException
{
    public ClassNotFoundException(Guid Id) : base("Class", Id)
    {
    }
}
