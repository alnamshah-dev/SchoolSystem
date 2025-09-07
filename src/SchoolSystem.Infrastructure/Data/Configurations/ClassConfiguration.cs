namespace SchoolSystem.Infrastructure.Data.Configurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Teachers)
                   .WithMany(t => t.Classes)
                   .UsingEntity(j => j.ToTable("ClassTeachers"));
            builder.HasMany(c => c.Subjects)
                   .WithMany(s => s.Classes)
                   .UsingEntity(j => j.ToTable("ClassSubjects"));
        }
    }
}
