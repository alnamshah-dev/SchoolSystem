namespace SchoolSystem.Application.Features.Students.Queries.GetStudentById;

public record GetStudentByIdQuery(Guid StudentId) : IQuery<GetStudentByIdResult>;
public record GetStudentByIdResult(StudentDto Student);