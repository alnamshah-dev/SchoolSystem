using MediatR;

namespace SchoolSystem.Application.Abstracts.CQRS
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
         where TResponse : notnull
    { }
}
