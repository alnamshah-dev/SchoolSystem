namespace SchoolSystem.Application.Dtos;
public record ClassDto(
    Guid Id,
    string Name,
    string Section,
    string RoomNumber,
    List<TeacherDto> Teachers,
    List<SubjectDto> Subjects,
    List<StudentDto> Students,
    List<ScheduleDto> Schedules
);
