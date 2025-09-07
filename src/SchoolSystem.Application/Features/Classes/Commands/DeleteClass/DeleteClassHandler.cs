using SchoolSystem.Application.Features.Classes.Commands.DeleteClass;
public class DeleteClassHandler(IApplicationDbContext dbContext) : ICommandHandler<DeleteClassCommand, DeleteClassResult>
{
    public async Task<DeleteClassResult> Handle(DeleteClassCommand command, CancellationToken cancellationToken)
    {
        var cls = await dbContext.Classes.FindAsync([command.Id], cancellationToken);
        if (cls is null)
            throw new ClassNotFoundException(command.Id);

        dbContext.Classes.Remove(cls);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new DeleteClassResult(true);
    }
}