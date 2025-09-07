namespace SchoolSystem.Application.Dtos;

public record StudentDto(
    Guid Id,
    string FirstName,
    string LastName,
    Guid ClassId,
    List<GradeDto> Grades
);
