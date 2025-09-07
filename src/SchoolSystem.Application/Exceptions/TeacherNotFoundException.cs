namespace SchoolSystem.Application.Exceptions;
public class TeacherNotFoundException: NotFoundException
{
    public TeacherNotFoundException(Guid Id) : base("Teacher", Id)
    {
    }
}
