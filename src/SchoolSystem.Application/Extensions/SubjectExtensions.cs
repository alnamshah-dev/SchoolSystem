namespace SchoolSystem.Application.Extensions
{
    public static class SubjectExtensions
    {
        public static IQueryable<SubjectDto> ToSubjectDtoList(this IQueryable<Subject> query)
        {
            return query.Select(subject => new SubjectDto(
                subject.Id,
                subject.Name,
                subject.Description,
                subject.TeacherId,
                subject.Grades.Select(g => new GradeDto(g.Id, g.Score, g.StudentId, g.SubjectId)).ToList(),
                subject.Schedules.Select(s => new ScheduleDto(s.Id, s.ClassId, s.DayOfWeek, s.StartTime, s.EndTime, s.RoomNumber, s.SubjectId, s.TeacherId)).ToList(),
                subject.Classes.Select(c => new ClassDto(c.Id, c.Name, c.Section, c.RoomNumber, new List<TeacherDto>(), new List<SubjectDto>(), new List<StudentDto>(), new List<ScheduleDto>())).ToList()
            ));
        }

        public static SubjectDto ToSubjectDto(this Subject subject)
        {
            return DtoFromSubject(subject);
        }

        public static SubjectDto DtoFromSubject(Subject subject)
        {
            return new SubjectDto(
                subject.Id,
                subject.Name,
                subject.Description,
                subject.TeacherId,
                subject.Grades.Select(g => new GradeDto(g.Id, g.Score, g.StudentId, g.SubjectId)).ToList(),
                subject.Schedules.Select(s => new ScheduleDto(s.Id, s.ClassId, s.DayOfWeek, s.StartTime, s.EndTime, s.RoomNumber, s.SubjectId, s.TeacherId)).ToList(),
                subject.Classes.Select(c => new ClassDto(c.Id, c.Name, c.Section, c.RoomNumber, new List<TeacherDto>(), new List<SubjectDto>(), new List<StudentDto>(), new List<ScheduleDto>())).ToList()
            );
        }
    }
}
