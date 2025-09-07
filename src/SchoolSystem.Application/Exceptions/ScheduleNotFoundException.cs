namespace SchoolSystem.Application.Exceptions;
public class ScheduleNotFoundException: NotFoundException
{
    public ScheduleNotFoundException(Guid Id) : base("Schedule", Id)
    {
    }
}
