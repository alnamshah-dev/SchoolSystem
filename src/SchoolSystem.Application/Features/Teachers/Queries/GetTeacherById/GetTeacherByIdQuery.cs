namespace SchoolSystem.Application.Features.Teachers.Queries.GetTeacherById;

public record GetTeacherByIdQuery(Guid TeacherId) : IQuery<GetTeacherByIdResult>;
public record GetTeacherByIdResult(TeacherDto Teacher);