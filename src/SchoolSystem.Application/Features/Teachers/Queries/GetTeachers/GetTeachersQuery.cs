namespace SchoolSystem.Application.Features.Teachers.Queries.GetTeachers;
public record GetTeachersQuery(PaginationRequest PaginationRequest) : IQuery<GetTeachersResult>;
public record GetTeachersResult(PaginatedResult<TeacherDto> Teachers);