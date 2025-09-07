namespace SchoolSystem.Application.Features.Grades.Queries.GetGrades;
public record GetGradesQuery(PaginationRequest PaginationRequest) : IQuery<GetGradesResult>;
public record GetGradesResult(PaginatedResult<GradeDto> Grades);
