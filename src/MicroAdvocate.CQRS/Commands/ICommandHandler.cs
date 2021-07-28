using MediatR;

namespace MicroAdvocate.CQRS.Commands
{
    public interface ICommandHandler<in TRequest> : IRequestHandler<TRequest> where TRequest : class, ICommand
    {
    }

    public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
    }
}