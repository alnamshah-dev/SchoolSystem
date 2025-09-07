namespace SchoolSystem.Application.Extensions;
public static class ClassExtensions
{
    public static IQueryable<ClassDto> ToClassDtoList(this IQueryable<Class> query)
    {
        return query.Select(cls => new ClassDto(
            cls.Id,
            cls.Name,
            cls.Section,
            cls.RoomNumber,
            cls.Teachers.Select(t => new TeacherDto(t.Id, t.FirstName, t.LastName, t.PhoneNumber,
                        t.Classes.Select(c => new ClassDto(c.Id, c.Name, c.Section, c.RoomNumber, new List<TeacherDto>(), new List<SubjectDto>(), new List<StudentDto>(), new List<ScheduleDto>())).ToList(),
                        t.Schedules.Select(s => new ScheduleDto(s.Id, s.ClassId, s.DayOfWeek, s.StartTime, s.EndTime, s.RoomNumber, s.SubjectId, s.TeacherId)).ToList(),
                        t.Subjects.Select(s => new SubjectDto(s.Id, s.Name, s.Description, s.TeacherId, new List<GradeDto>(), new List<ScheduleDto>(), new List<ClassDto>())).ToList()
            )).ToList(),
            cls.Subjects.Select(s => new SubjectDto(s.Id, s.Name, s.Description, s.TeacherId,
                        s.Grades.Select(g => new GradeDto(g.Id, g.Score, g.StudentId, g.SubjectId)).ToList(),
                        s.Schedules.Select(sc => new ScheduleDto(sc.Id, sc.ClassId, sc.DayOfWeek, sc.StartTime, sc.EndTime, sc.RoomNumber, sc.SubjectId, sc.TeacherId)).ToList(),
                        new List<ClassDto>())).ToList(),
            cls.Students.Select(s => new StudentDto(s.Id, s.FirstName, s.LastName, s.ClassId,
                        s.Grades.Select(g => new GradeDto(g.Id, g.Score, g.StudentId, g.SubjectId)).ToList()
            )).ToList(),
            cls.Schedules.Select(s => new ScheduleDto(s.Id, s.ClassId, s.DayOfWeek, s.StartTime, s.EndTime, s.RoomNumber, s.SubjectId, s.TeacherId)).ToList()
        ));
    }

    public static ClassDto ToClassDto(this Class cls)
    {
        return DtoFromClass(cls);
    }

    public static ClassDto DtoFromClass(Class cls)
    {
        return new ClassDto(
            cls.Id,
            cls.Name,
            cls.Section,
            cls.RoomNumber,
            cls.Teachers.Select(t => new TeacherDto(t.Id, t.FirstName, t.LastName, t.PhoneNumber,
                t.Classes.Select(c => new ClassDto(c.Id, c.Name, c.Section, c.RoomNumber, new List<TeacherDto>(), new List<SubjectDto>(), new List<StudentDto>(), new List<ScheduleDto>())).ToList(),
                t.Schedules.Select(s => new ScheduleDto(s.Id, s.ClassId, s.DayOfWeek, s.StartTime, s.EndTime, s.RoomNumber, s.SubjectId, s.TeacherId)).ToList(),
                t.Subjects.Select(s => new SubjectDto(s.Id, s.Name, s.Description, s.TeacherId, new List<GradeDto>(), new List<ScheduleDto>(), new List<ClassDto>())).ToList()
            )).ToList(),
            cls.Subjects.Select(s => new SubjectDto(s.Id, s.Name, s.Description, s.TeacherId,
                s.Grades.Select(g => new GradeDto(g.Id, g.Score, g.StudentId, g.SubjectId)).ToList(),
                s.Schedules.Select(sc => new ScheduleDto(sc.Id, sc.ClassId, sc.DayOfWeek, sc.StartTime, sc.EndTime, sc.RoomNumber, sc.SubjectId, sc.TeacherId)).ToList(),
                new List<ClassDto>())).ToList(),
            cls.Students.Select(s => new StudentDto(s.Id, s.FirstName, s.LastName, s.ClassId,
                s.Grades.Select(g => new GradeDto(g.Id, g.Score, g.StudentId, g.SubjectId)).ToList()
            )).ToList(),
            cls.Schedules.Select(s => new ScheduleDto(s.Id, s.ClassId, s.DayOfWeek, s.StartTime, s.EndTime, s.RoomNumber, s.SubjectId, s.TeacherId)).ToList()
        );
    }
}

