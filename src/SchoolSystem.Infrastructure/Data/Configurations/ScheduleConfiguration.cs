namespace SchoolSystem.Infrastructure.Data.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Class)
                   .WithMany(c => c.Schedules)
                   .HasForeignKey(s => s.ClassId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Subject)
                   .WithMany(sub => sub.Schedules)
                   .HasForeignKey(s => s.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Teacher)
                   .WithMany(t => t.Schedules)
                   .HasForeignKey(s => s.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
