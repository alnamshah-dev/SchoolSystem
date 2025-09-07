namespace SchoolSystem.Application.Features.Subjects.Queries.GetSubjects;

public record GetSubjectsQuery(PaginationRequest PaginationRequest) : IQuery<GetSubjectsResult>;
public record GetSubjectsResult(PaginatedResult<SubjectDto> Subjects);