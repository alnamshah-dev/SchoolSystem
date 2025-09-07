namespace SchoolSystem.Application.Extensions;
public static class TeacherExtensions
{
    public static IQueryable<TeacherDto> ToTeacherDtoList(this IQueryable<Teacher> query)
    {
        return query.Select(t => new TeacherDto(
            t.Id,
            t.FirstName,
            t.LastName,
            t.PhoneNumber,
            t.Classes.Select(c => new ClassDto(
                c.Id,
                c.Name,
                c.Section,
                c.RoomNumber,
                new List<TeacherDto>(),
                c.Subjects.Select(s => new SubjectDto(
                    s.Id,
                    s.Name,
                    s.Description,
                    s.TeacherId,
                    new List<GradeDto>(),
                    new List<ScheduleDto>(),
                    new List<ClassDto>()
                )).ToList(),
                c.Students.Select(st => new StudentDto(
                    st.Id,
                    st.FirstName,
                    st.LastName,
                    st.ClassId,
                    new List<GradeDto>()
                )).ToList(),
                c.Schedules.Select(sc => new ScheduleDto(
                    sc.Id,
                    sc.ClassId,
                    sc.DayOfWeek,
                    sc.StartTime,
                    sc.EndTime,
                    sc.RoomNumber,
                    sc.SubjectId,
                    sc.TeacherId
                )).ToList()
            )).ToList(),
            t.Schedules.Select(s => new ScheduleDto(
                s.Id,
                s.ClassId,
                s.DayOfWeek,
                s.StartTime,
                s.EndTime,
                s.RoomNumber,
                s.SubjectId,
                s.TeacherId
            )).ToList(),
            t.Subjects.Select(s => new SubjectDto(
                s.Id,
                s.Name,
                s.Description,
                s.TeacherId,
                s.Grades.Select(g => new GradeDto(
                    g.Id,
                    g.Score,
                    g.StudentId,
                    g.SubjectId
                )).ToList(),
                s.Schedules.Select(sc => new ScheduleDto(
                    sc.Id,
                    sc.ClassId,
                    sc.DayOfWeek,
                    sc.StartTime,
                    sc.EndTime,
                    sc.RoomNumber,
                    sc.SubjectId,
                    sc.TeacherId
                )).ToList(),
                new List<ClassDto>()
            )).ToList()
        ));
    }

    public static TeacherDto ToTeacherDto(this Teacher teacher)
    {
        return DtoFromTeacher(teacher);
    }

    public static TeacherDto DtoFromTeacher(Teacher teacher)
    {
        return new TeacherDto(
            teacher.Id,
            teacher.FirstName,
            teacher.LastName,
            teacher.PhoneNumber,
            teacher.Classes.Select(c => new ClassDto(
                c.Id,
                c.Name,
                c.Section,
                c.RoomNumber,
                new List<TeacherDto>(),
                c.Subjects.Select(s => new SubjectDto(
                    s.Id,
                    s.Name,
                    s.Description,
                    s.TeacherId,
                    new List<GradeDto>(),
                    new List<ScheduleDto>(),
                    new List<ClassDto>()
                )).ToList(),
                c.Students.Select(st => new StudentDto(
                    st.Id,
                    st.FirstName,
                    st.LastName,
                    st.ClassId,
                    new List<GradeDto>()
                )).ToList(),
                c.Schedules.Select(sc => new ScheduleDto(
                    sc.Id,
                    sc.ClassId,
                    sc.DayOfWeek,
                    sc.StartTime,
                    sc.EndTime,
                    sc.RoomNumber,
                    sc.SubjectId,
                    sc.TeacherId
                )).ToList()
            )).ToList(),
            teacher.Schedules.Select(s => new ScheduleDto(
                s.Id,
                s.ClassId,
                s.DayOfWeek,
                s.StartTime,
                s.EndTime,
                s.RoomNumber,
                s.SubjectId,
                s.TeacherId
            )).ToList(),
            teacher.Subjects.Select(s => new SubjectDto(
                s.Id,
                s.Name,
                s.Description,
                s.TeacherId,
                s.Grades.Select(g => new GradeDto(
                    g.Id,
                    g.Score,
                    g.StudentId,
                    g.SubjectId
                )).ToList(),
                s.Schedules.Select(sc => new ScheduleDto(
                    sc.Id,
                    sc.ClassId,
                    sc.DayOfWeek,
                    sc.StartTime,
                    sc.EndTime,
                    sc.RoomNumber,
                    sc.SubjectId,
                    sc.TeacherId
                )).ToList(),
                new List<ClassDto>()
            )).ToList()
        );
    }
}
