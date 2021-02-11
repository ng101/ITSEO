using MediatR;

namespace InfoTrack.Application.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}