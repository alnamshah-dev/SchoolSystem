namespace SchoolSystem.Application.Extensions;

public static class ScheduleExtensions
{
    public static IQueryable<ScheduleDto> ToScheduleDtoList(this IQueryable<Schedule> query)
    {
        return query.Select(schedule => new ScheduleDto(
            schedule.Id,
            schedule.ClassId,
            schedule.DayOfWeek,
            schedule.StartTime,
            schedule.EndTime,
            schedule.RoomNumber,
            schedule.SubjectId,
            schedule.TeacherId
        ));
    }

    public static ScheduleDto ToScheduleDto(this Schedule schedule)
    {
        return DtoFromSchedule(schedule);
    }

    public static ScheduleDto DtoFromSchedule(Schedule schedule)
    {
        return new ScheduleDto(
            schedule.Id,
            schedule.ClassId,
            schedule.DayOfWeek,
            schedule.StartTime,
            schedule.EndTime,
            schedule.RoomNumber,
            schedule.SubjectId,
            schedule.TeacherId
        );
    }
}

