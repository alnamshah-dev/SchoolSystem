using MediatR;

namespace SchoolSystem.Application.Abstracts.CQRS
{
    public interface ICommand : ICommand<Unit> { }
    public interface ICommand<out TResponse> : IRequest<TResponse> { }
}
