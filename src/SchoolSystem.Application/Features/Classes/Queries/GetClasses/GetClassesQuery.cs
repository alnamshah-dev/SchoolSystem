namespace SchoolSystem.Application.Features.Classes.Queries.GetClasses;
public record GetClassesQuery(PaginationRequest PaginationRequest) : IQuery<GetClassesResult>;
public record GetClassesResult(PaginatedResult<ClassDto> Classes);