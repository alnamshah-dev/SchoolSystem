namespace SchoolSystem.Application.Features.Grades.Queries.GetGradeById;
public record GetGradeByIdQuery(Guid GradeId) : IQuery<GetGradeByIdResult>;
public record GetGradeByIdResult(GradeDto Grade);