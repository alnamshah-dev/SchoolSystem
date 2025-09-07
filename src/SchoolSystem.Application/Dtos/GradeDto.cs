namespace SchoolSystem.Application.Dtos;
public record GradeDto(
    Guid Id,
    decimal Score,
    Guid StudentId,
    Guid SubjectId
);

