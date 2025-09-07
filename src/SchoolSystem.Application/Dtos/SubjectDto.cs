namespace SchoolSystem.Application.Dtos;
public record SubjectDto(
    Guid SubjectId,
    string Name,
    string? Description,
    Guid TeacherId,
    List<GradeDto> Grades,
    List<ScheduleDto> Schedules,
    List<ClassDto> Classes
);

