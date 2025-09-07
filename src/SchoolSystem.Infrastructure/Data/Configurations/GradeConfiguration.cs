namespace SchoolSystem.Infrastructure.Data.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasOne(g => g.Student)
                   .WithMany(s => s.Grades)
                   .HasForeignKey(g => g.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(g => g.Subject)
                   .WithMany(sub => sub.Grades)
                   .HasForeignKey(g => g.SubjectId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}