using SchoolSystem.Application.Features.Classes.Commands.UpdateClass;
public class UpdateClassHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateClassCommand, UpdateClassResult>
{
    public async Task<UpdateClassResult> Handle(UpdateClassCommand command, CancellationToken cancellationToken)
    {
        var cls = await dbContext.Classes.FindAsync([command.Id], cancellationToken: cancellationToken);
        if (cls is null)
            throw new ClassNotFoundException(command.Id);

        cls.Name = command.Name;
        cls.Section = command.Section;
        cls.RoomNumber = command.RoomNumber;

        dbContext.Classes.Update(cls);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateClassResult(true);
    }
}