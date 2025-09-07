namespace SchoolSystem.Application.Dtos;
public record ScheduleDto(
    Guid Id,
    Guid ClassId,
    DayOfWeek DayOfWeek,
    DateTime StartTime,
    DateTime EndTime,
    string RoomNumber,
    Guid SubjectId,
    Guid TeacherId
);
