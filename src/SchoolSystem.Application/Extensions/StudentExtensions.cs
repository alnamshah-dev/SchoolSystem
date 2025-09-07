namespace SchoolSystem.Application.Extensions
{
    public static class StudentExtensions
    {
        public static IQueryable<StudentDto> ToStudentDtoList(this IQueryable<Student> query)
        {
            return query.Select(student => new StudentDto(
                student.Id,
                student.FirstName,
                student.LastName,
                student.ClassId,
                student.Grades.Select(g => new GradeDto(g.Id, g.Score, g.StudentId, g.SubjectId)).ToList()
            ));
        }

        public static StudentDto ToStudentDto(this Student student)
        {
            return DtoFromStudent(student);
        }

        public static StudentDto DtoFromStudent(Student student)
        {
            return new StudentDto(
                student.Id,
                student.FirstName,
                student.LastName,
                student.ClassId,
                student.Grades.Select(g => new GradeDto(g.Id, g.Score, g.StudentId, g.SubjectId)).ToList()
            );
        }
    }
}
