namespace SchoolSystem.Application.Dtos;
public record TeacherDto(
    Guid Id,
    string FirstName,
    string LastName,
    string PhoneNumber,
    List<ClassDto> Classes,
    List<ScheduleDto> Schedules,
    List<SubjectDto> Subjects
);
