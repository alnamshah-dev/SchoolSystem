
namespace SchoolSystem.Application.Extensions;

public static class GradeExtensions
{
    public static IQueryable<GradeDto> ToGradeDtoList(this IQueryable<Grade> query)
    {
        return query.Select(grade => new GradeDto(
            grade.Id,
            grade.Score,
            grade.StudentId,
            grade.SubjectId
        ));
    }

    public static GradeDto ToGradeDto(this Grade grade)
    {
        return DtoFromGrade(grade);
    }

    public static GradeDto DtoFromGrade(Grade grade)
    {
        return new GradeDto(
            grade.Id,
            grade.Score,
            grade.StudentId,
            grade.SubjectId
        );
    }
}
