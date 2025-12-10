using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface IQuary<out TResponse> : IRequest<TResponse> where TResponse : notnull
    {
    }
}
