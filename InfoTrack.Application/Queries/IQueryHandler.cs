using MediatR;

namespace InfoTrack.Application.Queries
{
    public interface IQueryHandler<in TQuery, TResult> :
IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}