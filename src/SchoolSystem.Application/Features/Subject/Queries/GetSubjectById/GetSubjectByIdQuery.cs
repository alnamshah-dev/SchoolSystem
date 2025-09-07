namespace SchoolSystem.Application.Features.Subjects.Queries.GetSubjectById;
public record GetSubjectByIdQuery(Guid SubjectId) : IQuery<GetSubjectByIdResult>;
public record GetSubjectByIdResult(SubjectDto Subject);