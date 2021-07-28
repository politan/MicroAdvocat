using MediatR;

namespace MicroAdvocate.CQRS.Commands
{
    public interface ICommand : IRequest
    {
    }
    
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}