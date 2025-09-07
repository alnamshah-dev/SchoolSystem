namespace SchoolSystem.Application.Features.Students.Queries.GetStudents;
public record GetStudentsQuery(PaginationRequest PaginationRequest) : IQuery<GetStudentsResult>;
public record GetStudentsResult(PaginatedResult<StudentDto> Students);