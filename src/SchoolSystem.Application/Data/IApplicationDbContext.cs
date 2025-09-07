namespace SchoolSystem.Application.Data;
public interface IApplicationDbContext
{
    DbSet<Class> Classes { get; }
    DbSet<Student> Students { get; }
    DbSet<Teacher> Teachers { get; }
    DbSet<Grade> Grades { get; }
    DbSet<Subject> Subjects { get; }
    DbSet<Schedule> Schedules { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
