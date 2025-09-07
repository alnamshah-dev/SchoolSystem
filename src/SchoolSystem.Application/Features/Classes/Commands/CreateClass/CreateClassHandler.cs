namespace SchoolSystem.Application.Features.Classes.Commands.CreateClass;
public class CreateClassHandler(IApplicationDbContext dbContext) : ICommandHandler<CreateClassCommand, CreateClassResult>
{
    public async Task<CreateClassResult> Handle(CreateClassCommand command, CancellationToken cancellationToken)
    {
        var cls = new Class
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Section = command.Section,
            RoomNumber = command.RoomNumber
        };

        await dbContext.Classes.AddAsync(cls, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateClassResult(cls.Id);
    }
}
